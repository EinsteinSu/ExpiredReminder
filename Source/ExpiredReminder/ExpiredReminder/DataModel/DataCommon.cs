using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;

namespace ExpiredReminder.DataModel
{
    /// <summary>
    ///     Base class for <see cref="DataItem" /> and <see cref="SampleDataGroup" /> that
    ///     defines properties common to both.
    /// </summary>
    public abstract class DataCommon : ViewModelBase
    {
        private static readonly Uri BaseUri = new Uri("pack://application:,,,");
        private string _description;
        private ImageSource _image;
        private string _imagePath;
        private string _subtitle;
        private string _title;

        public DataCommon(string title, string subtitle, string imagePath, string description)
        {
            UniqueId = GetUniqueId();
            _title = title;
            _subtitle = subtitle;
            _description = description;
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
                if (_image == null && _imagePath != null) _image = GetImage(_imagePath);
                return _image;
            }
            set
            {
                _imagePath = null;
                SetProperty(ref _image, value, "Image");
            }
        }

        private static BitmapImage GetImage(string path)
        {
#if SILVERLIGHT
            return new BitmapImage(new Uri("../"  + path, UriKind.RelativeOrAbsolute));
#else
            return new BitmapImage(new Uri(BaseUri, path));
#endif
        }

        private static string GetUniqueId()
        {
            return Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return Title;
        }
    }
}