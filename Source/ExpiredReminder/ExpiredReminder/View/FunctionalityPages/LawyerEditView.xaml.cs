using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using ExpiredReminder.ViewModel.FunctionalityPages;

namespace ExpiredReminder.View.FunctionalityPages
{
    /// <summary>
    /// Interaction logic for LawyerEditView.xaml
    /// </summary>
    public partial class LawyerEditView : IDisposable
    {
        private readonly LawyerEdit _edit;
        public LawyerEditView()
        {
            InitializeComponent();
            _edit = new LawyerEdit(grid, grid.View as TableView);
        }

        public void Dispose()
        {
            _edit?.Dispose();
        }

        private void LawyerEditView_OnLoaded(object sender, RoutedEventArgs e)
        {
            _edit.Refresh();
        }
    }
}
