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
            ImageSource imageSource = new BitmapImage(new Uri("C:\\Users\\student\\Desktop\\WPFСalculator(GridHard)\\Калькулятор.png"));
            this.Icon = imageSource;
            this.Title = "Калькулятор";
            this.Height = 500;
            this.Width = 450;

            //InitializeComponent();
            double a = 0;
            double b = 0;
            Operation operation = null;
            Grid stack = new Grid();
            Label label0 = new Label()
            {
                Content = "",
                FontSize = 25
            };
            Label label1 = new Label()
            {
                Content = "",
                FontSize = 25
            };


            Label label2 = new Label()
            {
                Content = "",
                FontSize = 20,
            };

            Label label3 = new Label()
            {
                Content = "0",
                FontSize = 20
            };


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


            RowDefinition[] rowDefinition = new RowDefinition[7];
            ColumnDefinition[,] columnDefinitions = new ColumnDefinition[7, 4];
            for (int i = 0; i < 7; i++)
            {
                rowDefinition[i] = new RowDefinition();
                for (int i1 = 0; i1 < 4; i1++)
                {
                    columnDefinitions[i, i1] = new ColumnDefinition();
                }
                stack.RowDefinitions.Add(rowDefinition[i]);
            }
            Grid[] grid = new Grid[7];
            for (int i = 0; i < 7; i++)
            {
                grid[i] = new Grid();
                stack.Children.Add(grid[i]);
                Grid.SetRow(grid[i], i);
                for (int i1 = 0; i1 < 4; i1++)
                {
                    grid[i].ColumnDefinitions.Add(columnDefinitions[i, i1]);
                }
            }
            grid[0].Children.Add(label0);
            Grid.SetColumn(label0, 0);
            grid[0].Children.Add(label1);
            Grid.SetColumn(label1, 1);
            grid[1].Children.Add(label2);
            Grid.SetColumn(label2, 0);
            grid[1].Children.Add(label3);
            Grid.SetColumn(label3, 1);
            grid[2].Children.Add(button21);
            Grid.SetColumn(button21, 0);
            grid[2].Children.Add(button22);
            Grid.SetColumn(button22, 1);
            grid[2].Children.Add(button23);
            Grid.SetColumn(button23, 2);
            grid[2].Children.Add(button24);
            Grid.SetColumn(button24, 3);
            grid[3].Children.Add(button31);
            Grid.SetColumn(button31, 0);
            grid[3].Children.Add(button32);
            Grid.SetColumn(button32, 1);
            grid[3].Children.Add(button33);
            Grid.SetColumn(button33, 2);
            grid[3].Children.Add(button34);
            Grid.SetColumn(button34, 3);
            grid[4].Children.Add(button41);
            Grid.SetColumn(button41, 0);
            grid[4].Children.Add(button42);
            Grid.SetColumn(button42, 1);
            grid[4].Children.Add(button43);
            Grid.SetColumn(button43, 2);
            grid[4].Children.Add(button44);
            Grid.SetColumn(button44, 3);
            grid[5].Children.Add(button51);
            Grid.SetColumn(button51, 0);
            grid[5].Children.Add(button52);
            Grid.SetColumn(button52, 1);
            grid[5].Children.Add(button53);
            Grid.SetColumn(button53, 2);
            grid[5].Children.Add(button54);
            Grid.SetColumn(button54, 3);
            grid[6].Children.Add(button61);
            Grid.SetColumn(button61, 0);
            grid[6].Children.Add(button62);
            Grid.SetColumn(button62, 1);
            grid[6].Children.Add(button63);
            Grid.SetColumn(button63, 2);
            grid[6].Children.Add(button64);
            Grid.SetColumn(button64, 3);



            this.Content = stack;

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
                Deistvie(label0, label1, label2, label3, "+");
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
        public static void DeistvieKnopki(Label label3, string a)
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
