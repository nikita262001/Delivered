using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ListViewAndCells
{
    class CustomCell : ViewCell
    {
        Label labelName, labelSurname, labelAge, ageChoosenLabel;
        public Entry nameE, surnameE;
        Slider sl;

        public static readonly BindableProperty NameProperty =
       BindableProperty.Create("Name", typeof(string), typeof(CustomCell), "Имя");
        public static readonly BindableProperty SurnameProperty =
            BindableProperty.Create("Surname", typeof(string), typeof(CustomCell), "Фамилия");
        public static readonly BindableProperty AgeProperty =
            BindableProperty.Create("Age", typeof(int), typeof(CustomCell), 0);

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public string Surname
        {
            get { return (string)GetValue(SurnameProperty); }
            set
            {
                SetValue(SurnameProperty, value);
            }
        }

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public CustomCell()
        {
            FlexLayout fl = new FlexLayout();
            fl.Padding = new Thickness(15);
            fl.Direction = FlexDirection.Column;

            labelName = new Label()
            {
                Text = "Введите имя: "
            };

            labelSurname = new Label()
            {
                Text = "Введите фамилию: "
            };

            labelAge = new Label()
            {
                Text = "Введите возраст: "
            };

            nameE = new Entry();
            surnameE = new Entry() { Margin = new Thickness(0, 10, 0, 0) };
            nameE.SetBinding(Entry.TextProperty, "Name");
            surnameE.SetBinding(Entry.TextProperty, "Surname");

            sl = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            sl.SetBinding(Slider.ValueProperty, "Age");

            ageChoosenLabel = new Label();
            Binding b = new Binding()
            {
                StringFormat = "Возраст: {0:F0}",
                Source = sl,
                Path = "Value"
            };
            ageChoosenLabel.SetBinding(Label.TextProperty, b);

            StackLayout stack = new StackLayout()
            {
                Margin = new Thickness(0, 10, 0, 0),
                Orientation = StackOrientation.Horizontal,
                Children = { sl, ageChoosenLabel }
            };

            fl.Children.Add(labelName);
            fl.Children.Add(nameE);
            fl.Children.Add(labelSurname);
            fl.Children.Add(surnameE);
            fl.Children.Add(stack);

            View = fl;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            //if (BindingContext != null)
            //{
            //    labelName.Text = Name;
            //    labelSurname.Text = Surname;
            //    sl.Value = Age;
            //}
        }
    }
}
