using System;
using System.Collections.Generic;
using System.IO;//
using System.Runtime.Serialization.Formatters.Binary;//
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFСalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate double Operation(double a, double b);
        public MainWindow()
        {
            ImageSource imageSource = new BitmapImage(new Uri("C:\\Users\\student\\Desktop\\WPFСalculator(StackPanel)\\Калькулятор.png"));
            this.Icon = imageSource;
            this.Title = "Калькулятор";
            this.Height = 375;
            this.Width = 315;

            //InitializeComponent();
            double a = 0;
            double b = 0;
            Operation operation = null; 

            StackPanel stackPanel = new StackPanel();
            StackPanel stack0 = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };
            StackPanel stack1 = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            StackPanel stack2 = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            StackPanel stack3 = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            StackPanel stack4 = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            StackPanel stack5 = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            StackPanel stack6 = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };

            stackPanel.Children.Add(stack0);
            stackPanel.Children.Add(stack1);
            stackPanel.Children.Add(stack2);
            stackPanel.Children.Add(stack3);
            stackPanel.Children.Add(stack4);
            stackPanel.Children.Add(stack5);
            stackPanel.Children.Add(stack6);

            Label label0 = new Label()
            {
                Content = "",
                FontSize = 20
            };
            Label label1 = new Label()
            {
                Content = "",
                FontSize = 20
            };

            stack0.Children.Add(label0);
            stack0.Children.Add(label1);

            Label label2 = new Label()
            {
                Content = "",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                FontSize = 17,


            };

            Label label3 = new Label()
            {
                Content = "0",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 100,
                FontSize = 17
            };

            stack1.Children.Add(label2);
            stack1.Children.Add(label3);

            Button button21 = new Button()
            {
                Content = "CE",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button22 = new Button()
            {
                Content = "C",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button23 = new Button()
            {
                Content = "←",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };
            Button button24 = new Button()
            {
                Content = "/",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            stack2.Children.Add(button21);
            stack2.Children.Add(button22);
            stack2.Children.Add(button23);
            stack2.Children.Add(button24);

            Button button31 = new Button()
            {
                Content = "7",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button32 = new Button()
            {
                Content = "8",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button33 = new Button()
            {
                Content = "9",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };
            Button button34 = new Button()
            {
                Content = "X",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            stack3.Children.Add(button31);
            stack3.Children.Add(button32);
            stack3.Children.Add(button33);
            stack3.Children.Add(button34);

            Button button41 = new Button()
            {
                Content = "4",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button42 = new Button()
            {
                Content = "5",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button43 = new Button()
            {
                Content = "6",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };
            Button button44 = new Button()
            {
                Content = "──",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            stack4.Children.Add(button41);
            stack4.Children.Add(button42);
            stack4.Children.Add(button43);
            stack4.Children.Add(button44);

            Button button51 = new Button()
            {
                Content = "1",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button52 = new Button()
            {
                Content = "2",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button53 = new Button()
            {
                Content = "3",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };
            Button button54 = new Button()
            {
                Content = "+",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            stack5.Children.Add(button51);
            stack5.Children.Add(button52);
            stack5.Children.Add(button53);
            stack5.Children.Add(button54);

            Button button61 = new Button()
            {
                Content = "+/-",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button62 = new Button()
            {
                Content = "0",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            Button button63 = new Button()
            {
                Content = ".",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };
            Button button64 = new Button()
            {
                Content = "=",
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                MinHeight = 50,
                MinWidth = 75
            };

            stack6.Children.Add(button61);
            stack6.Children.Add(button62);
            stack6.Children.Add(button63);
            stack6.Children.Add(button64);

            this.Content = stackPanel;

            button21.Click += (sender, e) =>
            {
                label2.Content = "";
                label3.Content = "0";
            };

            button22.Click += (sender, e) =>
            {
                label0.Content = "";
                label1.Content = "";
                label2.Content = "";
                label3.Content = "0";
                operation = null;

            };

            button23.Click += (sender, e) =>
            {
                string label = (string)label3.Content;
                if (label.Length > 1)
                {
                    label3.Content = label.Remove(label.Length - 1);
                }
                else
                {
                    label2.Content = "";
                    label3.Content = "0";
                }
            };

            button24.Click += (sender, e) =>
            {
                Deistvie(label0, label1, label2, label3, "/");
                operation += Delit;
            };

            button31.Click += (sender, e) =>
            {
                DeistvieKnopki(label3, "7");
            };
            button32.Click += (sender, e) =>
            {
                DeistvieKnopki(label3, "8");
            };
            button33.Click += (sender, e) =>
            {
                DeistvieKnopki(label3, "9");
            };
            button34.Click += (sender, e) =>
            {
                Deistvie(label0, label1, label2, label3, "*");
                operation += Umnoj;
            };
            button41.Click += (sender, e) =>
            {
                DeistvieKnopki(label3, "4");
            };
            button42.Click += (sender, e) =>
            {
                DeistvieKnopki(label3, "5");
            };
            button43.Click += (sender, e) =>
            {
                DeistvieKnopki(label3, "6");
            };
            button44.Click += (sender, e) =>
            {
                Deistvie(label0, label1, label2, label3, "-");
                operation += Minus;
            };
            button51.Click += (sender, e) =>
            {
                DeistvieKnopki(label3, "1");
            };
            button52.Click += (sender, e) =>
            {
                DeistvieKnopki(label3, "2");
            };
            button53.Click += (sender, e) =>
            {
                DeistvieKnopki(label3, "3");
            };
            button54.Click += (sender, e) =>
            {
                Deistvie(label0, label1, label2,label3,"+");
                operation += Plus;
            };
            button61.Click += (sender, e) =>
            {
                if ((string)label2.Content == "=")
                {
                    label2.Content = "";
                }
                string labelt = (string)label2.Content;
                string label = (string)label3.Content;
                if (labelt.Length == 0 && double.Parse(label) != 0)
                    label2.Content = "-";
                else
                    label2.Content = "";
            };
            button62.Click += (sender, e) =>
            {
                string label = (string)label3.Content;
                if (double.Parse(label) != 0 || label.Length != 1)
                {
                    label3.Content += "0";
                }
            };
            button63.Click += (sender, e) =>
            {
                string label = (string)label3.Content;
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
                    label3.Content += ",";
                }
            };
            button64.Click += (sender, e) =>
            {
                if (label0.Content != "" && label1.Content != "")
                {
                    label3.Content = $"{(string)label2.Content}{double.Parse((string)label3.Content)}";
                    a = double.Parse((string)label0.Content);
                    b = double.Parse((string)label3.Content);
                    label0.Content = "";
                    label1.Content = "";
                    label2.Content = "=";
                    label3.Content = $"{operation(a, b)}";
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
            if (double.Parse((string)label3.Content) != 0)
            {
                if ((string)label2.Content == "=")
                {
                    label2.Content = "";
                }
                if ((string)label2.Content == "-" && double.Parse((string)label3.Content) < 0)
                {
                    label0.Content = Math.Abs(double.Parse((string)label3.Content));
                }
                else if ((string)label2.Content == "-")
                {
                    label0.Content = $"{label2.Content}" + $"{label3.Content}";
                }
                else
                {
                    label0.Content = $"{label3.Content}";
                }
            }
            label1.Content = a;
            label2.Content = "";
            label3.Content = "0";
        }
        public static void DeistvieKnopki(Label label3,string a)
        {

            string label = (string)label3.Content;
            if (double.Parse(label) == 0 && label.Length == 1)
            {
                label3.Content = a;
            }
            else
            {
                label3.Content += a;
            }
        }
    }
}
