using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prakt10VistView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateOrEditOrInfo : ContentPage
    {
        private void SetHasFalse()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }
        public CreateOrEditOrInfo(ObservableCollection<Person> collection, Person person)
        {
            //InitializeComponent();
            SetHasFalse();

            Label labelName = new Label { Text = "Имя: ", WidthRequest = 100, };
            Entry nameE = new Entry { Placeholder = "Имя", HorizontalOptions = LayoutOptions.FillAndExpand, };
            nameE.SetBinding(Entry.TextProperty, new Binding { Source = person, Path = "Name" });
            StackLayout stackName = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { labelName, nameE } };


            Label labelSurname = new Label { Text = "Фамилия: ", WidthRequest = 100, };
            Entry surnameE = new Entry { Placeholder = "Фамилия", HorizontalOptions = LayoutOptions.FillAndExpand, };
            surnameE.SetBinding(Entry.TextProperty, new Binding { Source = person, Path = "Surname" });
            StackLayout stackSurname = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { labelSurname, surnameE } };

            Label labelAge = new Label { Text = "Возраст: ", WidthRequest = 100, };
            Entry ageE = new Entry { Placeholder = "Возраст", HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric };
            ageE.SetBinding(Entry.TextProperty, new Binding { Source = person, Path = "Age" });
            ageE.TextChanged += AgeE_TextChanged;
            StackLayout stackAge = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { labelAge, ageE } };

            Frame frame = new Frame
            {
                Content = new StackLayout { Children = { stackName, stackSurname, stackAge } },
                CornerRadius = 20,
                BackgroundColor = Color.LightSkyBlue,
                Margin = 20,
            };

            Button button = new Button { FontSize = 20, VerticalOptions = LayoutOptions.EndAndExpand, HeightRequest = 75, };

            if (person == null)
                button.Text = "Добавить";
            else
                button.Text = "Редактировать";

            button.Clicked += (sender, e) =>
            {
                if (person == null)
                {
                    if (ageE.Text.Length == 0)
                        ageE.Text = "0";

                    collection.Add(new Person { Name = nameE.Text, Surname = surnameE.Text, Age = Convert.ToInt32(ageE.Text) });
                }
                else
                {
                    person.Name = nameE.Text;
                    person.Surname = surnameE.Text;
                    person.Age = Convert.ToInt32(ageE.Text);
                }
                Navigation.PopAsync();
            };

            StackLayout mainStack = new StackLayout { Children = { frame, button } };

            Content = mainStack;

        }

        private void AgeE_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry txtE = (Entry)sender;

            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                bool isValid = e.NewTextValue.ToCharArray().All(x => char.IsDigit(x));

                txtE.Text = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
            }
        }

        public CreateOrEditOrInfo(Person person)
        {
            //InitializeComponent();
            SetHasFalse();

            Label labelName = new Label { Text = "Имя: ", WidthRequest = 100, };
            Label nameL = new Label();
            nameL.SetBinding(Label.TextProperty, new Binding { Source = person, Path = "Name" });
            StackLayout stackName = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { labelName, nameL } };


            Label labelSurname = new Label { Text = "Фамилия: ", WidthRequest = 100, };
            Label surnameL = new Label();
            surnameL.SetBinding(Label.TextProperty, new Binding { Source = person, Path = "Surname" });
            StackLayout stackSurname = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { labelSurname, surnameL } };


            Label labelAge = new Label { Text = "Возраст: ", WidthRequest = 100, };
            Label ageL = new Label();
            ageL.SetBinding(Label.TextProperty, new Binding { Source = person, Path = "Age" });
            StackLayout stackAge = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { labelAge, ageL } };

            Frame frame = new Frame
            {
                Content = new StackLayout { Children = { stackName, stackSurname, stackAge } },
                CornerRadius = 20,
                BackgroundColor = Color.LightSkyBlue,
                Margin = 20,
            };

            Button button = new Button { Text = "Назад", FontSize = 20, VerticalOptions = LayoutOptions.EndAndExpand, HeightRequest = 75, };
            button.Clicked += (sender, e) => Navigation.PopAsync();

            StackLayout mainStack = new StackLayout { Children = { frame, button } };

            Content = mainStack;
        }
    }
}