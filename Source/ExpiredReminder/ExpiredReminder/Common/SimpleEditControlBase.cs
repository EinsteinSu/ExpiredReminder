using System;
using System.Windows;
using System.Windows.Input;
using DevExpress.Xpf.Grid;
using ExpiredReminder.DataAccess;

namespace ExpiredReminder.Common
{
    public abstract class SimpleEditControlBase : IDisposable
    {
        private readonly TableView _view;
        protected readonly ExpiredReminderDataContext Context = new ExpiredReminderDataContext();
        protected readonly GridControl Grid;

        public SimpleEditControlBase(GridControl grid, TableView view)
        {
            Grid = grid;
            _view = view;
            _view.RowUpdated += View_RowUpdated;
            _view.KeyUp += View_KeyUp;
            _view.InitNewRow += InitNewRow;
            _view.ValidateRow += _view_ValidateRow;
        }


        public void Dispose()
        {
            Context?.Dispose();
        }

        private void _view_ValidateRow(object sender, GridRowValidationEventArgs e)
        {
            if (e.Row == null) return;
            if (e.RowHandle == DataControlBase.NewItemRowHandle)
            {
                ValidateRow(e);
            }
        }

        protected virtual void ValidateRow(GridRowValidationEventArgs e)
        {

        }

        protected virtual void InitNewRow(object sender, InitNewRowEventArgs e)
        {
            
        }

        private void View_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete && MessageBox.Show("是否删除?", "删除操作", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                try
                {
                    _view.DeleteRow(_view.FocusedRowHandle);
                    Context.SaveChanges();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"删除错误：{exception.Message}");
                }
        }

        public abstract void Refresh();

        private void View_RowUpdated(object sender, RowEventArgs e)
        {
            try
            {
                Context.SaveChanges();
                Grid.RefreshData();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"保存错误：{exception.Message}");
                Grid.View.CancelRowEdit();
            }
        }
    }
}