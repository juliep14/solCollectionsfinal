using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkgServices.pkgCollections.pkgLineal.pkgLinked;
using pkgServices.pkgCollections.pkgLineal.pkgVector;

namespace uTestCollections
{
    [TestClass]
    public class uTestVectorStack
    {
        private clsVectorStack<int> testMyStack;
        private int[] testExpectedItems;
        private int testExpectedItem;
        #region BuildersTests
        [TestMethod]
        public void testDefaultConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>();
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testValidCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(10);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(10, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[10], testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testNegativeCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(-1);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testOverFlowCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(int.MaxValue);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testZeroCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(0);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testMaxCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(clsVectorStack<int>.opGetMaxCapacity());
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(clsVectorStack<int>.opGetMaxCapacity(), testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[clsVectorStack<int>.opGetMaxCapacity()], testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(0, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testBeyondMaxCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(clsVectorStack<int>.opGetMaxCapacity() + 1);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testBehindMaxCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(clsVectorStack<int>.opGetMaxCapacity() - 1);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(clsVectorStack<int>.opGetMaxCapacity() - 1, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[clsVectorStack<int>.opGetMaxCapacity() - 1], testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(1, testMyStack.opGetGrowingFactor());
            #endregion
        }
        #endregion
        #region Push Tests
        [TestMethod]
        public void testPushFirstItem()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = new int[100];
            testExpectedItems[0] = 123;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPush(123));
            Assert.AreEqual(1, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(99, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushNextItem()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[4] { 123, 0, 0, 0 }, 1);
            testExpectedItems = new int[4] { 456, 123, 0, 0 };
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPush(456));
            Assert.AreEqual(2, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(4, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(2, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushLastItem()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[4] { 789, 456, 123, 0 }, 3);
            testExpectedItems = new int[4];
            testExpectedItems[0] = 987;
            testExpectedItems[1] = 789;
            testExpectedItems[2] = 456;
            testExpectedItems[3] = 123;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPush(987));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(4, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(0, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushNextItemWithFullNoFlexibleCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[4] { 987, 789, 456, 123 });
            testExpectedItems = new int[4] { 987, 789, 456, 123 };
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyStack.opPush(666));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(4, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(0, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushNextItemWithFullFlexibleCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[4] { 987, 789, 456, 123 });
            testMyStack.opSetFlexible();
            testExpectedItems = new int[104];
            testExpectedItems[0] = 777;
            testExpectedItems[1] = 987;
            testExpectedItems[2] = 789;
            testExpectedItems[3] = 456;
            testExpectedItems[4] = 123;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPush(777));
            Assert.AreEqual(5, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(104, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsTrue(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(99, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushNextItemWithHugeFullFlexibleCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[clsVectorStack<int>.opGetMaxCapacity() - 1]);
            testMyStack.opSetFlexible();
            testExpectedItems = new int[clsVectorStack<int>.opGetMaxCapacity()];
            testExpectedItems[0] = 777;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPush(777));
            Assert.AreEqual(clsVectorStack<int>.opGetMaxCapacity(), testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(clsVectorStack<int>.opGetMaxCapacity(), testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(0, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(0, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        #endregion
        #region Pop Tests
        [TestMethod]
        public void testPopWithFullCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 2, 3, 4, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPop(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(4, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(1, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPopWithEmptyCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = new int[100];
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyStack.opPop(ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(100, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPopNextItem()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 2, 3, 4, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPop(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(2, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(4, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(2, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        #endregion
        #region Peek Tests
        [TestMethod]
        public void testPeekWithFullCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPeek(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(4, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(0, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPeekWithEmptyCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = new int[100];
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyStack.opPeek(ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(100, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPeekNextItem()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPeek(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(4, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(1, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        #endregion
    }
}