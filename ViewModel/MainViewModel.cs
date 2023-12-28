using Phanmemquanlybanhang.Model;
using Phanmemquanlybanhang.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Phanmemquanlybanhang.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public ICommand StaffCommand { get; set; }
        public ICommand RevenueCommand { get; set; }
        public ICommand SpendingCommand { get; set; }
        public ICommand SuplierCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            }
              );
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerWindow wd = new CustomerWindow(); wd.ShowDialog(); });
            ProductCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ProductWindow wd = new ProductWindow(); wd.ShowDialog(); });
            StaffCommand = new RelayCommand<object>((p) =>
            {
                LoginWindow loginWindow = new LoginWindow();
                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.Password=="admin" || loginVM.Password=="manager")
                {
                    return true;
                }
                return false;

            }, (p) => 
            { 
                StaffWindow wd = new StaffWindow();
                wd.ShowDialog();
            }
            );
            RevenueCommand = new RelayCommand<object>((p) => { return true; }, (p) => { RevenueWindow wd = new RevenueWindow(); wd.ShowDialog(); });
            SpendingCommand = new RelayCommand<object>((p) => { return true; }, (p) => { SpendingWindow wd = new SpendingWindow(); wd.ShowDialog(); });
            SuplierCommand = new RelayCommand<object>((p) => { return true; }, (p) => { SuplierWindow wd = new SuplierWindow(); wd.ShowDialog(); });
            UserCommand = new RelayCommand<object>((p) => 
            {
                LoginWindow loginWindow = new LoginWindow();
                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.Password == "admin" || loginVM.Password=="manager")
                {
                    return true;
                }
                return false;
            }, (p) =>
            { 
                UserWindow wd = new UserWindow();
                wd.ShowDialog(); });
            
        }

    } 
}
