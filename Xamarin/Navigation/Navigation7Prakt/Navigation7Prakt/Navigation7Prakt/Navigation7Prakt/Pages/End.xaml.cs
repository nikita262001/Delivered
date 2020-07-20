using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation7Prakt
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class End : ContentPage
    {
        Label labelStack = new Label();
        public End(string[] vs)
        {
            //InitializeComponent();
            NavigationPage.SetHasBackButton(this,false);
            StackLayout stack = new StackLayout();

            #region StackLabelText
            foreach (var item in vs)
            {
                stack.Children.Add(new Label { Text = $"{item}" });
            }

            Button button = new Button {Text ="Ну чтож, в начало?",BackgroundColor = Color.White, };
            button.Clicked += (obj, e) =>
            {
                Navigation.InsertPageBefore(new MainPage(), this);
                Navigation.PopAsync();
            };

            Frame frame = new Frame
            {
                BackgroundColor = Color.Green,
                Content = stack,
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };
            #endregion

            stack.Children.Add(button);
            stack.Children.Add(labelStack);

            this.Content = frame;
        }
        protected override void OnAppearing()
        {
            labelStack.Text = "";
            foreach (Page item in Navigation.NavigationStack)
            {
                labelStack.Text += $"{item.GetType()}\n";
            }
        }
    }
}