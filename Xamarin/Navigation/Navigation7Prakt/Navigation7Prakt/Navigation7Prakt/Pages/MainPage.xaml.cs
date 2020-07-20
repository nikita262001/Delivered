using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation7Prakt
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Label labelStack = new Label();
        public MainPage()
        {
            InitializeComponent();
            stack.Children.Add(labelStack);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string[] vs = new string[3];
            vs[0] = entry.Text;
            Navigation.PushAsync(new Page1(vs));
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
