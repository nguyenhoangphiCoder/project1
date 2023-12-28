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
using System.Windows.Shapes;

namespace Phanmemquanlybanhang
{
    /// <summary>
    /// Interaction logic for SpendingWindow.xaml
    /// </summary>
    public partial class SpendingWindow : Window
    {
        public SpendingWindow()
        {
            InitializeComponent();
        }

       
        private void ChildWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Ngăn chặn đóng cửa sổ con
            e.Cancel = true;

            // Ẩn cửa sổ con thay vì đóng
            ((Window)sender).Hide();
        }
       private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;

            }
            else this.WindowState = WindowState.Normal;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // WindowState = WindowState.Minimized;

            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;

            }
            else this.WindowState = WindowState.Normal;
        }
    }
}
