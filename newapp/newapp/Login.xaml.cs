﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace newapp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
   
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }
        bool GotoHome = true;
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignUp));
        }

        private void login_event(object sender,KeyRoutedEventArgs e)
        {
            if(e.Key==Windows.System.VirtualKey.Enter)
            LoginEntered_Click(sender, e);
        }
         private async void LoginEntered_Click(object sender, RoutedEventArgs e)
        {
            
            List<Person> loggedPerson =await App.MobileService.GetTable<Person>().Where(x => x.name == NameInput1.Text & x.pwd == PasswordInput1.Password).ToListAsync();
            

            if (loggedPerson.Count==0)
            { GotoHome = false;
              var dialog = new MessageDialog("Incorrect username or password");
              await dialog.ShowAsync();
            }
            
            if (GotoHome == true)
            {
                GlobalVar.Globalname = loggedPerson[0].name;
                GlobalVar.Globalcontact = loggedPerson[0].contactno;
                GlobalVar.Globalftb = loggedPerson[0].ftb;
                GlobalVar.Globalmv = loggedPerson[0].mv;
                GlobalVar.Globaldisc= loggedPerson[0].disc;
                GlobalVar.Globalcsgo = loggedPerson[0].csgo;
                GlobalVar.Globalg = loggedPerson[0].g;
                GlobalVar.Globalage = loggedPerson[0].age;
                this.Frame.Navigate(typeof(MainPage));
            }
            
        }
    }
}
