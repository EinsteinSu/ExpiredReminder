using DevExpress.Mvvm;
using DevExpress.Xpf.WindowsUI.Navigation;
using ExpiredReminder.Common;
using ExpiredReminder.DataModel;

namespace ExpiredReminder.ViewModel
{
    //A View Model for an ItemDetailPage
    public class ItemDetailViewModel : ViewModelBase, INavigationAware
    {
        private DataItem _selectedItem;

        public DataItem SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value, "SelectedItem");
        }

        private void LoadState(object navigationParameter)
        {
            var item = UIDataSource.GetItem((string)navigationParameter);
            SelectedItem = item;
        }

        private void SaveState(object navigationParameter)
        {
            var item = UIDataSource.GetItem((string)navigationParameter);
            if (item is ISave save)
            {
                save.Save();
            }
        }

        #region INavigationAware Members

        public void NavigatedFrom(NavigationEventArgs e)
        {

        }

        public void NavigatedTo(NavigationEventArgs e)
        {
            LoadState(e.Parameter);
        }

        public void NavigatingFrom(NavigatingEventArgs e)
        {
            SaveState(e.Parameter);
        }

        #endregion
    }
}