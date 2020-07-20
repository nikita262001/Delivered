using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prakt13SQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditBicycle : ContentPage
    {
        List<string> elementsPickerImage = new List<string>
        {
            "Images/Ardis.jpg" ,
            "Images/Assembly1.jpg" ,
            "Images/Assembly2.jpg",
            "Images/Assembly3.jpg",
            "Images/Giant.jpg" ,
            "Images/Gravity.jpg",
            "Images/LarsenTrack.jpg" ,
            "Images/Stels.jpg" ,
            "Images/Trek.jpg" ,
            "Images/Worthersee.jpg" ,
            "Images/Байкал.jpg"
        };
        ObservableCollection<Bicycles> bicycles;//
        Button button;
        Button buttonDel;
        Image imageBicycle;
        Picker pImage;
        Entry eName, eModelNumber, eNumberOfGears, eMaxSpeed, ePrice;
        DatePicker dpDateOfIssue;
        Switch swOnTheRun;
        public AddOrEditBicycle(ObservableCollection<Bicycles> _bicycles)
        {
            bicycles = _bicycles; //

            #region elements
            Label lID = new Label { };
            lID.SetBinding(Label.TextProperty, new Binding { Path = "ID", StringFormat = "ID: {0}" });

            Label lName = new Label { Text = "Название: ", WidthRequest = 200, };
            eName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            eName.SetBinding(Entry.TextProperty, new Binding { Path = "Name", Mode = BindingMode.OneTime }); //
            StackLayout sName = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lName, eName } };

            Label lModelNumber = new Label { Text = "Номер модели: ", WidthRequest = 200, };
            eModelNumber = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            eModelNumber.SetBinding(Entry.TextProperty, new Binding { Path = "ModelNumber", Mode = BindingMode.OneTime }); //
            StackLayout sModelNumber = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lModelNumber, eModelNumber } };

            Label lNumberOfGears = new Label { Text = "Количество скоростей: ", WidthRequest = 200, };
            eNumberOfGears = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            eNumberOfGears.SetBinding(Entry.TextProperty, new Binding { Path = "NumberOfGears", Mode = BindingMode.OneTime }); //
            StackLayout sNumberOfGears = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lNumberOfGears, eNumberOfGears } };

            Label lMaxSpeed = new Label { Text = "Максимальная скорость: ", WidthRequest = 200, };
            eMaxSpeed = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            eMaxSpeed.SetBinding(Entry.TextProperty, new Binding { Path = "MaxSpeed", Mode = BindingMode.OneTime }); //
            StackLayout sMaxSpeed = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lMaxSpeed, eMaxSpeed } };

            Label lPrice = new Label { Text = "Цена: ", WidthRequest = 200, };
            ePrice = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            ePrice.SetBinding(Entry.TextProperty, new Binding { Path = "Price", Mode = BindingMode.OneTime }); //
            StackLayout sPrice = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lPrice, ePrice } };

            Label lDateOfIssue = new Label { Text = "Дата выпуска: ", WidthRequest = 200, };
            dpDateOfIssue = new DatePicker { HorizontalOptions = LayoutOptions.StartAndExpand, };
            dpDateOfIssue.SetBinding(DatePicker.DateProperty, new Binding { Path = "DateOfIssue", Mode = BindingMode.OneTime }); //
            StackLayout sDateOfIssue = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lDateOfIssue, dpDateOfIssue } };

            Label lOnTheRun = new Label { Text = "На ходу: ", WidthRequest = 200, };
            swOnTheRun = new Switch { HorizontalOptions = LayoutOptions.FillAndExpand, };
            swOnTheRun.SetBinding(Switch.IsToggledProperty, new Binding { Path = "OnTheRun", Mode = BindingMode.OneTime }); //
            StackLayout sOnTheRun = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lOnTheRun, swOnTheRun } };

            Label lImage = new Label { Text = "Картинка: ", WidthRequest = 200, };
            pImage = new Picker { HorizontalOptions = LayoutOptions.StartAndExpand, };
            pImage.SelectedIndexChanged += PImage_SelectedIndexChanged;
            foreach (var item in elementsPickerImage)
            {
                pImage.Items.Add(item);
            }
            pImage.SetBinding(Picker.SelectedItemProperty, new Binding { Path = "Image", Mode = BindingMode.OneTime }); //
            StackLayout sImage = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lImage, pImage } };

            imageBicycle = new Image
            {
                HeightRequest = 300,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.AspectFit,
                IsVisible = false,
            };

            #endregion

            Frame frame = new Frame
            {
                Content = new StackLayout { Children = { lID, sName, sModelNumber, sNumberOfGears, sMaxSpeed, sPrice, sDateOfIssue, sOnTheRun, sImage, imageBicycle } },
                CornerRadius = 20,
                BackgroundColor = Color.LightSkyBlue,
                Margin = 20,
            };

            buttonDel = new Button { FontSize = 30, HeightRequest = 75, Text = "Удалить", IsVisible = false };
            buttonDel.Clicked += DeleteBicycle;
            button = new Button { FontSize = 30, HeightRequest = 75, };
            StackLayout sButtons = new StackLayout { Children = { buttonDel, button }, VerticalOptions = LayoutOptions.EndAndExpand };

            StackLayout mainStack = new StackLayout { Children = { frame, sButtons } };

            Content = mainStack;
        }

        private void DeleteBicycle(object sender, EventArgs e)
        {
            App.Database.DeleteItem(BindingContext as Bicycles);
            bicycles.Remove(BindingContext as Bicycles); //
            Navigation.PopAsync();
        }

        private void PImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pImage.SelectedIndex != -1)
            {
                imageBicycle.IsVisible = true;
                imageBicycle.Source = elementsPickerImage[pImage.SelectedIndex];
            }
        }

        protected override void OnAppearing()
        {
            if ((BindingContext as Bicycles).ID == 0)
            {
                button.Text = "Добавить";
                button.Clicked += AddBicycleDB;
            }
            else
            {
                imageBicycle.IsVisible = true;
                buttonDel.IsVisible = true;
                button.Text = "Редактировать";
                button.Clicked += EditBicycleDB;
            }
        }

        bool endedСorrectly = true;
        private void EditBicycleDB(object sender, EventArgs e)
        {
            EditBicycles(BindingContext as Bicycles);//
            if (endedСorrectly == false)//
                return;

            App.Database.EditItem(BindingContext as Bicycles);
            Navigation.PopAsync();
        }
        private void EditBicycles(Bicycles bicycles) //
        {
            bicycles.Name = eName.Text;
            bicycles.DateOfIssue = dpDateOfIssue.Date;
            bicycles.OnTheRun = swOnTheRun.IsToggled;
            try
            {
                bicycles.ModelNumber = Convert.ToInt32(eModelNumber.Text);
                bicycles.NumberOfGears = Convert.ToInt32(eNumberOfGears.Text);
                bicycles.MaxSpeed = Convert.ToInt32(eMaxSpeed.Text);
                bicycles.Price = Convert.ToInt32(ePrice.Text);
                bicycles.Image = Convert.ToString(pImage.SelectedItem);
                endedСorrectly = true;

            }
            catch (Exception ex)
            {
                endedСorrectly = false;
                DisplayAlert("Уведомление", "Вы ввели данные не корректно", "ОK");
            }

        }

        private void AddBicycleDB(object sender, EventArgs e)
        {
            EditBicycles(BindingContext as Bicycles);//
            if (endedСorrectly == false)//
                return;

            App.Database.SaveItem(BindingContext as Bicycles);
            bicycles.Add(BindingContext as Bicycles);//
            Navigation.PopAsync();
        }
    }
}