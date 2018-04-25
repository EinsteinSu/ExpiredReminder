using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using ExpiredReminder.ViewModel.FunctionalityPages;
using MessageBox = System.Windows.MessageBox;

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

        private void ButtonEditSettings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Clicked me!");
        }

        private void ButtonEditSettings_OnDefaultButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is ButtonEdit button)
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        button.Text = dialog.SelectedPath;
                    }
                }
            }
        }

        private void HyperlinkEdit_OnRequestNavigation(object sender, HyperlinkEditRequestNavigationEventArgs e)
        {
            if (sender is HyperlinkEdit link)
            {
                try
                {
                    Process.Start(link.Text);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Can not open the folder{link.Text}, {exception.Message}");
                }
            }
        }
    }
}