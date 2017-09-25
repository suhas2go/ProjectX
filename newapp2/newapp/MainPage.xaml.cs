﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace newapp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Person Login_User = new Person();

        public MainPage()
        {
            this.InitializeComponent();

            Login_User.name = GlobalVar.Globalname;
            Login_User.contactno = GlobalVar.Globalcontact;
            Login_User.ftb = GlobalVar.Globalftb;
            Login_User.mv = GlobalVar.Globalmv;
            Login_User.disc = GlobalVar.Globaldisc;
            Login_User.csgo = GlobalVar.Globalcsgo;
            Login_User.g = GlobalVar.Globalg;
            Login_User.age = GlobalVar.Globalage;

            MyFrame.Navigate(typeof(Profile),Login_User);

            TitleTextBlock.Text = "Profile";
            Profile.IsSelected = true;
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Profile.IsSelected)
            {
                MyFrame.Navigate(typeof(Profile),Login_User);
                TitleTextBlock.Text = "Profile";
            }
            else if (EventsHouse.IsSelected)
            {
                MyFrame.Navigate(typeof(EventsHouse));
                TitleTextBlock.Text = "Events House";
            }
            else if (Alerts.IsSelected)
            {
                MyFrame.Navigate(typeof(Alerts));
                TitleTextBlock.Text = "Notifications";
            }
            else if (Signout.IsSelected)
            {
                this.Frame.Navigate(typeof(Login));
            }
            else if (CreateEvent.IsSelected)
            {
                MyFrame.Navigate(typeof(Create));
                TitleTextBlock.Text = "Create Event";
            }


        }

        private void MyFrame_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
