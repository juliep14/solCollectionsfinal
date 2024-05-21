using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkgServices.pkgCollections.pkgLineal.pkgLinked;
using pkgServices.pkgCollections.pkgLineal.pkgVector;

namespace uTestCollections
{
    [TestClass]
    public class uTestVectorList
    {
        private clsVectorList<int> testMyList;
        private int[] testExpectedItems;
        private int testExpectedItem;
        #region BuildersTests
        [TestMethod]
        public void testDefaultConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyList = new clsVectorList<int>();
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(100, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testValidCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyList = new clsVectorList<int>(10);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(10, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[10], testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testNegativeCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyList = new clsVectorList<int>(-1);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(100, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testOverFlowCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyList = new clsVectorList<int>(int.MaxValue);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(100, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testZeroCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyList = new clsVectorList<int>(0);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(100, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testMaxCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyList = new clsVectorList<int>(clsVectorList<int>.opGetMaxCapacity());
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(clsVectorList<int>.opGetMaxCapacity(), testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[clsVectorList<int>.opGetMaxCapacity()], testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(0, testMyList.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testBeyondMaxCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyList = new clsVectorList<int>(clsVectorList<int>.opGetMaxCapacity() + 1);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(100, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testBehindMaxCapacityConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyList = new clsVectorList<int>(clsVectorList<int>.opGetMaxCapacity() - 1);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(clsVectorList<int>.opGetMaxCapacity() - 1, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[clsVectorList<int>.opGetMaxCapacity() - 1], testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(1, testMyList.opGetGrowingFactor());
            #endregion
        }
        #endregion
        #region Add Tests
        [TestMethod]
        public void testAddFirstItem()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testExpectedItems = new int[100];
            testExpectedItems[0] = 123;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opAdd(123));
            Assert.AreEqual(1, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(100, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(99, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testAddNextItem()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 123, 0, 0, 0 }, 1);
            testExpectedItems = new int[4] { 123, 456, 0, 0 };
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opAdd(456));
            Assert.AreEqual(2, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(2, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testAddLastItem()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 789, 456, 123, 0 }, 3);
            testExpectedItems = new int[4] { 789, 456, 123, 987 };
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opAdd(987));
            Assert.AreEqual(4, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(0, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testAddNextItemWithFullNoFlexibleCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 987, 789, 456, 123 });
            testExpectedItems = new int[4] { 987, 789, 456, 123 };
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opAdd(666));
            Assert.AreEqual(4, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(0, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testAddNextItemWithFullFlexibleCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 987, 789, 456, 123 });
            testMyList.opSetFlexible();
            testExpectedItems = new int[104];
            testExpectedItems[0] = 987;
            testExpectedItems[1] = 789;
            testExpectedItems[2] = 456;
            testExpectedItems[3] = 123;
            testExpectedItems[4] = 777;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opAdd(777));
            Assert.AreEqual(5, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(104, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsTrue(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(99, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testAddNextItemWithHugeFullFlexibleCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[clsVectorList<int>.opGetMaxCapacity() - 1]);
            testMyList.opSetFlexible();
            testExpectedItems = new int[clsVectorList<int>.opGetMaxCapacity()];
            testExpectedItems[clsVectorList<int>.opGetMaxCapacity() - 1] = 777;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opAdd(777));
            Assert.AreEqual(clsVectorList<int>.opGetMaxCapacity(), testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(clsVectorList<int>.opGetMaxCapacity(), testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(0, testMyList.opGetGrowingFactor());
            Assert.AreEqual(0, testMyList.opGetAvailableCapacity());
            #endregion
        }
        #endregion
        #region Remove Tests
        [TestMethod]
        public void testRemoveWithLowerInvalidIndexAndFullCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRemove(-1, ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(3, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(1, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testRemoveWithUpperInvalidIndexAndFullCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRemove(testMyList.opGetLength(), ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(3, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(1, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testRemoveWithEmptyCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testExpectedItems = new int[100];
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRemove(0, ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(100, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(100, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testRemoveItemOnValidIndexWithSemiFullCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 1, 3, 4, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opRemove(1, ref testExpectedItem));
            Assert.AreEqual(2, testExpectedItem);
            Assert.AreEqual(2, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(2, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testRemoveLastItemWithSemiFullCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opRemove(2, ref testExpectedItem));
            Assert.AreEqual(3, testExpectedItem);
            Assert.AreEqual(2, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(2, testMyList.opGetAvailableCapacity());
            #endregion
        }
        #endregion
        #region Retrieve Tests
        [TestMethod]
        public void testRetrieveWithEmptyCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testExpectedItems = new int[100];
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRetrieve(2, ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(100, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(100, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testRetrieveItemWithLowerInValidIndexSemiFullCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRetrieve(-1, ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(3, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(1, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testRetrieveItemWithUpperInValidIndexSemiFullCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRetrieve(testMyList.opGetLength(), ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(3, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(1, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testRetrieveItemWithValidIndexSemiFullCollection()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opRetrieve(1, ref testExpectedItem));
            Assert.AreEqual(2, testExpectedItem);
            Assert.AreEqual(3, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(1, testMyList.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testRetrieveLastItem()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opRetrieve(2, ref testExpectedItem));
            Assert.AreEqual(3, testExpectedItem);
            Assert.AreEqual(3, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(4, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            Assert.AreEqual(1, testMyList.opGetAvailableCapacity());
            #endregion
        }
        #endregion
    }
}