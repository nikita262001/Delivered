using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prakt12SQLite
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Bicycles> bicycles = new ObservableCollection<Bicycles>();
        ListView list;
        public MainPage()
        {
            Label label = new Label { Text = "Информация", HorizontalOptions = LayoutOptions.Center, FontSize = 40, };

            Button button = new Button { HeightRequest = 75, Text = "Добавить", FontSize = 30 };
            button.Clicked += AddBicycle;
            #region ListView
            list = new ListView { RowHeight = 220,  };
            list.ItemTapped += List_ItemTapped;

            list.ItemTemplate = new DataTemplate(() =>
            {
                Label lName = new Label { FontSize = 14, };
                lName.SetBinding(Label.TextProperty, new Binding { Path = "Name", StringFormat = "Название: {0}", });

                Label lModelNumber = new Label { FontSize = 14, };
                lModelNumber.SetBinding(Label.TextProperty, new Binding { Path = "ModelNumber", StringFormat = "Номер модели: {0}", });

                Label lNumberOfGears = new Label { FontSize = 14, };
                lNumberOfGears.SetBinding(Label.TextProperty, new Binding { Path = "NumberOfGears", StringFormat = "Количество скоростей: {0}", });

                Label lMaxSpeed = new Label { FontSize = 14, };
                lMaxSpeed.SetBinding(Label.TextProperty, new Binding { Path = "MaxSpeed", StringFormat = "Максимальная скорость: {0}", });

                Label lPrice = new Label { FontSize = 14, };
                lPrice.SetBinding(Label.TextProperty, new Binding { Path = "Price", StringFormat = "Цена: {0}", });

                Label lDateOfIssue = new Label { FontSize = 14, };
                lDateOfIssue.SetBinding(Label.TextProperty, new Binding { Path = "DateOfIssue", StringFormat = "Дата выпуска: {0:dd/MM/yyyy}", });

                Label lOnTheRun = new Label { FontSize = 14, };
                lOnTheRun.SetBinding(Label.TextProperty, new Binding { Path = "OnTheRun", StringFormat = "На ходу: {0}", });

                Image image = new Image { Aspect = Aspect.AspectFit };
                image.SetBinding(Image.SourceProperty, new Binding { Path = "Image" });

                #region RelativeLayout
                RelativeLayout relative = new RelativeLayout { };

                relative.Children.Add(image,
                     Constraint.RelativeToParent((parent) => -5),
                     Constraint.RelativeToParent((parent) => -5),
                     Constraint.RelativeToParent((parent) => parent.Width * 0.075+150),
                     Constraint.RelativeToParent((parent) => 150));

                relative.Children.Add(lName,
                     Constraint.RelativeToView(image, (parent, view) => view.X + view.Width + 10),
                     Constraint.RelativeToView(image, (parent, view) => 5));

                relative.Children.Add(lModelNumber,
                     Constraint.RelativeToView(lName, (parent, view) => view.X),
                     Constraint.RelativeToView(lName, (parent, view) => view.Y + view.Height + 2));

                relative.Children.Add(lNumberOfGears,
                     Constraint.RelativeToView(lModelNumber, (parent, view) => view.X),
                     Constraint.RelativeToView(lModelNumber, (parent, view) => view.Y + view.Height + 2));

                relative.Children.Add(lMaxSpeed,
                     Constraint.RelativeToView(lNumberOfGears, (parent, view) => view.X),
                     Constraint.RelativeToView(lNumberOfGears, (parent, view) => view.Y + view.Height + 2));

                relative.Children.Add(lPrice,
                     Constraint.RelativeToView(lMaxSpeed, (parent, view) => view.X),
                     Constraint.RelativeToView(lMaxSpeed, (parent, view) => view.Y + view.Height + 2));

                relative.Children.Add(lDateOfIssue,
                     Constraint.RelativeToView(lPrice, (parent, view) => view.X),
                     Constraint.RelativeToView(lPrice, (parent, view) => view.Y + view.Height + 2));

                relative.Children.Add(lOnTheRun,
                     Constraint.RelativeToView(lDateOfIssue, (parent, view) => view.X),
                     Constraint.RelativeToView(lDateOfIssue, (parent, view) => view.Y + view.Height + 2));

                #endregion

                return new ViewCell { View = new Frame { Margin = 15, Content = relative, CornerRadius = 20, BackgroundColor = Color.LightSkyBlue, HeightRequest = 70 } };
            });
            #endregion

            Content = new StackLayout { Children = { label, list, button }, };
        }

        private void List_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new AddOrEditBicycle { BindingContext = (Bicycles)e.Item });
        }

        private void AddBicycle(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddOrEditBicycle { BindingContext = new Bicycles()});
        }

        protected override void OnAppearing()
        {
            list.ItemsSource = App.Database.GetItems();
        }
    }
}
