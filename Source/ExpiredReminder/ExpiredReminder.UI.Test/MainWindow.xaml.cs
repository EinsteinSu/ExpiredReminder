using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using ExpiredReminder.DataAccess;

namespace ExpiredReminder.UI.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExpiredReminderDataContext context = new ExpiredReminderDataContext();
        public MainWindow()
        {
            InitializeComponent();
            context.Lawyers.Load();
            grid.ItemsSource = context.Lawyers.Local;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
         
        }

        private void GridViewBase_OnRowUpdated(object sender, RowEventArgs e)
        {
            context.SaveChanges();
            grid.RefreshData();
        }
    }
}
