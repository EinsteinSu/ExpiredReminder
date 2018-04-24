using System;
using System.Collections.ObjectModel;
using System.Linq;
using ExpiredReminder.Business;
using ExpiredReminder.DataAccess;
using ExpiredReminder.View.FunctionalityPages;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace ExpiredReminder.DataModel
{
    /// <summary>
    ///     Creates a collection of groups and items with hard-coded content.
    ///     SampleDataSource initializes with placeholder data rather than live production
    ///     data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public sealed class UIDataSource
    {
        private readonly ObservableCollection<DataItem> _items;

        public UIDataSource()
        {
            _items = new ObservableCollection<DataItem>();

            _items = GetDataItems();
        }

        public static ObservableCollection<DataItem> GetDataItems()
        {
            var items = new ObservableCollection<DataItem>();
            //todo customize the icons
            items.Add(new DataItem(
                "案件录入",
                "录入案件信息，以便统计案件的金额和提醒案件过期时间",
                "Assets/LightGray.png",
                "录入案件信息，以便统计案件的金额和提醒案件过期时间",
                new CaseEditView(), true, "信息录入"));
            items.Add(new DataItem(
                "律师管理",
                "律师信息录入",
                "Assets/DarkGray.png",
                "录入律师信息，以便统计律师分成等",
                new LawyerEditView()));
            items.Add(new DataItem(
                "过期策略",
                "设置过期提醒策略",
                "Assets/MediumGray.png",
                "设置过期提醒策略，以此来进行提醒。（例如： 过期时间为大于90天， 小于180 天， 名称为： 三个月提醒）",
                new ExpiredPolicyEditView()));

            int i = 0;
            using (var context = new ExpiredReminderDataContext())
            {
                CaseReminderCollection collection = new CaseReminderCollection(context.Cases.ToList(), DateTime.Now);
                collection.Calculate();
                foreach (var expiredCase in collection.ExpiredCaseses)
                {
                    var item = new DataItem(
                        expiredCase.Policy.Name,
                        $"过期时间{expiredCase.Policy.MinDay}, 案件数量{expiredCase.Cases.Count}",
                        "",
                        $"时间区间 大于等于{expiredCase.Policy.MinDay} 小于 {expiredCase.Policy.MaxDay}",
                        new ExpiredCaseView(expiredCase.Cases), expiredCase.Policy.Color.ToString());
                    if (i == 0)
                    {
                        item.IsFlowBreak = true;
                        item.GroupHeader = "过期案件";

                    }
                    items.Add(item);
                    i++;
                }
            }

            return items;
        }

        public static UIDataSource Instance { get; } = new UIDataSource();

        public ObservableCollection<DataItem> Items => Instance._items;

        public static DataItem GetItem(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = Instance.Items.Where(item => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }
    }
}