﻿using System;
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
    /// Interaction logic for ProblemList.xaml
    /// </summary>
    public partial class ProblemList : Page
    {
        public ProblemList()
        {
            InitializeComponent();
        }
        public int currentNum = 2;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listControl newCtl = new listControl();
            newCtl.Number = "Problem" + currentNum;
            newCtl.Title = "Some title lel";
            problemGrid.Children.Add(newCtl);
            currentNum++;
        }
    }
}
