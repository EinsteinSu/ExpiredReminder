using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using ExpiredReminder.DataAccess;
using ExpiredReminder.ViewModel.FunctionalityPages;

namespace ExpiredReminder.View.FunctionalityPages
{
    /// <summary>
    ///     Interaction logic for ExpiredPolicyEditView.xaml
    /// </summary>
    public partial class ExpiredPolicyEditView : IDisposable
    {
        private readonly ExpiredPolicyEdit _edit;

        public ExpiredPolicyEditView()
        {
            InitializeComponent();
            _edit = new ExpiredPolicyEdit(grid, grid.View as TableView);
        }

        private void ExpiredPolicyEditView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _edit.Refresh();
            color.Items.Clear();
            var items = Enum.GetValues(typeof(ExpiredColor));
            foreach (var item in items)
            {
                color.Items.Add(item);
            }
        }

        public void Dispose()
        {
            _edit?.Dispose();
        }
    }
}