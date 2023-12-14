using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TechElevator.Exercises.LogicalBranching.Tests
{
    [TestClass]
	public sealed class Exercise07_StoreHoursTests : TestBase
    {
        [TestMethod]
        public void StoreShouldBeOpen1_BasedOnHour()
        {
            // Arrange
            StoreHours store = new StoreHours();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsFalse(store.IsStoreOpen(0), "The store should be closed at 12 AM / Midnight (hour 0)");
            Assert.IsFalse(store.IsStoreOpen(1), "The store should be closed at 1 AM (hour 1)");
            Assert.IsFalse(store.IsStoreOpen(7), "The store should be closed at 7 AM (hour 7)");
            Assert.IsTrue(store.IsStoreOpen(8), "The store should be open at 8 AM (hour 8)");
            Assert.IsTrue(store.IsStoreOpen(10), "The store should be open at 10 AM (hour 10)");
            Assert.IsTrue(store.IsStoreOpen(16), "The store should be open at 4 PM (hour 16)");
            Assert.IsFalse(store.IsStoreOpen(17), "The store should be closed at 5 PM (hour 17) since the closing time is exact");
            Assert.IsFalse(store.IsStoreOpen(19), "The store should be closed at 7 PM (hour 19)");
            Assert.IsFalse(store.IsStoreOpen(23), "The store should be closed at 11 PM (hour 23)");
        }        
        
        [TestMethod]
        public void StoreShouldBeOpen2_BasedOnHour()
        {
            // Arrange
            StoreHours store = new StoreHours();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsFalse(store.IsStoreOpen(7, 'M'), "The store should be closed at 7 AM on Monday");
            Assert.IsFalse(store.IsStoreOpen(7, 'W'), "The store should be closed at 7 AM on Wednesday");
            Assert.IsFalse(store.IsStoreOpen(7, 'F'), "The store should be closed at 7 AM on Friday");
            Assert.IsFalse(store.IsStoreOpen(7, 'S'), "The store should be closed at 7 AM on Saturday");
            Assert.IsTrue(store.IsStoreOpen(8, 'M'), "The store should be open at 8 AM on Monday");
            Assert.IsTrue(store.IsStoreOpen(8, 'W'), "The store should be open at 8 AM on Wednesday");
            Assert.IsTrue(store.IsStoreOpen(8, 'F'), "The store should be open at 8 AM on Friday");
            Assert.IsFalse(store.IsStoreOpen(8, 'S'), "The store should be closed at 8 AM on Saturday");
            Assert.IsTrue(store.IsStoreOpen(13, 'M'), "The store should be open at 1 PM on Monday");
            Assert.IsTrue(store.IsStoreOpen(13, 'W'), "The store should be open at 1 PM on Wednesday");
            Assert.IsTrue(store.IsStoreOpen(13, 'F'), "The store should be open at 1 PM on Friday");
            Assert.IsFalse(store.IsStoreOpen(13, 'S'), "The store should be closed at 1 PM on Saturday");
            Assert.IsTrue(store.IsStoreOpen(16, 'M'), "The store should be open at 4 PM on Monday");
            Assert.IsTrue(store.IsStoreOpen(16, 'W'), "The store should be open at 4 PM on Wednesday");
            Assert.IsTrue(store.IsStoreOpen(16, 'F'), "The store should be open at 4 PM on Friday");
            Assert.IsFalse(store.IsStoreOpen(16, 'S'), "The store should be closed at 4 PM on Saturday");
            Assert.IsFalse(store.IsStoreOpen(17, 'M'), "The store should be closed at 5 PM on Monday");
            Assert.IsFalse(store.IsStoreOpen(17, 'W'), "The store should be closed at 5 PM on Wednesday");
            Assert.IsFalse(store.IsStoreOpen(17, 'F'), "The store should be closed at 5 PM on Friday");
            Assert.IsFalse(store.IsStoreOpen(17, 'S'), "The store should be closed at 5 PM on Saturday");
            Assert.IsFalse(store.IsStoreOpen(19, 'M'), "The store should be closed at 7 PM on Monday");
            Assert.IsFalse(store.IsStoreOpen(19, 'W'), "The store should be closed at 7 PM on Wednesday");
            Assert.IsFalse(store.IsStoreOpen(19, 'F'), "The store should be closed at 7 PM on Friday");
            Assert.IsFalse(store.IsStoreOpen(19, 'S'), "The store should be closed at 7 PM on Saturday");
        }

        [TestMethod]
        public void StoreShouldBeOpen3_SummerHours()
        {
            // Arrange
            StoreHours store = new StoreHours();

            // Act / Assert - Note: Normally each of these would be a separate test
            // We include multiple assertions here for ease of student experience / to reduce confusion
            Assert.IsFalse(store.IsStoreOpen(7, 'M', false), "The store should be closed at 7 AM on Monday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(7, 'W', false), "The store should be closed at 7 AM on Wednesday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(7, 'F', false), "The store should be closed at 7 AM on Friday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(7, 'S', false), "The store should be closed at 7 AM on Saturday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(8, 'M', false), "The store should be open at 8 AM on Monday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(8, 'W', false), "The store should be open at 8 AM on Wednesday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(8, 'F', false), "The store should be open at 8 AM on Friday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(8, 'M', true), "The store should be open at 8 AM on Monday in summer months");
            Assert.IsTrue(store.IsStoreOpen(8, 'W', true), "The store should be open at 8 AM on Wednesday in summer months");
            Assert.IsTrue(store.IsStoreOpen(8, 'F', true), "The store should be open at 8 AM on Friday in summer months");
            Assert.IsFalse(store.IsStoreOpen(8, 'S', false), "The store should be closed at 8 AM on Saturday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(8, 'S', true), "The store should be closed at 8 AM on Saturday in summer months");
            Assert.IsFalse(store.IsStoreOpen(9, 'S', false), "The store should be closed at 9 AM on Saturday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(9, 'S', true), "The store should be open at 9 AM on Saturday in summer months due to summer rules for Saturdays");
            Assert.IsTrue(store.IsStoreOpen(13, 'M', false), "The store should be open at 1 PM on Monday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(13, 'W', false), "The store should be open at 1 PM on Wednesday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(13, 'F', false), "The store should be open at 1 PM on Friday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(13, 'S', false), "The store should be closed at 1 PM on Saturday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(15, 'S', false), "The store should be closed at 3 PM on Saturday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(15, 'S', true), "The store should be closed at 3 PM on Saturday in summer months");
            Assert.IsTrue(store.IsStoreOpen(16, 'M', false), "The store should be open at 4 PM on Monday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(16, 'W', false), "The store should be open at 4 PM on Wednesday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(16, 'F', false), "The store should be open at 4 PM on Friday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(16, 'S', false), "The store should be closed at 4 PM on Saturday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(16, 'S', true), "The store should be closed at 4 PM on Saturday in summer months");
            Assert.IsFalse(store.IsStoreOpen(17, 'M', false), "The store should be closed at 5 PM on Monday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(17, 'M', true), "The store should be closed at 5 PM on Monday in summer months");
            Assert.IsFalse(store.IsStoreOpen(17, 'W', false), "The store should be closed at 5 PM on Wednesday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(17, 'W', true), "The store should be open at 5 PM on Wednesday in summer months due to Wednesday-specific summer rules");
            Assert.IsFalse(store.IsStoreOpen(17, 'F', false), "The store should be closed at 5 PM on Friday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(17, 'F', true), "The store should be closed at 5 PM on Friday in summer months");
            Assert.IsFalse(store.IsStoreOpen(17, 'S', false), "The store should be closed at 5 PM on Saturday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(17, 'S', true), "The store should be closed at 5 PM on Saturday in summer months");
            Assert.IsFalse(store.IsStoreOpen(19, 'M', false), "The store should be closed at 7 PM on Monday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(19, 'W', false), "The store should be closed at 7 PM on Wednesday in non-summer months");
            Assert.IsTrue(store.IsStoreOpen(19, 'W', true), "The store should be open at 7 PM on Wednesday in summer months due to Wednesday-specific summer rules");
            Assert.IsFalse(store.IsStoreOpen(19, 'F', false), "The store should be closed at 7 PM on Friday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(19, 'S', false), "The store should be closed at 7 PM on Saturday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(20, 'W', false), "The store should be closed at 8 PM on Wednesday in non-summer months");
            Assert.IsFalse(store.IsStoreOpen(20, 'W', true), "The store should be closed at 8 PM on Wednesday in summer months");
        }
    }
}
