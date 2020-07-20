using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
            Grid grid = new Grid();

            ColumnDefinition column1 = new ColumnDefinition();
            ColumnDefinition column2 = new ColumnDefinition();
            ColumnDefinition column3 = new ColumnDefinition();
            ColumnDefinition column4 = new ColumnDefinition();

            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);
            grid.ColumnDefinitions.Add(column3);
            grid.ColumnDefinitions.Add(column4);

            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();

            grid.RowDefinitions.Add(row1);
            grid.RowDefinitions.Add(row2);

            Label l1 = new Label
            {
                Background = new SolidColorBrush(Color.FromArgb(50, 100, 150, 100)),
                Content = "1"
            };
            Label l2 = new Label
            {
                Background = new SolidColorBrush(Color.FromArgb(100, 50, 100, 25)),
                Content = "2"
            };
            Label l3 = new Label
            {
                Background = new SolidColorBrush(Color.FromArgb(25, 25, 25, 25)),
                Content = "3"
            };
            Label l4 = new Label
            {
                Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)),
                Content = "4"
            };

            grid.Children.Add(l1);
            grid.Children.Add(l2);
            grid.Children.Add(l3);
            grid.Children.Add(l4);

            Grid.SetColumn(l1, 0);
            Grid.SetRow(l1, 0);

            Grid.SetColumn(l2, 1);
            Grid.SetRow(l2, 0);

            Grid.SetColumn(l3, 1);
            Grid.SetRow(l3, 1);

            Grid.SetColumn(l4, 0);
            Grid.SetRow(l4, 1);

            /*StackPanel stack = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            ScrollViewer scroll = new ScrollViewer()
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Visible
            };


            stack.Children.Add(l1);
            stack.Children.Add(l2);
            stack.Children.Add(l3);
            stack.Children.Add(l4);*/


            this.Content = grid;
        }
    }
}
