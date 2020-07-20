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
    public partial class Page1 : ContentPage
    {
        StackLayout stack = new StackLayout();
        Label labelStack = new Label();
        public Page1(string[] vs)
        {
            //InitializeComponent();
            Entry entry = new Entry { Placeholder = "Пусто(напиши сюда что нибудь)", };
            Button button = new Button { Text = "Далее страница 2", };
            button.Clicked += (obj, e) =>
            {
                vs[1] = entry.Text;
                Navigation.PushAsync(new Page2(vs));
            };

            foreach (var item in vs)
            {
                stack.Children.Add(new Label { Text = $"{item}" });
            }
            stack.Children.Add(entry);
            stack.Children.Add(button);
            stack.Children.Add(labelStack);

            this.Content = stack;

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