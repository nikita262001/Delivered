using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Binding2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Person person = new Person { Name = "Label №1", SurName = "Label №2", Patronymic = "Label №3" };
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            label1.SetBinding(Label.TextProperty, new Binding { Path = "Name", Mode = BindingMode.OneWay, Source = person });
            label2.SetBinding(Label.TextProperty, new Binding { Path = "SurName", Mode = BindingMode.OneWay, Source = person });
            label3.SetBinding(Label.TextProperty, new Binding { Path = "Patronymic", Mode = BindingMode.OneWay, Source = person });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1(person));
        }
    }
}
