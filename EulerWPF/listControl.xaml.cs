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

namespace EulerWPF
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class listControl : UserControl
    {
        public listControl()
        {
            InitializeComponent();
            //DataContext = this;
        }
        private string hNumber = "Problem 1";
        private string hTitle = "Here's a title";
        public string Number { get { return hNumber; } set { hNumber = value;  } }

        public string Title { get { return hTitle; } set { hTitle = value; } }
    }
}
