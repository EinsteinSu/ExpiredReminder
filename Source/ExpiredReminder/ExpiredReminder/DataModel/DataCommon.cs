using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using ExpiredReminder.DataAccess;

namespace ExpiredReminder.DataModel
{
    /// <summary>
    ///     Base class for <see cref="DataItem" /> and <see cref="SampleDataGroup" /> that
    ///     defines properties common to both.
    /// </summary>
    public abstract class DataCommon : ViewModelBase
    {
        private static readonly Uri BaseUri = new Uri("pack://application:,,,");
        private readonly string _color;
        private string _description;
        private ImageSource _image;
        private string _imagePath;
        private string _subtitle;
        private string _title;

        public DataCommon(string title, string subtitle, string imagePath, string description, string color = "")
        {
            UniqueId = title;
            _title = title;
            _subtitle = subtitle;
            _description = description;
            _color = color;
            _imagePath = imagePath;
        }

        public string UniqueId { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value, "Title");
        }

        public string Subtitle
        {
            get => _subtitle;
            set => SetProperty(ref _subtitle, value, "Subtitle");
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value, "Description");
        }

        public ImageSource Image
        {
            get
            {
                if (_image == null)
                {
                    if (!string.IsNullOrEmpty(_color))
                    {
                        _image = GetImage(_imagePath, ConvertToExpiredColor(_color).ConvertToColor());
                    }
                    else
                    {
                        _image = GetImage(_imagePath, Colors.Transparent);
                    }
                }

                return _image;
            }
            set
            {
                _imagePath = null;
                SetProperty(ref _image, value, "Image");
            }
        }

        private ExpiredColor ConvertToExpiredColor(string color)
        {
            var expiredColor = (ExpiredColor)Enum.Parse(typeof(ExpiredColor), color);
            return expiredColor;
        }

        private static BitmapSource CreateBitmapWithColor(Color color)
        {
            var width = 128;
            var height = width;
            var stride = width / 8;
            var pixels = new byte[height * stride];

            // Try creating a new image with a custom palette.
            var colors = new List<Color>();
            colors.Add(color);
            //colors.Add(Colors.Blue);
            //colors.Add(Colors.GreenYellow);
            var myPalette = new BitmapPalette(colors);

            // Creates a new empty image with the pre-defined palette
            var image = BitmapSource.Create(
                width, height,
                96, 96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);
            return image;
        }

        private static BitmapSource GetImage(string path, Color color)
        {
#if SILVERLIGHT
            return new BitmapImage(new Uri("../"  + path, UriKind.RelativeOrAbsolute));
#else
            if (!string.IsNullOrEmpty(path))
            {
                return new BitmapImage(new Uri(BaseUri, path));
            }
            else
            {
                return CreateBitmapWithColor(color);
            }

#endif
        }

        private string GetUniqueId()
        {
            return _title;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}