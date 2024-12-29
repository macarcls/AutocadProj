using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace acTest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*Button button = new Button();
            button.Margin = new System.Windows.Thickness(78,352,552,41);
            button.Content = "Generate";
            button.Click += formula;
            generate.Children.Add(button);*/ 
        }

        public void formula(object sender, RoutedEventArgs e)
        {
            int count_pl = 120; //int.Parse(plastini.Text);
            int convXY = 350; //int.Parse(Name.Text);
            int z = count_pl + (count_pl * 5) + (80 * 2);
            int x = convXY;
            int y = x;
            int cold_side_count_of_nozzles = int.Parse(col_flanci_cold.Text);
            int Hot_side_count_of_nozzles = int.Parse(col_flanci_hot.Text);
            int nozzle_d = 120;
            int peregor_hot = 2;
            int peregor_cold = 2;

            if (Type.Text == "V")
            {
                Graphic.create_V(x, y, z, nozzle_d, peregor_hot, peregor_cold, cold_side_count_of_nozzles, Hot_side_count_of_nozzles);
            }
            else if (Type.Text == "H")
            {
                Graphic.create_H(x, y, z, nozzle_d, peregor_hot, peregor_cold, cold_side_count_of_nozzles, Hot_side_count_of_nozzles);
            }
            MessageBox.Show("done!");
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                col_flanci_cold.Focus();
            }
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                col_flanci_cold.Focus();
            }
            if (e.Key == Key.Up)
            {
                e.Handled = true;
                Type.Focus();
            }
        }
        private void TextBox_PreviewKeyDown2(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                col_flanci_hot.Focus();
            }
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                col_flanci_hot.Focus();
            }
            if (e.Key == Key.Up)
            {
                e.Handled = true;
                Model.Focus();
            }
        }
        private void TextBox_PreviewKeyDown3(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                plates.Focus();
            }
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                plates.Focus();
            }
            if (e.Key == Key.Up)
            {
                e.Handled = true;
                col_flanci_cold.Focus();
            }
        }
        private void TextBox_PreviewKeyDown4(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                partitc.Focus();
            }
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                partitc.Focus();
            }
            if (e.Key == Key.Up)
            {
                e.Handled = true;
                col_flanci_hot.Focus();
            }
        }
        private void TextBox_PreviewKeyDown5(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                partith.Focus();
            }
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                partith.Focus();
            }
            if (e.Key == Key.Up)
            {
                e.Handled = true;
                plates.Focus();
            }
        }
        private void TextBox_PreviewKeyDown6(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                Type.Focus();
            }
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                Type.Focus();
            }
            if (e.Key == Key.Up)
            {
                e.Handled = true;
                partitc.Focus();
            }
        }
        private void TextBox_PreviewKeyDown7(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                Model.Focus();
            }
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                Model.Focus();
            }
            if (e.Key == Key.Up)
            {
                e.Handled = true;
                partith.Focus();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.Open(System.IO.Path.Combine(Environment.CurrentDirectory,"\\sample1.dxf"), FileMode.Open);
            MessageBox.Show(Environment.CurrentDirectory);
        }
    }
}