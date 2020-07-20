using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Binding1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //Ряд эллементов и их свойсва использующих двусторонюю привязку.
        /*Stepper Value
        Switch IsToggled
        Entry Text
        Editor Text
        SearchBar Text
        DatePicker Date
        TimePicker Time*/

        static int i = 0;
        public MainPage()
        {
            InitializeComponent();
            StackLayout stack = new StackLayout();

            Label label = new Label { Text = "Default" };
            Entry entry1 = new Entry() { Placeholder = "Target" };
            Entry entry2 = new Entry() { Placeholder = "Source" };
            Button button = new Button { Text = "+1 Mode" };

            entry1.BindingContext = entry2;
            entry1.SetBinding(Entry.TextProperty, "Text");

            button.Clicked += (sender, e) =>
            {
                if (i == 4)
                    i = 0;
                else
                    i++;

                Binding binding1 = new Binding { Source = entry2, Path = "Text", Mode = BindingMode.Default + i };
                entry1.SetBinding(Entry.TextProperty, binding1);

                label.Text = $"{ binding1.Mode}";
            };

            stack.Children.Add(label);
            stack.Children.Add(entry1);
            stack.Children.Add(entry2);
            stack.Children.Add(button);

            #region Default Slider1 == Entry11
            Slider slider1 = new Slider() { Maximum = 100, Minimum = 0, };
            Entry entry11 = new Entry() { Placeholder = "Default" };
            Binding binding6 = new Binding { Source = slider1, Path = "Value", Mode = BindingMode.Default };
            entry11.SetBinding(Entry.TextProperty, binding6);
            stack.Children.Add(entry11);
            stack.Children.Add(slider1);
            #endregion

            //Content = stack;


        }
    }
}
