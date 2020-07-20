using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewAndCells
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static List<string> names = new List<string>
        {
            "Вилен",
            "Марсель",
            "Алина",
            "Амир",
            "Руфина",
            "Ландыш",
            "Разиль",
            "Даниэль",
            "Нур"
        };
        static List<Person> people = new List<Person>()
        {
            new Person("Вилен", 35, "Евсеев"),
            new Person("Ноунейм", 10, "Ноунеймов"),
            new Person("Вася", 32, "Безфамильный"),
            new Person("Саша", 24, "Какой-то"),
            new Person("Григорий", 18, "Безчувственый"),
        };
        static List<Person> people2 = new List<Person>()
        {
            new Person("Саша", 24, "Какой-то"),
            new Person("Ноунейм", 10, "Ноунеймов"),
            new Person("Григорий", 18, "Безчувственый"),
            new Person("Вася", 32, "Безфамильный"),
            new Person("Вилен", 35, "Евсеев")
        };
        static List<string> labels = new List<string>()
        {
            "Введите имя: ",    
            "Введите фамилию: ",
            "Введите возраст: ",
        };


        int i = 0;

        public MainPage()
        {
            //InitializeComponent();

            // 1
            //ListView l = new ListView()
            //{
            //    ItemsSource = names
            //};

            ListView l = new ListView();

            //Cell
            //TextCell
            //EntryCell
            //ImageCell
            //SwitchCell
            //CustomCell

            // 2
            //l.ItemTemplate = new DataTemplate(() =>
            //{
            //    //Text
            //    //Detail

            //    TextCell textCell = new TextCell();
            //    textCell.Text = names[i];

            //    if (i >= names.Count - 1)
            //    {
            //        i = 0;
            //    }

            //    i++;

            //    return textCell;
            //});

            // 3
            //l.ItemsSource = people;
            //l.SelectionMode = ListViewSelectionMode.None;
            //l.RowHeight = 200;
            //l.ItemTemplate = new DataTemplate(() =>
            //{
            //    TextCell textCell = new TextCell();
            //    textCell.Text = people[i].Name;
            //    textCell.Detail = people[i].Surname;

            //    Random r = new Random();
            //    textCell.TextColor = Color.FromRgb(r.NextDouble(), r.NextDouble(), r.NextDouble());

            //    if (i >= people.Count - 1)
            //    {
            //        i = 0;
            //    }

            //    i++;

            //    return textCell;
            //});

            // 4
            //l.ItemsSource = people;
            //l.ItemTemplate = new DataTemplate(() =>
            //{
            //    TextCell textCell = new TextCell();
            //    textCell.SetBinding(TextCell.TextProperty, "Surname");
            //    textCell.SetBinding(TextCell.DetailProperty, "Name");

            //    Random r = new Random();
            //    textCell.TextColor = Color.FromRgb(r.NextDouble(), r.NextDouble(), r.NextDouble());

            //    return textCell;
            //});

            // 5
            //l.ItemsSource = labels;
            //l.ItemTemplate = new DataTemplate(() =>
            //{
            //    EntryCell entryCell = new EntryCell();
            //    entryCell.Label = labels[i];

            //    Random r = new Random();
            //    entryCell.LabelColor = Color.FromRgb(r.NextDouble(), r.NextDouble(), r.NextDouble());

            //    if (i >= labels.Count - 1)
            //    {
            //        i = 0;
            //    }

            //    i++;

            //    return entryCell;
            //});

            //SwitchCell, ImageCell

            // 6
            //l.ItemsSource = people;
            //l.ItemTemplate = new DataTemplate(() =>
            //{
            //    ViewCell viewCell = new ViewCell();

            //    FlexLayout fl = new FlexLayout();
            //    fl.Padding = new Thickness(15);
            //    fl.Direction = FlexDirection.Column;

            //    Label labelName = new Label()
            //    {
            //        Text = "Введите имя: "
            //    };

            //    Label labelSurname = new Label()
            //    {
            //        Text = "Введите фамилию: "
            //    };

            //    Label labelAge = new Label()
            //    {
            //        Text = "Введите возраст: "
            //    };

            //    Entry nameE = new Entry();
            //    Entry surnameE = new Entry() { Margin = new Thickness(0, 10, 0, 0) };
            //    nameE.SetBinding(Entry.TextProperty, "Name");
            //    surnameE.SetBinding(Entry.TextProperty, "Surname");

            //    Slider sl = new Slider
            //    {
            //        Minimum = 0,
            //        Maximum = 100,
            //        HorizontalOptions = LayoutOptions.FillAndExpand
            //    };
            //    sl.SetBinding(Slider.ValueProperty, "Age");

            //    Label ageChoosenLabel = new Label();
            //    Binding binding = new Binding()
            //    {
            //        StringFormat = "Возраст: {0:F0}",
            //        Source = sl,
            //        Path = "Value"
            //    };
            //    ageChoosenLabel.SetBinding(Label.TextProperty, binding);

            //    StackLayout stack = new StackLayout()
            //    {
            //        Margin = new Thickness(0, 10, 0, 0),
            //        Orientation = StackOrientation.Horizontal,
            //        Children = { sl, ageChoosenLabel }
            //    };

            //    fl.Children.Add(labelName);
            //    fl.Children.Add(nameE);
            //    fl.Children.Add(labelSurname);
            //    fl.Children.Add(surnameE);
            //    fl.Children.Add(stack);

            //    viewCell.View = fl;

            //    return viewCell;
            //});

            // 7

            CustomCell cell = null;

            l.ItemsSource = people;
            l.ItemTemplate = new DataTemplate(() =>
            {
                CustomCell c = new CustomCell();

                c.SetBinding(CustomCell.NameProperty, "Name");
                c.SetBinding(CustomCell.SurnameProperty, "Surname");
                c.SetBinding(CustomCell.AgeProperty, "Age");

                cell = c;

                return c;
            });



            //ContextActions
            //XAML
            //PullToRefresh
            //Header
            //Footer

            Button changeContext = new Button() { Text = "Меняем список" };
            changeContext.Clicked += (sender, e) =>
            {
                Debug.WriteLine(people[people.Count - 1].Name);
                cell.BindingContext = null;
                cell.nameE.Text = "Arnold";
            };

            StackLayout main = new StackLayout();
            main.Children.Add(l);
            main.Children.Add(changeContext);

            Content = main;
        }
    }
}
