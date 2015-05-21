using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Menu_Planner_with_Grocery_List
{
    [KnownType(typeof(Menu_Planner_with_Grocery_List.Lunchs))]
    [DataContractAttribute]

    public class Lunchs
    {
        [DataMember()]
        public String MainDish { get; set; }
        [DataMember()]
        public String SideDish { get; set; }
        [DataMember()]
        public String Content { get; set; }
        [DataMember()]
        public String Image { get; set; }
    }

    public class LunchMenu : Menu_Planner_with_Grocery_List.Common.BindableBase
    {
        public String MainDish { get; set; }
        public String SideDish { get; set; }
        public String Content { get; set; }
        //public String Image { get; set; }

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


}
