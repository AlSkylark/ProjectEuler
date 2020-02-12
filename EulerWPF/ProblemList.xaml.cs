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
using Newtonsoft.Json;

namespace EulerWPF
{
    /// <summary>
    /// Interaction logic for ProblemList.xaml
    /// </summary>
    public partial class ProblemList : Page
    {
        public ProblemList()
        {
            InitializeComponent();
        }
        public int currentNum = 2;
        public int currentMargin = 250;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listControl newCtl = new listControl();
            newCtl.Number = "Problem" + currentNum;
            newCtl.Title = "Some title lel";
            newCtl.Margin = new Thickness(10, currentMargin, 0, 0);
            problemGrid.Children.Add(newCtl);
            currentNum++;
            currentMargin += 160;
        }
    }
}
