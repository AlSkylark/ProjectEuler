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
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EulerWPF
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class contentViewer : UserControl
    {
        public contentViewer()
        {
            InitializeComponent();
        }

        private void ContentButton_Click(object sender, RoutedEventArgs e)
        {
            //main two animation instances
            DoubleAnimation angleAnim = new DoubleAnimation();
            DoubleAnimation heightAnim = new DoubleAnimation();

            //we check the rotation of the arrow, if 90° then its pointing down
            //we set different animation properties depending

            if (arrowRotation.Angle ==  0)
            {
                //arrow animation
                angleAnim.To = 90;
                angleAnim.Duration = TimeSpan.FromMilliseconds(100);

                //max height animation
                heightAnim.To = mainStack.ActualHeight + 5;
                heightAnim.Duration = TimeSpan.FromMilliseconds(100);
            } else
            {
                //arrow animation back
                angleAnim.To = 0;
                angleAnim.Duration = TimeSpan.FromMilliseconds(100);

                //max height animation
                heightAnim.To = 1;
                heightAnim.Duration = TimeSpan.FromMilliseconds(100);
            }

            //execute animations
            arrowRotation.BeginAnimation(RotateTransform.AngleProperty, angleAnim);
            mainContent.BeginAnimation(MaxHeightProperty, heightAnim);
        }
    }
}
