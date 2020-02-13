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

        public MainWindow()
        {
            InitializeComponent();
        }
        //public int currentNum = 1;
        public int currentMargin = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
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
                scrollGrid.Children.Add(newCtl);
                currentMargin += 60;
            }

        }
        public class SearchResult
        {
            public string Number { get; set; }
            public string Title { get; set; }
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            //gridProblemList.Margin = new Thickness(0, 0, 0, 0);

            //HERE I NEED TO RUN THE CODE OF THE TEST BUTTON!!


            ThicknessAnimationUsingKeyFrames animation = new ThicknessAnimationUsingKeyFrames();
            //ThicknessKeyFrame key1;
            //key1.Value = gridProblemList.Margin;
            //animation.KeyFrames.Add();

            animation.AccelerationRatio = 0.2;
            
            gridProblemList.BeginAnimation(MarginProperty, animation);

        }
    }

}

