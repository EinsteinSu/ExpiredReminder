using System.Windows;

namespace ExpiredReminder.DataModel
{
    /// <summary>
    ///     Generic item data model.
    /// </summary>
    public class DataItem : DataCommon
    {
        private FrameworkElement _content;
        private string _groupHeader;
        private bool _isFlowBreak;

        public DataItem(string title, string subtitle, string imagePath, string description, FrameworkElement content, string color = "")
            : this(title, subtitle, imagePath, description, content, false, string.Empty, color)
        {
        }

        public DataItem(string title, string subtitle, string imagePath, string description, FrameworkElement content,
            bool isFlowBreak, string groupHeader, string color = "")
            : base(title, subtitle, imagePath, description, color)
        {
            _content = content;
            IsFlowBreak = isFlowBreak;
            GroupHeader = groupHeader;
        }

        public FrameworkElement Content
        {
            get => _content;
            set => SetProperty(ref _content, value, "Content");
        }

        public bool IsFlowBreak
        {
            get => _isFlowBreak;
            set => SetProperty(ref _isFlowBreak, value, "IsFlowBreak");
        }

        public string GroupHeader
        {
            get => _groupHeader;
            set => SetProperty(ref _groupHeader, value, "GroupHeader");
        }
    }
}