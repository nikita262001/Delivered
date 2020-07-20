using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prakt11Serialize
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Person> people = new ObservableCollection<Person>();
        ListView list;
        public MainPage()
        {
            Label label = new Label { Text = "Информация", HorizontalOptions = LayoutOptions.Center, FontSize = 40, };

            Button button = new Button { HeightRequest = 75, Text = "Сериализация списка в json", FontSize = 30 };
            button.Clicked += SerializePeopleToFile;
            #region ListView
            list = new ListView { RowHeight = Device.RuntimePlatform == Device.Android ? 110 : Device.RuntimePlatform == Device.UWP ? 140 : 160, };

            list.ItemTemplate = new DataTemplate(() =>
            {
                Label labelName = new Label { FontSize = 14, };
                labelName.SetBinding(Label.TextProperty, new Binding { Path = "Name", StringFormat = "Имя: {0}", });

                Label labelSurname = new Label { FontSize = 14, };
                labelSurname.SetBinding(Label.TextProperty, new Binding { Path = "Surname", StringFormat = "Фамилия: {0}" });

                Label labelYearOfBirth = new Label { FontSize = 14, };
                labelYearOfBirth.SetBinding(Label.TextProperty, new Binding { Path = "YearOfBirth", StringFormat = "Дата рождения: {0}" });

                ImageButton imageRemove = new ImageButton { Source = "imageRemove.png", BackgroundColor = Color.Transparent, };
                imageRemove.Clicked += ImageRemove_Clicked;

                #region RelativeLayout
                RelativeLayout relative = new RelativeLayout { };

                relative.Children.Add(labelName,
                     Constraint.RelativeToParent((parent) => parent.Width * .05),
                     Constraint.RelativeToParent((parent) => parent.Height * .005));

                relative.Children.Add(labelSurname,
                     Constraint.RelativeToView(labelName, (parent, view) => view.X),
                     Constraint.RelativeToView(labelName, (parent, view) => view.Y + view.Height + 2));

                relative.Children.Add(labelYearOfBirth,
                     Constraint.RelativeToView(labelSurname, (parent, view) => view.X),
                     Constraint.RelativeToView(labelSurname, (parent, view) => view.Y + view.Height + 2));

                relative.Children.Add(imageRemove,
                     Constraint.RelativeToParent((parent) => parent.Width - 40),
                     Constraint.RelativeToParent((parent) => (parent.Height * 0.5) - 25),
                     Constraint.RelativeToParent((parent) => 50),
                     Constraint.RelativeToParent((parent) => 50));
                #endregion

                return new ViewCell { View = new Frame { Margin = 15, Content = relative, CornerRadius = 20, BackgroundColor = Color.LightSkyBlue, HeightRequest = 70 } };
            });
            #endregion

            Content = new StackLayout { Children = { label, list, button }, };
        }
        protected override void OnAppearing()
        {
            people = new ObservableCollection<Person>();
            foreach (var pers in new DataBase().People)
            {
                people.Add(pers);
            }
            list.ItemsSource = people;
        }

        private async void SerializePeopleToFile(object sender, EventArgs e)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    #region Android
                    var pathToFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    var pathToFile = pathToFolder + @"\jsonFile.json";
                    Debug.WriteLine(pathToFile);

                    using (var fileStream = new FileStream(pathToFile, FileMode.Create))
                    {
                        var txt = JsonConvert.SerializeObject(people);
                        byte[] array = Encoding.UTF8.GetBytes(txt);
                        await fileStream.WriteAsync(array, 0, array.Length);
                    }
                    #endregion
                    break;

                case Device.UWP:
                    #region UWP
                    pathToFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    pathToFile = pathToFolder + @"\jsonFile.json";
                    Debug.WriteLine(pathToFile);

                    using (var fileStream = new FileStream(pathToFile, FileMode.Create))
                    {
                        var txt = JsonConvert.SerializeObject(people);
                        byte[] array = Encoding.Default.GetBytes(txt);
                        await fileStream.WriteAsync(array, 0, array.Length);
                    }
                    #endregion
                    break;

                default:
                    break;
            }
            Navigation.PushAsync(new SecondPage());
        }

        private void ImageRemove_Clicked(object sender, EventArgs e)
        {
            people.Remove(ReturnPerson(sender));
        }
        private Person ReturnPerson(object sender)
        {
            ImageButton image = (ImageButton)sender;
            RelativeLayout relative = (RelativeLayout)image.Parent;
            Frame frame = (Frame)relative.Parent;
            ViewCell cell = (ViewCell)frame.Parent;

            return (Person)cell.BindingContext;
        }
    }
}
