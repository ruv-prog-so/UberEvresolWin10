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
using UberEversol.Models;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UberEversol
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// For list view
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new UberEversolContext())
            {
                session_list.ItemsSource = db.Sessions.ToList();
            }
        }

        /// List button Add
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new UberEversolContext())
            {
                var s = new Session(txtTitle.Text, txtDesc.Text);
                db.Sessions.Add(s);
                db.SaveChanges();

                // Update the session list
                session_list.ItemsSource = db.Sessions.ToList();
            }
        }

        /// List button Remove
        private void remove_click(object sender, RoutedEventArgs e)
        {
            ListViewItem lvi = (ListViewItem)session_list.SelectedItem;
            using (var db = new UberEversolContext())
            {
                var s = new Session(txtTitle.Text, txtDesc.Text);
                db.Sessions.Remove(lvi.item);
                db.SaveChanges();

                // Update the session list
                session_list.ItemsSource = db.Sessions.ToList();
            }
        }

        // Toggle Side Pane
        private void OnMenuButtonClicked(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }

        // Go to Home Page
        private void OnHomeButtonChecked(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }

        // Open Search Page
        private void OnSearchButtonChecked(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }

        // Open Settings Page
        private void OnSettingsButtonChecked(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }

        // Open About Page
        private void OnAboutButtonChecked(object sender, RoutedEventArgs e)
        {
            Split.IsPaneOpen = !Split.IsPaneOpen;
        }


        private void Sessions_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Sessions));
        }

        private async void session_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRemove.IsEnabled = true;
            MessageDialog dialog;
            ListViewItem itemId = ((sender as ListView).SelectedItem as ListViewItem);
            if (itemId != null)
            {
                dialog = new MessageDialog(itemId.ToString());
            }
            else
            {
                dialog = new MessageDialog("Item Selected");
            }

            await dialog.ShowAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
