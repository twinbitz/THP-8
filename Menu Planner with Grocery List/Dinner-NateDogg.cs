using Menu_Planner_with_Grocery_List.Common;
using System;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Menu_Planner_with_Grocery_List
{
    public class Dinner : BindableBase
    {
        public string MainDish { get; set; }
        public string SideDish { get; set; }
        public string Content { get; set; }
        //public string ImagePath { get; set; }


        private ImageSource image = null;
        public String imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (this.image == null && this.imagePath != null)
                {
                    this.image = new BitmapImage(new Uri(this.imagePath));
                }
                return this.image;
            }
            set
            {
                this.imagePath = null;
                this.SetProperty(ref this.image, value);
            }
        }

        public void SetImage(String path)
        {
            this.image = null;
            this.imagePath = path;
            this.OnPropertyChanged("Image");
        }
    }

    //public class DinnerDataCommon : Menu_Planner_with_Grocery_List.Common.BindableBase
    //{
    //    private static Uri _baseUri = new Uri("ms-appx:///");

    //    public DinnerDataCommon(String mainDish, String sideDish, String content, String imagePath)
    //    {
    //        this._mainDish = mainDish;
    //        this._sideDish = sideDish;
    //        this._content = content;
    //        this._imagePath = imagePath;
    //    }

    //    private string _mainDish = string.Empty;
    //    public string MainDish
    //    {
    //        get { return this._mainDish; }
    //        set { this.SetProperty(ref this._mainDish, value); }
    //    }

    //    private string _sideDish = string.Empty;
    //    public string SideDish
    //    {
    //        get { return this._sideDish; }
    //        set { this.SetProperty(ref this._sideDish, value); }
    //    }

    //    private string _content = string.Empty;
    //    public string Content
    //    {
    //        get { return this._content; }
    //        set { this.SetProperty(ref this._content, value); }
    //    }

    //    private ImageSource _image = null;
    //    private String _imagePath = null;
    //    public ImageSource Image
    //    {
    //        get
    //        {
    //            if (this._image == null && this._imagePath != null)
    //            {
    //                this._image = new BitmapImage(new Uri(DinnerDataCommon._baseUri, this._imagePath));
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
    //        this.OnPropertyChanged("Image");
    //    }
    //}


    //public class DinnerItems : DinnerDataCommon
    //{
    //    public DinnerItems(String mainDish, String sideDish, String content, String imagePath)
    //        : base(mainDish, sideDish, content, imagePath)
    //    {
    //    }

    //    private ObservableCollection<DinnerItems> _items = new ObservableCollection<DinnerItems>();
    //    public ObservableCollection<DinnerItems> Items
    //    {
    //        get { return this._items; }
    //    }
    //}
}
