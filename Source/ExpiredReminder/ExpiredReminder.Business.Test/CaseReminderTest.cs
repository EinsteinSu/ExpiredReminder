using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ExpiredReminder.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpiredReminder.Business.Test
{
    [TestClass]
    public class CaseReminderTest
    {
        [TestInitialize]
        public virtual void Initialize()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Databases"));
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ExpiredReminderDataContext>());
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var context = new ExpiredReminderDataContext())
            {
                context.Database.ExecuteSqlCommand("Delete from ExpiredPolicies");
            }
        }

        private readonly List<Case> _cases = new List<Case>
        {
            new Case {FirstTime = DateTime.Now.AddDays(-90)},
            new Case {FirstTime = DateTime.Now.AddDays(-92)},
            new Case {FirstTime = DateTime.Now.AddDays(-180)},
            new Case {FirstTime = DateTime.Now.AddDays(-186)},
            new Case {FirstTime = DateTime.Now.AddDays(-270)},
            new Case {FirstTime = DateTime.Now.AddDays(-271)},
            new Case {FirstTime = DateTime.Now.AddDays(-273)},
            new Case {FirstTime = DateTime.Now.AddDays(-366)},
            new Case {FirstTime = DateTime.Now.AddDays(-376)},
            new Case {FirstTime = DateTime.Now.AddDays(-30)},
            new Case {FirstTime = DateTime.Now.AddDays(-10)}
        };

        [TestMethod]

        public void RemindCasesTest()
        {
            AssertReminder(90, 180, 2);
            AssertReminder(180, 270, 2);
            AssertReminder(270, 360, 3);
            AssertReminder(360, 999, 2);

        }

        private void AssertReminder(int minDay, int maxDay, int assertCount)
        {
            var reminder = new CaseReminder(_cases, minDay, maxDay, DateTime.Now);
            Assert.AreEqual(assertCount, reminder.RemindCases.Count);
        }

        [TestMethod]
        public void CaseReminderCollectionTest()
        {
            using (var context = new ExpiredReminderDataContext())
            {
                context.ExpiredPolicies.Add(new ExpiredPolicy { MinDay = 90, MaxDay = 180, Name = "First remind days." });
                context.ExpiredPolicies.Add(
                    new ExpiredPolicy { MinDay = 180, MaxDay = 270, Name = "Second remind days." });
                context.ExpiredPolicies.Add(
                    new ExpiredPolicy { MinDay = 270, MaxDay = 360, Name = "Second remind days." });
                context.ExpiredPolicies.Add(
                    new ExpiredPolicy { MinDay = 360, MaxDay = 999, Name = "Second remind days." });
                context.SaveChanges();
            }
            var collection = new CaseReminderCollection(_cases, DateTime.Now);
            collection.Calculate();
            AssertReminderCollection(collection, 90, 2);
            AssertReminderCollection(collection, 180, 2);
            AssertReminderCollection(collection, 270, 3);
            AssertReminderCollection(collection, 360, 2);
        }

        private void AssertReminderCollection(CaseReminderCollection collection, int minDay, int assert)
        {
            var first = collection.ExpiredCaseses.FirstOrDefault(w => w.Policy.MinDay == minDay);
            Assert.IsNotNull(first);
            Assert.AreEqual(assert, first.Cases.Count);
        }
    }
}
