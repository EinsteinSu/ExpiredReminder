﻿using System.Collections.ObjectModel;
using System.Linq;
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
            var content = new LawyerEdit();
            var ITEM_DESCRIPTION =
                "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.";

            _items.Add(new DataItem(
                "Item Title: 1",
                "Item Subtitle: 1",
                "Assets/LightGray.png",
                ITEM_DESCRIPTION,
                content, true, "Group 1"));
            _items.Add(new DataItem(
                "Item Title: 2",
                "Item Subtitle: 2",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 3",
                "Item Subtitle: 3",
                "Assets/MediumGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 4",
                "Item Subtitle: 4",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 5",
                "Item Subtitle: 5",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 6",
                "Item Subtitle: 6",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));


            _items.Add(new DataItem(
                "Item Title: 1",
                "Item Subtitle: 1",
                "Assets/MediumGray.png",
                ITEM_DESCRIPTION,
                content, true, "Group 2"));
            _items.Add(new DataItem(
                "Item Title: 2",
                "Item Subtitle: 2",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 3",
                "Item Subtitle: 3",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));

            _items.Add(new DataItem(
                "Item Title: 1",
                "Item Subtitle: 1",
                "Assets/MediumGray.png",
                ITEM_DESCRIPTION,
                content, true, "Group 3"));
            _items.Add(new DataItem(
                "Item Title: 2",
                "Item Subtitle: 2",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 3",
                "Item Subtitle: 3",
                "Assets/LightGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 4",
                "Item Subtitle: 4",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 5",
                "Item Subtitle: 5",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 6",
                "Item Subtitle: 6",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 7",
                "Item Subtitle: 7",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 8",
                "Item Subtitle: 8",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));

            _items.Add(new DataItem(
                "Item Title: 1",
                "Item Subtitle: 1",
                "Assets/MediumGray.png",
                ITEM_DESCRIPTION,
                content, true, "Group 4"));
            _items.Add(new DataItem(
                "Item Title: 2",
                "Item Subtitle: 2",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 3",
                "Item Subtitle: 3",
                "Assets/LightGray.png",
                ITEM_DESCRIPTION,
                content));
            _items.Add(new DataItem(
                "Item Title: 4",
                "Item Subtitle: 4",
                "Assets/DarkGray.png",
                ITEM_DESCRIPTION,
                content));
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