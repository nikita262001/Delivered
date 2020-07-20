using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prakt12SQLite
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

        Button button;
        Button buttonDel;
        Image imageBicycle;
        Picker pImage;
        public AddOrEditBicycle()
        {
            #region elements
            Label lID = new Label { };
            lID.SetBinding(Label.TextProperty, new Binding { Path = "ID", StringFormat = "ID: {0}" });

            Label lName = new Label { Text = "Название: ", WidthRequest = 200, };
            Entry eName = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            eName.SetBinding(Entry.TextProperty, new Binding { Path = "Name" });
            StackLayout sName = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lName, eName } };

            Label lModelNumber = new Label { Text = "Номер модели: ", WidthRequest = 200, };
            Entry eModelNumber = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            eModelNumber.SetBinding(Entry.TextProperty, new Binding { Path = "ModelNumber" });
            StackLayout sModelNumber = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lModelNumber, eModelNumber } };

            Label lNumberOfGears = new Label { Text = "Количество скоростей: ", WidthRequest = 200, };
            Entry eNumberOfGears = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            eNumberOfGears.SetBinding(Entry.TextProperty, new Binding { Path = "NumberOfGears" });
            StackLayout sNumberOfGears = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lNumberOfGears, eNumberOfGears } };

            Label lMaxSpeed = new Label { Text = "Максимальная скорость: ", WidthRequest = 200, };
            Entry eMaxSpeed = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            eMaxSpeed.SetBinding(Entry.TextProperty, new Binding { Path = "MaxSpeed" });
            StackLayout sMaxSpeed = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lMaxSpeed, eMaxSpeed } };

            Label lPrice = new Label { Text = "Цена: ", WidthRequest = 200, };
            Entry ePrice = new Entry { HorizontalOptions = LayoutOptions.FillAndExpand, };
            ePrice.SetBinding(Entry.TextProperty, new Binding { Path = "Price" });
            StackLayout sPrice = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lPrice, ePrice } };

            Label lDateOfIssue = new Label { Text = "Дата выпуска: ", WidthRequest = 200, };
            DatePicker dpDateOfIssue = new DatePicker { HorizontalOptions = LayoutOptions.StartAndExpand, };
            dpDateOfIssue.SetBinding(DatePicker.DateProperty, new Binding { Path = "DateOfIssue" });
            StackLayout sDateOfIssue = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lDateOfIssue, dpDateOfIssue } };

            Label lOnTheRun = new Label { Text = "На ходу: ", WidthRequest = 200, };
            Switch swOnTheRun = new Switch { HorizontalOptions = LayoutOptions.FillAndExpand, };
            swOnTheRun.SetBinding(Switch.IsToggledProperty, new Binding { Path = "OnTheRun" });
            StackLayout sOnTheRun = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { lOnTheRun, swOnTheRun } };

            Label lImage = new Label { Text = "Картинка: ", WidthRequest = 200, };
            pImage = new Picker { HorizontalOptions = LayoutOptions.StartAndExpand, };
            pImage.SelectedIndexChanged += PImage_SelectedIndexChanged;
            foreach (var item in elementsPickerImage)
            {
                pImage.Items.Add(item);
            }
            pImage.SetBinding(Picker.SelectedItemProperty, new Binding { Path = "Image" });
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

        private void EditBicycleDB(object sender, EventArgs e)
        {
            App.Database.EditItem(BindingContext as Bicycles);
            Navigation.PopAsync();
        }

        private void AddBicycleDB(object sender, EventArgs e)
        {
            App.Database.SaveItem(BindingContext as Bicycles);
            Navigation.PopAsync();
        }
    }
}