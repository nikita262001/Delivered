using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXaml12
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.BackgroundColor = Color.Cyan;
            InitializeComponent();
            StackLayout stack = new StackLayout
            {
                Padding = 50, // внутреняя
                BackgroundColor = Color.AliceBlue,
                Margin = 50, // внешняя
            };
            ScrollView scroll = new ScrollView
            {
                Content = stack,
            };
            Frame frame = new Frame
            {
                BackgroundColor = Color.Orange,
                CornerRadius = 40,
                Content = new Label { Text = "LabelFrame" }
            };
            Image image = new Image
            {
                Source = ImageSource.FromResource("AppXaml12.qwer.jpg"),
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = 300,
            };
            Entry entry = new Entry
            {
                //Text = "Cursor position set",
                //CursorPosition = 2,
                //SelectionLength = 10,
                Placeholder = "Password",
                PlaceholderColor = Color.Olive,
                //MaxLength = 10,
                CharacterSpacing = 10,
                IsPassword = true,
                Keyboard = Keyboard.Chat,
                TextColor = Color.Red,
                BackgroundColor = Color.FromHex("#00FF00"),
            };
            Label label = new Label
            {
                TextColor = Color.Green,
                Text = "Label",
                CharacterSpacing = 10,
                BackgroundColor = Color.FromHex("#00FFBB"),
            };
            Editor editor = new Editor //на новую строку
            {
                Placeholder = "User",
                PlaceholderColor = Color.Olive,
                CharacterSpacing = 10,
                Keyboard = Keyboard.Email,
                HeightRequest = 100,
            };

            int i = 0;
            Button button = new Button
            {
                Text = $"{i}",
            };
            button.Clicked /*Press*/ += (sender, e) => // лямбда выражения
            {
                i++;
                Button a = (Button)sender;
                a.Text = $"{i}";
            };
            BoxView boxView = new BoxView
            {
                CornerRadius = 20,
                BackgroundColor = Color.Black,
                HeightRequest = 100,
                WidthRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
            };
            Switch @switch = new Switch
            {
                OnColor = Color.Orange,
                ThumbColor = Color.Green,
            };
            @switch.Toggled += (sender, e) =>
            {
                Switch a = (Switch)sender;
                if (a.IsToggled == true) // on=true , off = false
                {
                    i++;
                    button.Text = $"{i}";
                }
            };


            stack.Children.Add(frame);
            stack.Children.Add(image);
            stack.Children.Add(entry);
            stack.Children.Add(label);
            stack.Children.Add(editor);
            stack.Children.Add(button);
            stack.Children.Add(boxView);
            stack.Children.Add(@switch);

            //this.Content = scroll;
        }
        static int i = 0;
        private void WorkButton(object sender, EventArgs e)
        {
            Button a = (Button)sender;
            i++;
            a.Text = $"{i}";
        }
        private void WorkSwitch(object sender, ToggledEventArgs e)
        {
            Switch a = (Switch)sender;
            i++;
            button.Text = $"{i}";
            if (a.IsToggled == true) // on=true , off = false
                boxView.BackgroundColor = Color.Coral;
            else
                boxView.BackgroundColor = Color.Red;
        }
    }
}