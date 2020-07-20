using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prakt11Serialize
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        List<Person> people = new List<Person>();
        Label label;
        ListView list;
        public SecondPage()
        {
            label = new Label { HorizontalOptions = LayoutOptions.Center, FontSize = 40, IsVisible = false };

            #region ListView
            list = new ListView { IsVisible = false, RowHeight = Device.RuntimePlatform == Device.Android ? 110 : Device.RuntimePlatform == Device.UWP ? 140 : 160, };

            list.ItemTemplate = new DataTemplate(() =>
            {
                Label labelName = new Label { FontSize = 14, };
                labelName.SetBinding(Label.TextProperty, new Binding { Path = "Name", StringFormat = "Имя: {0}", });

                Label labelSurname = new Label { FontSize = 14, };
                labelSurname.SetBinding(Label.TextProperty, new Binding { Path = "Surname", StringFormat = "Фамилия: {0}" });

                Label labelYearOfBirth = new Label { FontSize = 14, };
                labelYearOfBirth.SetBinding(Label.TextProperty, new Binding { Path = "YearOfBirth", StringFormat = "Дата рождения: {0}" });

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
                #endregion

                return new ViewCell { View = new Frame { Margin = 15, Content = relative, CornerRadius = 20, BackgroundColor = Color.LightSeaGreen, HeightRequest = 70 } };
            });
            #endregion

            Content = new StackLayout { Children = { label, list }, };
        }
        protected async override void OnAppearing()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    #region Android
                    var pathToFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    var pathToFile = pathToFolder + @"\jsonFile.json";
                    //Debug.WriteLine(pathToFile);

                    people = await Deserialise(pathToFile);
                    list.ItemsSource =people;
                    #endregion
                    break;

                case Device.UWP:
                    #region UWP
                    pathToFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    pathToFile = pathToFolder + @"\jsonFile.json";
                    //Debug.WriteLine(pathToFile);

                    list.ItemsSource = people = await Deserialise(pathToFile);
                    #endregion
                    break;

                default:
                    break;
            }
            if (people.Count == 0)
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(SecondPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("Prakt11Serialize.txtLabel.embedded"); // Загружает указанный ресурс манифеста из сборки.

                using (var reader = new StreamReader(stream))
                {
                    label.Text = reader.ReadLine();
                }
                label.IsVisible = true;
            }
            else
            {
                list.IsVisible = true;
            }
        }

        async Task<List<Person>> Deserialise(string path)
        {
            return await Task<List<Person>>.Factory.StartNew(() =>
            {
                string txt = "";
                using (StreamReader fileStream = new StreamReader(path))
                    txt = fileStream.ReadLine();

                return JsonConvert.DeserializeObject<List<Person>>(txt);
            });
        }
    }
}