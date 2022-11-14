using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        
        byte countCommand , countNegative = 0;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNegativeClick(object sender, RoutedEventArgs e)
        {
            if (countCommand == 0)
            {
                txtBResult.Text = txtBResult.Text.Insert(0, "-");
                ++countCommand;
            }
            else if (countNegative == 1)
            {
                txtBResult.Text = txtBResult.Text.Remove(0, 1);
                countNegative = 0;
            }
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (txtBResult.Text == "0")
            {
                txtBResult.Clear();
            }

            Button button = (Button)sender;
            txtBResult.Text = txtBResult.Text + button.Content;
        }

        

        private void btnCommanClick(object sender, RoutedEventArgs e)
        {
            string same = txtBResult.Text;
            var result = new DataTable().Compute(same, null);
            txtBResult.Text = result.ToString();
        }

        private void btnRemoveAllClick(object sender, RoutedEventArgs e)
        {
            txtBResult.Text = "0";
        }

        private void btnDeleteoneClick(object sender, RoutedEventArgs e)
        {
            if (txtBResult.Text.Length == 1)
                txtBResult.Text = "0";
            else
            {
                txtBResult.Text = txtBResult.Text.Remove(txtBResult.Text.Length - 1, 1);

                if (txtBResult.Text[txtBResult.Text.Length - 1] == '.')
                {
                    txtBResult.Text = txtBResult.Text.Remove(txtBResult.Text.Length - 1, 1);
                    countCommand = 0;
                }
                if (txtBResult.Text[txtBResult.Text.Length - 1] == '-')
                {
                    txtBResult.Text = txtBResult.Text.Remove(txtBResult.Text.Length - 1, 1);
                    countCommand = 0;
                }
            }
        }
    }
}
