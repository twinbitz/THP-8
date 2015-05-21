using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Menu_Planner_with_Grocery_List
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : Menu_Planner_with_Grocery_List.Common.LayoutAwarePage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void ListViewItem_Tapped_grcylst(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Grocery));
        }

        private void ListViewItem_Tapped_dnr(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Dinner));
        }

        private void ListViewItem_Tapped_lnch(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lunch));
        }

        private void ListViewItem_Tapped_brkfst(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Breakfast));
        }

        private void ListViewItem_Tapped_recipes(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecipesPage));
        }

        private void ListViewItem_Tapped_snks(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Snack));
        }

        private void GVTappedgrcylst(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Grocery));
        }

        private void GVTappedbrkfst(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Breakfast));
        }

        private void GVTappedlnch(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Lunch));
        }

        private void GVTappeddnr(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Dinner));
        }

        private void GVTappedrecipes(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(RecipesPage));
        }

        private void GVTappedsnks(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Snack));
        }

        // Footer Click
        async void Footer_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri(((HyperlinkButton)sender).Tag.ToString()));
        }

        private void itemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void PrivacyClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
