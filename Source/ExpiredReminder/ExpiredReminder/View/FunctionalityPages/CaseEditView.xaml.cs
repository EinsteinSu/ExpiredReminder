using System;
using System.Windows;
using DevExpress.Xpf.Grid;
using ExpiredReminder.ViewModel.FunctionalityPages;

namespace ExpiredReminder.View.FunctionalityPages
{
    /// <summary>
    ///     Interaction logic for CaseEditView.xaml
    /// </summary>
    public partial class CaseEditView : IDisposable
    {
        private readonly CaseEdit _edit;

        public CaseEditView()
        {
            InitializeComponent();
            _edit = new CaseEdit(grid, grid.View as TableView);
        }

        public void Dispose()
        {
            _edit?.Dispose();
        }

        private void CaseEditView_OnLoaded(object sender, RoutedEventArgs e)
        {
            lawyer.ItemsSource = _edit.Lawyers;
            _edit.Refresh();
        }
    }
}