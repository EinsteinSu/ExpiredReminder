using System.Collections.Generic;
using DevExpress.Mvvm;
using DevExpress.Xpf.WindowsUI.Navigation;
using ExpiredReminder.DataModel;

namespace ExpiredReminder.ViewModel
{
    //A View Model for a GroupedItemsPage
    public class GroupedItemsViewModel : ViewModelBase, INavigationAware
    {
        private IEnumerable<DataItem> items;

        public IEnumerable<DataItem> Items
        {
            get => items;
            private set => SetProperty(ref items, value, "Items");
        }

        public void LoadState(object navigationParameter)
        {
            Items = UIDataSource.GetDataItems();
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
        }

        #endregion
    }
}