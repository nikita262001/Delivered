using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Relativ3Prak
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static int i = 0;
        BoxView box = new BoxView
        {
            BackgroundColor = Color.Green,
            CornerRadius = 10,
        };
        Button button = new Button { Text = "0", IsVisible = false, };
        public MainPage()
        {
            InitializeComponent();
            #region 1 задание
            RelativeLayout relative1 = new RelativeLayout();
            BoxView box = new BoxView
            {
                BackgroundColor = Color.Red,
            };
            Func<RelativeLayout, double> func = TestWidth;

            relative1.Children.Add(box,
                Constraint.RelativeToParent((r) => { return r.Width * 0.05; }),
                Constraint.RelativeToParent((r) => { return r.Height * 0.05; }),
                Constraint.RelativeToParent(func),
                Constraint.RelativeToParent(TestHeight));
            #endregion
            #region 2 задание
            Switch @switch = new Switch();
            @switch.Toggled += TestToggled;
            button.Clicked += TestButton;

            Entry entry = new Entry
            {
                WidthRequest = 100,
                IsPassword = true,
            };

            Image image = new Image
            {
                Source = ImageSource.FromResource("Relativ3Prak.test.jpg"),
            };

            Frame frame = new Frame
            {
                Content = entry,
                CornerRadius = 20,
                BackgroundColor = Color.Cyan,
                BorderColor = Color.Black,
            };

            RelativeLayout relative = new RelativeLayout();

            relative.Children.Add(frame,
                Constraint.RelativeToParent((r) => { return r.Width * 0.1; }),
                Constraint.RelativeToParent((r) => { return r.Height * 0.1; }));

            relative.Children.Add(image,
                Constraint.RelativeToView(frame, (r, v) => { return v.X; }),
                Constraint.RelativeToView(frame, (r, v) => { return v.Y + 100; }));

            relative.Children.Add(button,
                Constraint.RelativeToView(frame, (r, v) => { return v.X + v.Width + 10; }),
                Constraint.RelativeToView(frame, (r, v) => { return v.Y; }));

            relative.Children.Add(@switch,
                Constraint.RelativeToView(image, (r, v) => { return v.X + v.Width + 10; }),
                Constraint.RelativeToView(image, (r, v) => { return v.Y; }));


            ScrollView scroll = new ScrollView
            {
                Content = relative,
            };
            #endregion

            //this.Content = scroll; // 2 задание
            //this.Content = relative; // 1 задание
        }
        #region Методы 2 задание
        private void TestToggled(object sender, EventArgs e)
        {
            Switch sw = (Switch)sender;
            if (sw.IsToggled == false)
            {
                button.IsVisible = false;
            }
            else
            {
                button.IsVisible = true;
            }
        }
        private void TestButton(object sender, EventArgs e)
        {
            i++;
            Button button = (Button)sender;
            button.Text = $"{i}";
        }
        private void TestButtonXam(object sender, EventArgs e)
        {
            i++;
            Button button = (Button)sender;
            button.Text = $"{i}";
        }
        #endregion
        #region Методы 1 задания
        private double TestWidth(RelativeLayout relative)
        {
            return relative.Width * 0.9;
        }
        private double TestHeight(RelativeLayout relative)
        {
            return relative.Height * 0.9;
        }
        #endregion

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            Switch sw = (Switch)sender;
            if (sw.IsToggled == false)
            {
                buttonXam.IsVisible = false;
            }
            else
            {
                buttonXam.IsVisible = true;
            }
        }
    }
}
