using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Binding2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1(Person person)
        {
            //InitializeComponent();

            Entry entry1 = new Entry();
            Entry entry2 = new Entry();
            Entry entry3 = new Entry();
            Button button = new Button { Text = "Сохранить" };

            button.Clicked += (sender, e) =>
            {
                person.Name = entry1.Text;
                person.SurName = entry2.Text;
                person.Patronymic = entry3.Text;
                Navigation.PopAsync();
            };

            StackLayout stack = new StackLayout
            {
                Children = { entry1, entry2, entry3, button },
            };

            Content = stack;
        }
    }
}