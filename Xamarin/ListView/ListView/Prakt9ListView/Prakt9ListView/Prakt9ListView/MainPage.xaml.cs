using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prakt9ListView
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<Person> peoples = new List<Person>
        {
            new Person { Name = "Рустем" , SurName = "Исламов" , Age = 10},
            new Person { Name = "Никита" , SurName = "Волков" , Age = 20},
            new Person { Name = "Илья" , SurName = "Ермолаев" , Age = 30},
            new Person { Name = "Эмиль" , SurName = "Тагиев" , Age = 40},
            new Person { Name = "Амир" , SurName = "Сафеев" , Age = 50},
            new Person { Name = "Булат" , SurName = "Рахматуллин" , Age = 60},
            new Person { Name = "Даниэль" , SurName = "Малиновский" , Age = 70},
            new Person { Name = "Булат" , SurName = "Нигматуллин" , Age = 80},
        };
        public List<string> pathImage = new List<string>
        {
            "SmallImagePack/image1.jpg",
            "SmallImagePack/image2.jpg",
            "SmallImagePack/image3.jpg",
            "SmallImagePack/image4.jpg",
            "SmallImagePack/image5.jpg",
        };
        public MainPage()
        {
            //InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            StackLayout mainStack = new StackLayout();

            Label label = new Label
            {
                Text = "Информация о студентах",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            ListPaths list = new ListPaths { Items = pathImage};

            ListView mainList = new ListView{};
            int item = 0;
            /*int itemPhoto = 0;*/

            mainList.ItemsSource = text;
            mainList.ItemTapped += MainList_ItemTapped;
            //mainList.ItemsSource = pathImage;
            mainList.ItemTemplate = new DataTemplate(() =>
            {
                var a = this;
                ViewCell viewCell = new ViewCell();

                AbsoluteLayout absolute = new AbsoluteLayout();

                Label name = new Label
                {
                    FontSize = 18,
                };
                
                name.SetBinding(Label.TextProperty,new Binding {Path = "" });

                Label surname = new Label
                {
                    FontSize = 18,
                };
                surname.SetBinding(Label.TextProperty, new Binding { Path = "SurName"});

                Label ageChoosenLabel = new Label
                {
                    FontSize = 18,
                };
                ageChoosenLabel.SetBinding(Label.TextProperty, new Binding { Path = "Age"});

                Label idPeople = new Label { Text = $"Студент {item + 1 }", TextColor = Color.Blue };

                StackLayout stack = new StackLayout { Children = { name, surname, ageChoosenLabel, new Label(), idPeople } };

                Label txt = new Label { Text = "Межрегиональный центр компетенций\nКазанский техникум информационных технологий и связи", FontSize = 12 };

                Image image = new Image { Source = "SmallImagePack/logo.png", Aspect = Aspect.AspectFit };

                Image imagePeople = new Image { Aspect = Aspect.AspectFit };
                imagePeople.SetBinding(Image.SourceProperty, new Binding { Source = list.GetPath(), });

                /*if (item == peoples.Count - 1)
                {
                    item = -1;
                }
                item++;

                if (itemPhoto == pathImage.Count - 1)
                {
                    itemPhoto = -1;
                }
                itemPhoto++;*/

                absolute.Children.Add(txt);
                AbsoluteLayout.SetLayoutBounds(txt, new Rectangle(.05, .05, .8, .15));
                AbsoluteLayout.SetLayoutFlags(txt, AbsoluteLayoutFlags.All);

                absolute.Children.Add(image);
                AbsoluteLayout.SetLayoutBounds(image, new Rectangle(.95, .05, 50, 50));
                AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.PositionProportional);

                absolute.Children.Add(imagePeople);
                AbsoluteLayout.SetLayoutBounds(imagePeople, new Rectangle(.05, .8, .3, .7));
                AbsoluteLayout.SetLayoutFlags(imagePeople, AbsoluteLayoutFlags.All);

                absolute.Children.Add(stack);
                AbsoluteLayout.SetLayoutBounds(stack, new Rectangle(.9, .5, .6, .5));
                AbsoluteLayout.SetLayoutFlags(stack, AbsoluteLayoutFlags.All);


                Frame frame = new Frame
                {
                    Content = absolute,
                    CornerRadius = 15,
                    Padding = 10,
                    Margin = 10,
                    BackgroundColor = Color.LightSkyBlue,
                    BorderColor = Color.Black,
                };

                viewCell.View = frame;

                return viewCell;

            });

            mainStack.Children.Add(label);
            mainStack.Children.Add(mainList);

            Content = mainStack;
        }

        private void MainList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Person person = (Person)e.Item;
            DisplayAlert("Info Click Person", $"Имя: {person.Name},\nФамилия: {person.SurName},\nВозраст: {person.Age}.", "OK");
        }
        public class ListPaths
        {
            public int i = -1;
            public List<string> Items { get; set; }

            public string GetPath()
            {
                i++;
                if (i >= Items.Count)
                {
                    i = 0;
                }
                return Items[i];
            }
        }
    }
}
