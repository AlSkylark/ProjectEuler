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
using System.Windows.Shapes;

namespace EulerWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public int currentNum = 2;
        public int currentMargin = 60;
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i=0;i<200;i++)
            {
                listControl newCtl = new listControl();
                
                newCtl.Number = "Problem " + currentNum;
                newCtl.Title = "Some title lel";
                newCtl.HorizontalAlignment = HorizontalAlignment.Left;
                newCtl.VerticalAlignment = VerticalAlignment.Top;
                newCtl.Margin = new Thickness(0, currentMargin, 0, 0);
                scrollGrid.Children.Add(newCtl);
                currentNum++;
                currentMargin += 60;
            }

        }
    }
}
