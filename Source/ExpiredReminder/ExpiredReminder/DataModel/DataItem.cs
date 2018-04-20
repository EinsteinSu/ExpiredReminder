using System.Windows;

namespace ExpiredReminder.DataModel
{
    /// <summary>
    ///     Generic item data model.
    /// </summary>
    public class DataItem : DataCommon
    {
        private FrameworkElement _content;
        private string _GroupHeader;
        private bool _IsFlowBreak;

        public DataItem(string title, string subtitle, string imagePath, string description, FrameworkElement content)
            : this(title, subtitle, imagePath, description, content, false, string.Empty)
        {
        }

        public DataItem(string title, string subtitle, string imagePath, string description, FrameworkElement content,
            bool isFlowBreak, string groupHeader)
            : base(title, subtitle, imagePath, description)
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
            get => _IsFlowBreak;
            set => SetProperty(ref _IsFlowBreak, value, "IsFlowBreak");
        }

        public string GroupHeader
        {
            get => _GroupHeader;
            set => SetProperty(ref _GroupHeader, value, "GroupHeader");
        }
    }
}