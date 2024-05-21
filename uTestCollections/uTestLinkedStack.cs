using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkgServices.pkgCollections.pkgLineal.pkgLinked;

namespace uTestCollections
{
    [TestClass]
    public class uTestLinkedStack
    {
        private clsLinkedStack<int> testMyStack;
        private int[] testExpectedItems;
        private int testExpectedItem;
        #region BuildersTests
        [TestMethod]
        public void testDefaultConstructor()
        {
            #region Setup
            #endregion
            #region Test & Assert
            testMyStack = new clsLinkedStack<int>();
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(null, testMyStack.opToArray());
            Assert.IsNull(testMyStack.opGetFirst());
            Assert.IsNull(testMyStack.opGetFirstQuarter());
            Assert.IsNull(testMyStack.opGetMiddle());
            Assert.IsNull(testMyStack.opGetLastQuarter());
            Assert.IsNull(testMyStack.opGetLast());
            #endregion
        }
        #endregion
        #region Push Tests
        [TestMethod]
        public void testPushFirstItem()
        {
            #region Setup
            testMyStack = new clsLinkedStack<int>();
            testExpectedItems = new int[1];
            testExpectedItems[0] = 123;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPush(123));
            Assert.AreEqual(1, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(123, testMyStack.opGetFirst().opGetItem());
            Assert.AreEqual(123, testMyStack.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(123, testMyStack.opGetMiddle().opGetItem());
            Assert.AreEqual(123, testMyStack.opGetLastQuarter().opGetItem());
            Assert.AreEqual(123, testMyStack.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testPushNextItem()
        {
            #region Setup
            testMyStack = new clsLinkedStack<int>();
            testMyStack.opToItems(new int[4] { 0, 1, 2, 3 });
            testExpectedItems = new int[5] { 456, 0, 1, 2, 3 };
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPush(456));
            Assert.AreEqual(5, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(456, testMyStack.opGetFirst().opGetItem());
            Assert.AreEqual(0, testMyStack.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(1, testMyStack.opGetMiddle().opGetItem());
            Assert.AreEqual(2, testMyStack.opGetLastQuarter().opGetItem());
            Assert.AreEqual(3, testMyStack.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testPushNextItemWithHugeCollection()
        {
            #region Setup
            testMyStack = new clsLinkedStack<int>();
            testMyStack.opToItems(new int[clsLinkedStack<int>.opGetMaxCapacity() - 1]);
            testExpectedItems = new int[clsLinkedStack<int>.opGetMaxCapacity()];
            testExpectedItems[0] = 777;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPush(777));
            Assert.AreEqual(clsLinkedStack<int>.opGetMaxCapacity(), testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            #endregion
        }
        #endregion
        #region Pop Tests
        [TestMethod]
        public void testPop()
        {
            #region Setup
            testMyStack = new clsLinkedStack<int>();
            testMyStack.opToItems(new int[4] { 1, 2, 3, 4 });
            testExpectedItems = new int[3] { 2, 3, 4 };
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsTrue(testMyStack.opPop(ref testExpectedItem));
            Assert.AreEqual(1, testExpectedItem);
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(2, testMyStack.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyStack.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(3, testMyStack.opGetMiddle().opGetItem());
            Assert.AreEqual(3, testMyStack.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyStack.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testPopWithEmptyCollection()
        {
            #region Setup
            testMyStack = new clsLinkedStack<int>();
            testExpectedItems = null;
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyStack.opPop(ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(null, testMyStack.opGetFirst());
            Assert.AreEqual(null, testMyStack.opGetFirstQuarter());
            Assert.AreEqual(null, testMyStack.opGetMiddle());
            Assert.AreEqual(null, testMyStack.opGetLastQuarter());
            Assert.AreEqual(null, testMyStack.opGetLast());
            #endregion
        }
        #endregion
        #region Peek Tests
        [TestMethod]
        public void testPeek()
        {
            #region Setup
            testMyStack = new clsLinkedStack<int>();
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
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(1, testMyStack.opGetFirst().opGetItem());
            Assert.AreEqual(2, testMyStack.opGetFirstQuarter().opGetItem());
            Assert.AreEqual(3, testMyStack.opGetMiddle().opGetItem());
            Assert.AreEqual(4, testMyStack.opGetLastQuarter().opGetItem());
            Assert.AreEqual(4, testMyStack.opGetLast().opGetItem());
            #endregion
        }
        [TestMethod]
        public void testPeekWithEmptyCollection()
        {
            #region Setup
            testMyStack = new clsLinkedStack<int>();
            testExpectedItems = null;
            testExpectedItem = default;
            #endregion
            #region Test & Assert
            Assert.IsFalse(testMyStack.opPeek(ref testExpectedItem));
            Assert.AreEqual(default, testExpectedItem);
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(null, testMyStack.opGetFirst());
            Assert.AreEqual(null, testMyStack.opGetFirstQuarter());
            Assert.AreEqual(null, testMyStack.opGetMiddle());
            Assert.AreEqual(null, testMyStack.opGetLastQuarter());
            Assert.AreEqual(null, testMyStack.opGetLast());
            #endregion
        }
        #endregion
    }
}
