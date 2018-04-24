using System.Collections.Generic;
using System.Windows.Controls;
using ExpiredReminder.DataAccess;

namespace ExpiredReminder.View.FunctionalityPages
{
    /// <summary>
    ///     Interaction logic for ExpiredCaseView.xaml
    /// </summary>
    public partial class ExpiredCaseView
    {
        public ExpiredCaseView()
        {
            InitializeComponent();
        }

        public ExpiredCaseView(IList<Case> cases)
        {
            InitializeComponent();
            grid.ItemsSource = cases;
        }
    }
}