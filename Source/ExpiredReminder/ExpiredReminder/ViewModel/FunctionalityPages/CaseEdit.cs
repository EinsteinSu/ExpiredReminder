using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DevExpress.Xpf.Grid;
using ExpiredReminder.Common;
using ExpiredReminder.DataAccess;

namespace ExpiredReminder.ViewModel.FunctionalityPages
{
    public class CaseEdit : SimpleEditControlBase
    {
        public CaseEdit(GridControl grid, TableView view) : base(grid, view)
        {

        }

        protected override void InitNewRow(object sender, InitNewRowEventArgs e)
        {
            Grid.SetCellValue(e.RowHandle, "FirstTime", DateTime.Now);
            var lawyer = Context.Lawyers.FirstOrDefault();
            if (lawyer != null)
            {
                Grid.SetCellValue(e.RowHandle, "LawyerId", lawyer.Id);
            }
        }

        protected override void ValidateRow(GridRowValidationEventArgs e)
        {
            e.IsValid = ((Case)e.Row).LawyerId > 0;
            e.IsValid = ((Case)e.Row).FirstTime > DateTime.MinValue;
            e.Handled = true;
        }

        public override void Refresh()
        {
            Context.Cases.Load();
            Grid.ItemsSource = Context.Cases.Local;
        }

        public List<Lawyer> Lawyers => Context.Lawyers.ToList();
    }
}