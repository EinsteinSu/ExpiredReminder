using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Grid;
using ExpiredReminder.Common;

namespace ExpiredReminder.ViewModel.FunctionalityPages
{
    public class ExpiredPolicyEdit : SimpleEditControlBase
    {
        public ExpiredPolicyEdit(GridControl grid, TableView view) : base(grid, view)
        {
        }

        public override void Refresh()
        {
            Context.ExpiredPolicies.Load();
            Grid.ItemsSource = Context.ExpiredPolicies.Local;
        }
    }
}
