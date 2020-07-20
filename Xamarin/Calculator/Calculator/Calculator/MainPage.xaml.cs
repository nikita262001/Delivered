using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        delegate double Operation(double a, double b);
        public MainPage()
        {
            //InitializeComponent();

            double a = 0;
            double b = 0;
            Operation operation = null;

            StackLayout StackLayout = new StackLayout();
            StackLayout stack0 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
            };
            StackLayout stack1 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout stack2 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout stack3 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout stack4 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout stack5 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout stack6 = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            StackLayout.Children.Add(stack0);
            StackLayout.Children.Add(stack1);
            StackLayout.Children.Add(stack2);
            StackLayout.Children.Add(stack3);
            StackLayout.Children.Add(stack4);
            StackLayout.Children.Add(stack5);
            StackLayout.Children.Add(stack6);

            Label label0 = new Label()
            {
                Text = "",
                FontSize = 30,
                Margin = 50,
            };
            Label label1 = new Label()
            {
                Text = "",
                FontSize = 30,
                Margin = 50,
            };

            stack0.Children.Add(label0);
            stack0.Children.Add(label1);

            Label label2 = new Label()
            {
                Text = "",
                FontSize = 30,
            };

            Label label3 = new Label()
            {
                Text = "0",
                FontSize = 30,
            };

            stack1.Children.Add(label2);
            stack1.Children.Add(label3);

            Button button21 = new Button()
            {
                Text = "CE"
            };

            Button button22 = new Button()
            {
                Text = "C"
            };

            Button button23 = new Button()
            {
                Text = "←"
            };
            Button button24 = new Button()
            {
                Text = "/"
            };

            stack2.Children.Add(button21);
            stack2.Children.Add(button22);
            stack2.Children.Add(button23);
            stack2.Children.Add(button24);

            Button button31 = new Button()
            {
                Text = "7"
            };

            Button button32 = new Button()
            {
                Text = "8"
            };

            Button button33 = new Button()
            {
                Text = "9"
            };
            Button button34 = new Button()
            {
                Text = "X"
            };

            stack3.Children.Add(button31);
            stack3.Children.Add(button32);
            stack3.Children.Add(button33);
            stack3.Children.Add(button34);

            Button button41 = new Button()
            {
                Text = "4"
            };

            Button button42 = new Button()
            {
                Text = "5"
            };

            Button button43 = new Button()
            {
                Text = "6"
            };
            Button button44 = new Button()
            {
                Text = "──"
            };

            stack4.Children.Add(button41);
            stack4.Children.Add(button42);
            stack4.Children.Add(button43);
            stack4.Children.Add(button44);

            Button button51 = new Button()
            {
                Text = "1"
            };

            Button button52 = new Button()
            {
                Text = "2"
            };

            Button button53 = new Button()
            {
                Text = "3"
            };
            Button button54 = new Button()
            {
                Text = "+"
            };

            stack5.Children.Add(button51);
            stack5.Children.Add(button52);
            stack5.Children.Add(button53);
            stack5.Children.Add(button54);

            Button button61 = new Button()
            {
                Text = "+/-"
            };

            Button button62 = new Button()
            {
                Text = "0"
            };

            Button button63 = new Button()
            {
                Text = "."
            };
            Button button64 = new Button()
            {
                Text = "="
            };

            stack6.Children.Add(button61);
            stack6.Children.Add(button62);
            stack6.Children.Add(button63);
            stack6.Children.Add(button64);

            this.Content = StackLayout;

            button21.Pressed += (sender, e) =>
            {
                label2.Text = "";
                label3.Text = "0";
            };

            button22.Pressed += (sender, e) =>
            {
                label0.Text = "";
                label1.Text = "";
                label2.Text = "";
                label3.Text = "0";
                operation = null;

            };

            button23.Pressed += (sender, e) =>
            {
                string label = (string)label3.Text;
                if (label.Length > 1)
                {
                    label3.Text = label.Remove(label.Length - 1);
                }
                else
                {
                    label2.Text = "";
                    label3.Text = "0";
                }

                if (label3.Text == "-")
                {
                    label3.Text = "0";
                    label2.Text = "";
                }
            };

            button24.Pressed += (sender, e) =>
            {
                Deistvie(label0, label1, label2, label3, "/");
                operation += Delit;
            };

            button31.Pressed += (sender, e) =>
            {
                DeistvieKnopki(label3, "7");
            };
            button32.Pressed += (sender, e) =>
            {
                DeistvieKnopki(label3, "8");
            };
            button33.Pressed += (sender, e) =>
            {
                DeistvieKnopki(label3, "9");
            };
            button34.Pressed += (sender, e) =>
            {
                Deistvie(label0, label1, label2, label3, "*");
                operation += Umnoj;
            };
            button41.Pressed += (sender, e) =>
            {
                DeistvieKnopki(label3, "4");
            };
            button42.Pressed += (sender, e) =>
            {
                DeistvieKnopki(label3, "5");
            };
            button43.Pressed += (sender, e) =>
            {
                DeistvieKnopki(label3, "6");
            };
            button44.Pressed += (sender, e) =>
            {
                Deistvie(label0, label1, label2, label3, "-");
                operation += Minus;
            };
            button51.Pressed += (sender, e) =>
            {
                DeistvieKnopki(label3, "1");
            };
            button52.Pressed += (sender, e) =>
            {
                DeistvieKnopki(label3, "2");
            };
            button53.Pressed += (sender, e) =>
            {
                DeistvieKnopki(label3, "3");
            };
            button54.Pressed += (sender, e) =>
            {
                Deistvie(label0, label1, label2, label3, "+");
                operation += Plus;
            };
            button61.Pressed += (sender, e) =>
            {
                if ((string)label2.Text == "=")
                {
                    label2.Text = "";
                }
                string labelt = (string)label2.Text;
                string label = (string)label3.Text;
                if (labelt.Length == 0 && double.Parse(label) != 0)
                    label2.Text = "-";
                else
                    label2.Text = "";
            };
            button62.Pressed += (sender, e) =>
            {
                string label = (string)label3.Text;
                if (double.Parse(label) != 0 || label.Length != 1)
                {
                    label3.Text += "0";
                }
            };
            button63.Pressed += (sender, e) =>
            {
                string label = (string)label3.Text;
                bool tf = true;
                for (int i = 0; i < label.Length; i++)
                {
                    if (label[i] == ',')
                    {
                        tf = false;
                        break;
                    }
                }
                if (tf)
                {
                    label3.Text += ",";
                }
            };
            button64.Pressed += (sender, e) =>
            {
                if (label0.Text != "" && label1.Text != "")
                {
                    label3.Text = $"{(string)label2.Text}{double.Parse((string)label3.Text)}";
                    a = double.Parse((string)label0.Text);
                    b = double.Parse((string)label3.Text);
                    label0.Text = "";
                    label1.Text = "";
                    label2.Text = "=";
                    label3.Text = $"{operation(a, b)}";
                }
            };
        }
        public static double Minus(double a, double b)
        {
            return a - b;
        }
        public static double Plus(double a, double b)
        {
            return a + b;
        }
        public static double Umnoj(double a, double b)
        {
            return a * b;
        }
        public static double Delit(double a, double b)
        {
            return a / b;
        }
        public static void Deistvie(Label label0, Label label1, Label label2, Label label3, string a)
        {
            if (double.Parse((string)label3.Text) != 0)
            {
                if ((string)label2.Text == "=")
                {
                    label2.Text = "";
                }
                if ((string)label2.Text == "-" && double.Parse((string)label3.Text) < 0)
                {
                    label0.Text = $"{Math.Abs(double.Parse(label3.Text))}";
                }
                else if ((string)label2.Text == "-")
                {
                    label0.Text = $"{label2.Text}" + $"{label3.Text}";
                }
                else
                {
                    label0.Text = $"{label3.Text}";
                }
            }
            label1.Text = a;
            label2.Text = "";
            label3.Text = "0";
        }
        public static void DeistvieKnopki(Label label3, string a)
        {

            string label = (string)label3.Text;
            if (double.Parse(label) == 0 && label.Length == 1)
            {
                label3.Text = a;
            }
            else
            {
                label3.Text += a;
            }
        }
    }
}
