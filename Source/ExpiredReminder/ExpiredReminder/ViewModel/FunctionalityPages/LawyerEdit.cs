using System.Data.Entity;
using DevExpress.Xpf.Grid;
using ExpiredReminder.Common;

namespace ExpiredReminder.ViewModel.FunctionalityPages
{
    public class LawyerEdit : SimpleEditControlBase
    {
        public LawyerEdit(GridControl grid, TableView view) : base(grid, view)
        {
        }

        public override void Refresh()
        {
            Context.Lawyers.Load();
            Grid.ItemsSource = Context.Lawyers.Local;
        }
    }
}