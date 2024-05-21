using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkgServices.pkgCollections.pkgLineal.pkgLinked;
using pkgServices.pkgCollections.pkgLineal.pkgVector;

namespace uTestCollections
{
    [TestClass]
    public class uTestVectorQueue
    {
        private clsVectorQueue<int> testMyQueue;
        private int[] testExpectedItems;
        private int testExpectedItem;
        #region BuildersTests
        [TestMethod]
        public void testDefaultConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyQueue = new clsVectorQueue<int>();
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testValidCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyQueue = new clsVectorQueue<int>(10);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(10, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[10], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testNegativeCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyQueue = new clsVectorQueue<int>(-1);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testOverFlowCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyQueue = new clsVectorQueue<int>(int.MaxValue);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testZeroCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyQueue = new clsVectorQueue<int>(0);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testMaxCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyQueue = new clsVectorQueue<int>(clsVectorQueue<int>.opGetMaxCapacity());
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(clsVectorQueue<int>.opGetMaxCapacity(), testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[clsVectorQueue<int>.opGetMaxCapacity()], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(0, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testBeyondMaxCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyQueue = new clsVectorQueue<int>(clsVectorQueue<int>.opGetMaxCapacity() + 1);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testBehindMaxCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyQueue = new clsVectorQueue<int>(clsVectorQueue<int>.opGetMaxCapacity() - 1);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(clsVectorQueue<int>.opGetMaxCapacity() - 1, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[clsVectorQueue<int>.opGetMaxCapacity() - 1], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(1, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        #endregion
        #region Push Tests
        [TestMethod]
        public void testPushFirstItem()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testExpectedItems = new int[100];
            testExpectedItems[0] = 123;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPush(123));
            Assert.AreEqual(1, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(99, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushNextItem()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testMyQueue.opToItems(new int[4] { 123, 0, 0, 0 }, 1);
            testExpectedItems = new int[4] { 123, 456, 0, 0 };
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPush(456));
            Assert.AreEqual(2, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(4, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(2, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushLastItem()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testMyQueue.opToItems(new int[4] { 789, 456, 123, 0 }, 3);
            testExpectedItems = new int[4] { 789, 456, 123, 987 };
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPush(987));
            Assert.AreEqual(4, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(4, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(0, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushNextItemWithFullNoFlexibleCollection()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testMyQueue.opToItems(new int[4] { 987, 789, 456, 123 });
            testExpectedItems = new int[4] { 987, 789, 456, 123 };
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyQueue.opPush(666));
            Assert.AreEqual(4, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(4, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(0, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushNextItemWithFullFlexibleCollection()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testMyQueue.opToItems(new int[4] { 987, 789, 456, 123 });
            testMyQueue.opSetFlexible();
            testExpectedItems = new int[104];
            testExpectedItems[0] = 987;
            testExpectedItems[1] = 789;
            testExpectedItems[2] = 456;
            testExpectedItems[3] = 123;
            testExpectedItems[4] = 777;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPush(777));
            Assert.AreEqual(5, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(104, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsTrue(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(99, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushNextItemWithHugeFullFlexibleCollection()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testMyQueue.opToItems(new int[clsVectorQueue<int>.opGetMaxCapacity() - 1]);
            testMyQueue.opSetFlexible();
            testExpectedItems = new int[clsVectorQueue<int>.opGetMaxCapacity()];
            testExpectedItems[clsVectorQueue<int>.opGetMaxCapacity() - 1] = 777;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPush(777));
            Assert.AreEqual(clsVectorQueue<int>.opGetMaxCapacity(), testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(clsVectorQueue<int>.opGetMaxCapacity(), testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(0, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(0, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        #endregion
        #region Pop Tests
        [TestMethod]
        public void testPopWithFullCollection()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testMyQueue.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 2, 3, 4, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPop(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(3, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(4, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(1, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPopWithEmptyCollection()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testExpectedItems = new int[100];
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyQueue.opPop(ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(100, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPopNextItem()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testMyQueue.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 2, 3, 4, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPop(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(2, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(4, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(2, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        #endregion
        #region Peek Tests
        [TestMethod]
        public void testPeekWithFullCollection()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testMyQueue.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPeek(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(4, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(4, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(0, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPeekWithEmptyCollection()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testExpectedItems = new int[100];
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyQueue.opPeek(ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(100, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPeekNextItem()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            testMyQueue.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPeek(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(3, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(4, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            Assert.AreEqual(1, testMyQueue.opGetAvailableCapacity());
            #endregion
        }
        #endregion
    }
}
