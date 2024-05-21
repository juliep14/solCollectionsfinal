using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkgServices.pkgCollections.pkgLineal.pkgDoubleLinked;

namespace uTestCollections
{
    [TestClass]
    public class uTestDoubleLinkedQueue
    {
        private clsDoubleLinkedQueue<int> testMyQueue;
        private int[] testExpectedItems;
        private int testExpectedItem;
        #region BuildersTests
        [TestMethod]
        public void testDefaultConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyQueue = new clsDoubleLinkedQueue<int>();
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            CollectionAssert.AreEqual(null, testMyQueue.opToArray());
            Assert.IsNull(testMyQueue.opGetFirst());
            Assert.IsNull(testMyQueue.opGetFirstQuarter());
            Assert.IsNull(testMyQueue.opGetMiddle());
            Assert.IsNull(testMyQueue.opGetLastQuarter());
            Assert.IsNull(testMyQueue.opGetLast());
            #endregion
        }
        #endregion
        #region Push Tests
        [TestMethod]
        public void testPushFirstItem()
        {
            #region Setup
            testMyQueue = new clsDoubleLinkedQueue<int>();
            testExpectedItems = new int[1];
            testExpectedItems[0] = 123;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPush(123));
            Assert.AreEqual(1, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.AreEqual(123, testMyQueue.opGetFirst().opGetItem());
            Assert.AreEqual(123, testMyQueue.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(123, testMyQueue.opGetMiddle().opGetItem());
            Assert.AreEqual(123, testMyQueue.opGetLastQuarter().opGetItem());
            Assert.AreEqual(123, testMyQueue.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testPushNextItem()
        {
            #region Setup
            testMyQueue = new clsDoubleLinkedQueue<int>();
            testMyQueue.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[5] { 1, 2, 3, 4, 456 };
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPush(456));
            Assert.AreEqual(5, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.AreEqual(1, testMyQueue.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyQueue.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(3, testMyQueue.opGetMiddle().opGetItem());
            Assert.AreEqual(4, testMyQueue.opGetLastQuarter().opGetItem());
            Assert.AreEqual(456, testMyQueue.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testPushNextItemWithHugeCollection()
        {
            #region Setup
            testMyQueue = new clsDoubleLinkedQueue<int>();
            testMyQueue.opToItems(new int[clsDoubleLinkedQueue<int>.opGetMaxCapacity() - 1]);
            testExpectedItems = new int[clsDoubleLinkedQueue<int>.opGetMaxCapacity()];
            testExpectedItems[clsDoubleLinkedQueue<int>.opGetMaxCapacity() - 1] = 777;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPush(777));
            Assert.AreEqual(clsDoubleLinkedQueue<int>.opGetMaxCapacity(), testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.AreEqual(0, testMyQueue.opGetFirst().opGetItem());
            Assert.AreEqual(0, testMyQueue.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(0, testMyQueue.opGetMiddle().opGetItem());
            Assert.AreEqual(0, testMyQueue.opGetLastQuarter().opGetItem());
            Assert.AreEqual(777, testMyQueue.opGetLast().opGetItem());
            #endregion
        }
        #endregion
        #region Pop Tests
        [TestMethod]
        public void testPop()
        {
            #region Setup
            testMyQueue = new clsDoubleLinkedQueue<int>();
            testMyQueue.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[3] { 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyQueue.opPop(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(3, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.AreEqual(2, testMyQueue.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyQueue.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(3, testMyQueue.opGetMiddle().opGetItem());
            Assert.AreEqual(3, testMyQueue.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyQueue.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testPopWithEmptyCollection()
        {
            #region Setup
            testMyQueue = new clsDoubleLinkedQueue<int>();
            testExpectedItems = null;
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyQueue.opPop(ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsNull(testMyQueue.opGetFirst());
            Assert.IsNull(testMyQueue.opGetFirstQuarter());
            Assert.IsNull(testMyQueue.opGetMiddle());
            Assert.IsNull(testMyQueue.opGetLastQuarter());
            Assert.IsNull(testMyQueue.opGetLast());
            #endregion
        }
        #endregion
        #region Peek Tests
        [TestMethod]
        public void testPeek()
        {
            #region Setup
            testMyQueue = new clsDoubleLinkedQueue<int>();
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
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.AreEqual(1, testMyQueue.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyQueue.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(3, testMyQueue.opGetMiddle().opGetItem());
            Assert.AreEqual(3, testMyQueue.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyQueue.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testPeekWithEmptyCollection()
        {
            #region Setup
            testMyQueue = new clsDoubleLinkedQueue<int>();
            testExpectedItems = new int[100];
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyQueue.opPeek(ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyQueue.opToArray());
            Assert.IsNull(testMyQueue.opGetFirst());
            Assert.IsNull(testMyQueue.opGetFirstQuarter());
            Assert.IsNull(testMyQueue.opGetMiddle());
            Assert.IsNull(testMyQueue.opGetLastQuarter());
            Assert.IsNull(testMyQueue.opGetLast());
            #endregion
        }
        #endregion
    }
}
