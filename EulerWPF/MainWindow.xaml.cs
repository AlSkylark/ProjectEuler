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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json.Linq;
using System.IO;

namespace EulerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int currentMargin = 0;
        //private string solTitle = "";
        //private string solNumber = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        public string UserNameIni
        {
            get
            {
                return Properties.Settings.Default.UserName;
            }
        }

        public class SearchResult
        {
            public string Number { get; set; }
            public string Title { get; set; }
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            currentMargin = 0;
            scrollGrid.Children.Clear();

            //establish the json string, aka open the damn json lol
            string json = "";
            using (StreamReader r = new StreamReader(@"C:\Users\Al\source\repos\ProjectEuler\EulerWPF\testjson.json"))
            {
                json = r.ReadToEnd();
            }

            //we open a JObject searching specific thangs
            JObject problemSearch = JObject.Parse(json);

            //make a list of them JSON objects
            IList<JToken> results = problemSearch["Problems"].Children().ToList();

            //serialize JSON results into the .NET objects
            IList<SearchResult> searchResults = new List<SearchResult>();
            foreach (JToken result in results)
            {
                SearchResult jsonSearch = result.ToObject<SearchResult>();
                searchResults.Add(jsonSearch);
            }

            //then we SORT this list by the PROBLEMS property
            IEnumerable<SearchResult> sortedEnum = searchResults.OrderBy(problems => problems.Number);
            IList<SearchResult> sortedResults = sortedEnum.ToList();

            //then for each object in the json list we make a new listControl
            foreach (SearchResult thing in sortedResults)
            {
                listControl newCtl = new listControl();
                newCtl.Number = thing.Number;
                newCtl.Title = thing.Title;
                newCtl.HorizontalAlignment = HorizontalAlignment.Left;
                newCtl.VerticalAlignment = VerticalAlignment.Top;
                newCtl.Margin = new Thickness(0, currentMargin, 0, 0);
                //newCtl.
                scrollGrid.Children.Add(newCtl);
                currentMargin += 60;
            }


            ThicknessAnimationUsingKeyFrames animation = new ThicknessAnimationUsingKeyFrames();

            ThicknessKeyFrame key1 = new SplineThicknessKeyFrame();
            key1.Value = new Thickness(1208, 0, 0, 0);
            key1.KeyTime = TimeSpan.FromSeconds(0.1);

            ThicknessKeyFrame key2 = new SplineThicknessKeyFrame();
            key2.Value = new Thickness(0, 0, 0, 0);
            key2.KeyTime = TimeSpan.FromSeconds(1);

            animation.KeyFrames.Add(key1);
            animation.KeyFrames.Add(key2);

            animation.AccelerationRatio = 0.2;
            animation.BeginTime = TimeSpan.FromSeconds(.3);
            gridProblemList.BeginAnimation(MarginProperty, animation);

        }

        private void newCtl_Click(object sender, System.EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}

