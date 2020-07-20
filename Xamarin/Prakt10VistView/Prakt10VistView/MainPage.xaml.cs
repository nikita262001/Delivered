using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prakt10VistView
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Person> people = new ObservableCollection<Person>
        {
            new Person { Name = "Рустем" , Surname = "Исламов" , Age = 10},
            new Person { Name = "Никита" , Surname = "Волков" , Age = 20},
            new Person { Name = "Илья" , Surname = "Ермолаев" , Age = 30},
            new Person { Name = "Эмиль" , Surname = "Тагиев" , Age = 40},
            new Person { Name = "Амир" , Surname = "Сафеев" , Age = 50},
            new Person { Name = "Булат" , Surname = "Рахматуллин" , Age = 60},
            new Person { Name = "Даниэль" , Surname = "Малиновский" , Age = 70},
            new Person { Name = "Булат" , Surname = "Нигматуллин" , Age = 80},
        };

        public MainPage()
        {
            //InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            Label label = new Label { Text = "Информация", HorizontalOptions = LayoutOptions.Center, FontSize = 40, };

            Button button = new Button { HeightRequest = 75, Text = "Добавить", FontSize = 30 };
            button.Clicked += Button_Clicked;

            ListView list = new ListView { RowHeight = Device.RuntimePlatform == Device.Android ? 110 : Device.RuntimePlatform == Device.UWP ? 140 : 160, };

            list.ItemsSource = people;
            list.ItemTapped += List_ItemTapped;
            list.ItemTemplate = new DataTemplate(() =>
            {
                Label labelName = new Label { FontSize = 14, };
                labelName.SetBinding(Label.TextProperty, new Binding { Path = "Name", StringFormat = "Имя: {0}", });

                Label labelSurname = new Label { FontSize = 14, };
                labelSurname.SetBinding(Label.TextProperty, new Binding { Path = "Surname", StringFormat = "Фамилия: {0}" });

                ImageButton imageRemove = new ImageButton { Source = "imageRemove.png", BackgroundColor = Color.Transparent,};
                imageRemove.Clicked += ImageRemove_Clicked;

                ImageButton imageEdit = new ImageButton { Source = "imageEdit.png", BackgroundColor = Color.Transparent,};
                imageEdit.Clicked += ImageEdit_Clicked;

                RelativeLayout relative = new RelativeLayout { };

                relative.Children.Add(labelName,
                     Constraint.RelativeToParent((parent) => parent.Width * .05),
                     Constraint.RelativeToParent((parent) => parent.Height * .01));


                relative.Children.Add(labelSurname,
                     Constraint.RelativeToView(labelName, (parent, view) => view.X),
                     Constraint.RelativeToView(labelName, (parent, view) => view.Y + view.Height + 2));


                relative.Children.Add(imageRemove,
                     Constraint.RelativeToView(imageEdit, (parent, view) => view.X - 70),
                     Constraint.RelativeToView(imageEdit, (parent, view) => view.Y),
                     Constraint.RelativeToParent((parent) => 50),
                     Constraint.RelativeToParent((parent) => 50));


                relative.Children.Add(imageEdit,
                     Constraint.RelativeToParent((parent) => parent.Width - 40),
                     Constraint.RelativeToParent((parent) => (parent.Height * 0.5) - 25),
                     Constraint.RelativeToParent((parent) => 50),
                     Constraint.RelativeToParent((parent) => 50));

                return new ViewCell { View = new Frame { Margin = 15, Content = relative, CornerRadius = 20, BackgroundColor = Color.LightSkyBlue, HeightRequest = 70 } };
            });

            Content = new StackLayout { Children = { label, list, button }, };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateOrEditOrInfo(people, null));
        }

        private void ImageEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateOrEditOrInfo(people, ReturnPerson(sender)));
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

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Person person = (Person)e.Item;
            Navigation.PushAsync(new CreateOrEditOrInfo(person));
            /*DisplayAlert("Полная информация о человеке", $"Имя: {person.Name}\nФамилия: {person.Surname}\nВозраст: {person.Age}", "Ok");*/
        }
    }
}