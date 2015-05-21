using Menu_Planner_with_Grocery_List.Common;
using System.ComponentModel;
using System.Runtime.Serialization;
using Windows.UI.Xaml.Media;
using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media.Imaging;

namespace Menu_Planner_with_Grocery_List
{
    public class PlannerData : INotifyPropertyChanged
    {

        //private static Uri _baseUri = new Uri("ms-appx:///local/Images");

        // Menu items
        private string _mainDish;
        public string MainDish
        {
            get { return _mainDish; }
            set { _mainDish = value; RaisePropertyChanged(); }
        }

        private string _sideDish;
        public string SideDish
        {
            get { return _sideDish; }
            set { _sideDish = value; RaisePropertyChanged(); }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; RaisePropertyChanged(); }
        }

        private string _sideDish2;
        public string SideDish2
        {
            get { return _sideDish2; }
            set { _sideDish2 = value; RaisePropertyChanged(); }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set { _image = value; RaisePropertyChanged(); } 
        }

        // Recipes items
        private string _instructions;
        public string Instructions
        {
            get { return _instructions; }
            set { _instructions = value; RaisePropertyChanged(); }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set { _category = value; RaisePropertyChanged(); }
        }

        private string _recipeName;
        public string RecipeName
        {
            get { return _recipeName; }
            set { _recipeName = value; RaisePropertyChanged(); }
        }

        private string _ingrdients;
        public string Ingredients
        {
            get { return _ingrdients; }
            set { _ingrdients = value; RaisePropertyChanged(); }
        }

        // Snack items
        private string _snackItem;
        public string SnackItem
        {
            get { return _snackItem; }
            set { _snackItem = value; RaisePropertyChanged(); }
        }

        private string _snackStore;
        public string SnackStore
        {
            get { return _snackStore; }
            set { _snackStore = value; RaisePropertyChanged(); }
        }

        // Grocery items
        private string _groceryItem;
        public string GroceryItem
        {
            get { return _groceryItem; }
            set { _groceryItem = value; RaisePropertyChanged(); }
        }

        private string _groceryPlace;
        public string GroceryPlace
        {
            get { return _groceryPlace; }
            set { _groceryPlace = value; RaisePropertyChanged(); }
        }

        private string _groceryPrice;
        public string GroceryPrice
        {
            get { return _groceryPrice; }
            set { _groceryPrice = value; RaisePropertyChanged(); }
        }

        //public class Images : BindableBase
        //{
        //    private ImageSource _image = null;
        //    private String _imagePath = null;
        //    public ImageSource ImageSource
        //    {
        //        get
        //        {
        //            if (this._image == null && this._imagePath != null)
        //            {
        //                this._image = new BitmapImage(new Uri(PlannerData._baseUri, this._imagePath));
        //            }
        //            return this._image;
        //        }

        //        set
        //        {
        //            this._imagePath = null;
        //            this.SetProperty(ref this._image, value);
        //        }
        //    }

        //    public void SetImage(String path)
        //    {
        //        this._image = null;
        //        this._imagePath = path;
        //        this.OnPropertyChanged("ImageSource");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}