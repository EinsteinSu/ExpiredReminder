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
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Grid;
using ExpiredReminder.Common;
using ExpiredReminder.DataAccess;

namespace ExpiredReminder.View.FunctionalityPages
{
    /// <summary>
    /// Interaction logic for LawyerEdit.xaml
    /// </summary>
    public partial class LawyerEdit : ISave
    {
        public LawyerEdit()
        {
            InitializeComponent();
        }


        public void Dispose()
        {


        }

        public void Save()
        {

        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {

            var item = (EntitySimpleDataSource)this.TryFindResource("EntitySimpleDataSource");
            var data = item.DataContext;
            GridControl.EndDataUpdate();
        }

        private void Save(object sender, RowEventArgs e)
        {

        }
    }
}
