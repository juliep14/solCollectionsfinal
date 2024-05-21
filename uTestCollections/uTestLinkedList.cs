using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkgServices.pkgCollections.pkgLineal.pkgLinked;
using pkgServices.pkgCollections.pkgLineal.pkgVector;

namespace uTestCollections
{
    [TestClass]
    public class uTestLinkedList
    {
        private clsLinkedList<int> testMyList;
        private int[] testExpectedItems;
        private int testExpectedItem;
        #region BuildersTests
        [TestMethod]
        public void testDefaultConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyList = new clsLinkedList<int>();
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(null, testMyList.opToArray());
            Assert.IsNull(testMyList.opGetFirst());
            Assert.IsNull(testMyList.opGetFirstQuarter());
            Assert.IsNull(testMyList.opGetMiddle());
            Assert.IsNull(testMyList.opGetLastQuarter());
            Assert.IsNull(testMyList.opGetLast());
            #endregion
        }
        #endregion
        #region Add Tests
        [TestMethod]
        public void testAddItem()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testMyList.opToItems(new int[4] { 123, 0, 0, 0 });
            testExpectedItems = new int[5] { 123, 0, 0, 0, 456 };
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opAdd(456));
            Assert.AreEqual(5, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.AreEqual(123, testMyList.opGetFirst().opGetItem());
            Assert.AreEqual(0, testMyList.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(0, testMyList.opGetMiddle().opGetItem());
            Assert.AreEqual(0, testMyList.opGetLastQuarter().opGetItem());
            Assert.AreEqual(456, testMyList.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testAddNextItemWithHugeCollection()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testMyList.opToItems(new int[clsLinkedList<int>.opGetMaxCapacity() - 1]);
            testExpectedItems = new int[clsLinkedList<int>.opGetMaxCapacity()];
            testExpectedItems[clsLinkedList<int>.opGetMaxCapacity() - 1] = 777;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opAdd(777));
            Assert.AreEqual(clsLinkedList<int>.opGetMaxCapacity(), testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.AreEqual(0, testMyList.opGetFirst().opGetItem());
            Assert.AreEqual(0, testMyList.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(0, testMyList.opGetMiddle().opGetItem());
            Assert.AreEqual(0, testMyList.opGetLastQuarter().opGetItem());
            Assert.AreEqual(777, testMyList.opGetLast().opGetItem());
            #endregion
        }
        #endregion
        #region Remove Tests
        [TestMethod]
        public void testRemoveWithLowerInvalidIndex()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRemove(-1, ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(4, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.AreEqual(1, testMyList.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyList.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(2, testMyList.opGetMiddle().opGetItem());
            Assert.AreEqual(3, testMyList.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyList.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testRemoveWithUpperInvalidIndexAndFullCollection()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRemove(testMyList.opGetLength(), ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(4, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.AreEqual(1, testMyList.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyList.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(2, testMyList.opGetMiddle().opGetItem());
            Assert.AreEqual(3, testMyList.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyList.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testRemoveWithEmptyCollection()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testExpectedItems = null;
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRemove(0, ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsNull(testMyList.opGetFirst());
            Assert.IsNull(testMyList.opGetFirstQuarter());
            Assert.IsNull(testMyList.opGetMiddle());
            Assert.IsNull(testMyList.opGetLastQuarter());
            Assert.IsNull(testMyList.opGetLast());
            #endregion
        }
        [TestMethod]
        public void testRemove()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[3] { 1, 2, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opRemove(2, ref testExpectedItem));
            Assert.AreEqual(3, testExpectedItem);
            Assert.AreEqual(2, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.AreEqual(1, testMyList.opGetFirst().opGetItem());
            Assert.AreEqual(1, testMyList.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(2, testMyList.opGetMiddle().opGetItem());
            Assert.AreEqual(2, testMyList.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyList.opGetLast().opGetItem());
            #endregion
        }
        #endregion
        #region Retrieve Tests
        [TestMethod]
        public void testRetrieveWithEmptyCollection()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testExpectedItems = null;
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRetrieve(2, ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.IsNull(testMyList.opGetFirst());
            Assert.IsNull(testMyList.opGetFirstQuarter());
            Assert.IsNull(testMyList.opGetMiddle());
            Assert.IsNull(testMyList.opGetLastQuarter());
            Assert.IsNull(testMyList.opGetLast());
            #endregion
        }
        [TestMethod]
        public void testRetrieveItemWithLowerInValidIndex()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRetrieve(-1, ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(4, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.AreEqual(1, testMyList.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyList.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(2, testMyList.opGetMiddle().opGetItem());
            Assert.AreEqual(3, testMyList.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyList.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testRetrieveItemWithUpperInValidIndex()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyList.opRetrieve(testMyList.opGetLength(), ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(4, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.AreEqual(1, testMyList.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyList.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(2, testMyList.opGetMiddle().opGetItem());
            Assert.AreEqual(3, testMyList.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyList.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testRetrieveItemWithValidIndex()
        {
            #region Setup
            testMyList = new clsLinkedList<int>();
            testMyList.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[4] { 1, 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyList.opRetrieve(1, ref testExpectedItem));
            Assert.AreEqual(2, testExpectedItem);
            Assert.AreEqual(4, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyList.opToArray());
            Assert.AreEqual(1, testMyList.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyList.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(2, testMyList.opGetMiddle().opGetItem());
            Assert.AreEqual(3, testMyList.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyList.opGetLast().opGetItem());
            #endregion
        }
    }
    #endregion
}
