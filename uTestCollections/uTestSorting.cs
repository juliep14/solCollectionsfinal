using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkgServices.pkgCollections.pkgLineal.pkgVector;

namespace uTestCollections
{
    [TestClass]
    public class uTestSorting
    {
        public clsVectorStack<int> testMyStack;
        public int[] testExpectedItems;
        #region Bubble Sort Tests
        [TestMethod]
        public void testBubbleSortByAscendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opBubbleSort(true));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testBubbleSortByDescendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opBubbleSort(false));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testBubbleSortByAscendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opBubbleSort(true));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testBubbleSortByDescendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opBubbleSort(false));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testBubbleSortByAscendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opBubbleSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testBubbleSortByDescendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opBubbleSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testBubbleSortByDescendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { -1, 1, 2, 3 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opBubbleSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testBubbleSortByAscendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 2, 1, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opBubbleSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        #endregion
        #region Cocktail Sort Tests
        [TestMethod]
        public void testCocktailSortByAscendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opCocktailSort(true));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testCocktailSortByDescendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opCocktailSort(false));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testCocktailSortByAscendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opCocktailSort(true));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testCocktailSortByDescendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opCocktailSort(false));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testCocktailSortByAscendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opCocktailSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testCocktailSortByDescendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opCocktailSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testCocktailSortByDescendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { -1, 1, 2, 3 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opCocktailSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testCocktailSortByAscendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 2, 1, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opCocktailSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        #endregion
        #region Insert Sort Tests
        [TestMethod]
        public void testInsertSortByAscendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opInsertSort(true));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testInsertSortByDescendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opInsertSort(false));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testInsertSortByAscendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opInsertSort(true));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testInsertSortByDescendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opInsertSort(false));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testInsertSortByAscendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opInsertSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testInsertSortByDescendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opInsertSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testInsertSortByDescendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { -1, 1, 2, 3 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opInsertSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testInsertSortByAscendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 2, 1, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opInsertSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        #endregion
        #region Merge Sort Tests
        [TestMethod]
        public void testMergeSortByAscendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opMergeSort(true));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testMergeSortByDescendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opMergeSort(false));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testMergeSortByAscendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opMergeSort(true));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testMergeSortByDescendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opMergeSort(false));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testMergeSortByAscendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opMergeSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testMergeSortByDescendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opMergeSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testMergeSortByDescendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { -1, 1, 2, 3 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opMergeSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testMergeSortByAscendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 2, 1, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opMergeSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        #endregion
        #region Quick Sort Tests
        [TestMethod]
        public void testQuickSortByAscendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opQuickSort(true));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testQuickSortByDescendingWithEmptyVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = null;
            #endregion
            #region Test&Assert
            Assert.IsFalse(testMyStack.opQuickSort(false));
            Assert.AreEqual(0, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testQuickSortByAscendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 1, 2, 3, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opQuickSort(true));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testQuickSortByDescendingWithSemiFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 }, 3);
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opQuickSort(false));
            Assert.AreEqual(3, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testQuickSortByAscendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opQuickSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testQuickSortByDescendingWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 1, 2, -1 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opQuickSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testQuickSortByDescendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { -1, 1, 2, 3 });
            testExpectedItems = new int[4] { 3, 2, 1, -1 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opQuickSort(false));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsTrue(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        [TestMethod]
        public void testQuickSortByAscendingWorstCaseWithFullVectorStackCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[] { 3, 2, 1, -1 });
            testExpectedItems = new int[4] { -1, 1, 2, 3 };
            #endregion
            #region Test&Assert
            Assert.IsTrue(testMyStack.opQuickSort(true));
            Assert.AreEqual(4, testMyStack.opGetLength());
            Assert.IsTrue(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.IsFalse(testMyStack.opItsFlexible());
            #endregion
        }
        #endregion
    }
}