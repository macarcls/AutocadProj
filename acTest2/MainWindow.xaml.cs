using System.Diagnostics;
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
        Graphic _graphicModel;
        public MainWindow()
        {
            InitializeComponent();
            _graphicModel = new Graphic();
            DataContext = _graphicModel;
            
        }

        public void formula(object sender, RoutedEventArgs e)
        {
            /*int count_pl = 120; //int.Parse(plastini.Text);
            int convXY = 350; //int.Parse(Name.Text);
            int z = count_pl + (count_pl * 5) + (80 * 2);
            int x = convXY;
            int y = x;
            int cold_side_count_of_nozzles = int.Parse(col_flanci_cold.Text);
            int Hot_side_count_of_nozzles = int.Parse(col_flanci_hot.Text);
            int nozzle_d = 120;
            int peregor_hot = 2;
            int peregor_cold = 2;*/
            Graphic graphic = new Graphic 
            { 
                x = _graphicModel.x * 10,
                y = _graphicModel.x * 10,
                count_pl = _graphicModel.count_pl,
                peregor_hot = _graphicModel.peregor_hot,
                peregor_cold = _graphicModel.peregor_cold,
                cold_side_count_of_nozzles = _graphicModel.cold_side_count_of_nozzles,
                Hot_side_count_of_nozzles = _graphicModel.Hot_side_count_of_nozzles,
                nozzle_d = _graphicModel.nozzle_d
            };
            if (Type.Text == "V")
            {
                graphic.create_V();
            }
            else if (Type.Text == "H")
            {
                graphic.create_H();
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
        }
    }
}