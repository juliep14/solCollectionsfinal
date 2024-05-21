using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTDoubleLinked<T> : clsADTLineal<T>, iADTDoubleLinked<T> where T : IComparable<T>
    {
        #region Attributes
        protected clsDoubleLinkedNode<T> attFirst;
        protected clsDoubleLinkedNode<T> attFirstQuarter;
        protected clsDoubleLinkedNode<T> attMiddle;
        protected clsDoubleLinkedNode<T> attLastQuarter;
        protected clsDoubleLinkedNode<T> attLast;
        protected clsDoubleLinkedNode<T> attCurrentNode;
        #endregion
        #region Operations
        #region Builders
        protected clsADTDoubleLinked()
        {
        }
        #endregion
        #region Getters
        public clsDoubleLinkedNode<T> opGetFirst()
        {
            if (attItems == null)
            {
                attFirst = null;
                return attFirst;
            }
            if (attLength == 0)
            {
                attFirst = null;
                return attFirst;
            }
            if (attLength == 1)
            {
                attFirst.opSetItem(attItems[0]);
                return attFirst;
            }
            attFirst.opSetItem(attItems[0]);
            return attFirst;
        }
        public clsDoubleLinkedNode<T> opGetFirstQuarter()
        {
            if (attItems == null)
            {
                attFirstQuarter = null;
                return attFirstQuarter;
            }
            if (attLength == 0)
            {
                attFirstQuarter = null;
                return attFirstQuarter;
            }
            if (attLength == 1)
            {
                attFirstQuarter.opSetItem(attItems[0]);
                return attFirstQuarter;
            }
            if (attFirstQuarter != null) return attFirstQuarter;
            attFirstQuarter.opSetItem(attItems[(attLength / 1) / 4]);
            return attFirstQuarter;
        }
        public clsDoubleLinkedNode<T> opGetLast()
        {
            if (attItems == null)
            {
                attLast = null;
                return attLast;
            }
            if (attLength == 0)
            {
                attLast = null;
                return attLast;
            }
            if (attLength == 1)
            {
                attLast.opSetItem(attItems[0]);
                return attLast;
            }
            if(attLength == attItems.Length)
            {
                attLast.opSetItem(attItems[attLength - 1]);
            }
            if (attLength == attItems.Length / 2)
            {
                attLast.opSetItem(attItems[attItems.Length - 1]);
                return attLast;
            }
            if (attLast != null) return attLast;
            attLast.opSetItem(attItems[attLength - 1]);
            return attLast;
        }
        public clsDoubleLinkedNode<T> opGetLastQuarter()
        {
            if (attItems == null)
            {
                attLastQuarter = null;
                return attLastQuarter;
            }
            if (attLength == 0)
            {
                attLastQuarter = null;
                return attLastQuarter;
            }
            if (attLength == 1)
            {
                attLastQuarter.opSetItem(attItems[0]);
                return attLastQuarter;
            }
            if (attLastQuarter != null) return attLastQuarter;
            if (attLength == attItems.Length)
            {
                attLast.opSetItem(attItems[attLength/2]);
            }
            if (attLastQuarter != null) return attLastQuarter;
            attLastQuarter.opSetItem(attItems[(attLength / 2) + (attLength / 4)]);
            return attLastQuarter;
        }
        public clsDoubleLinkedNode<T> opGetMiddle()
        {
            if (attItems == null)
            {
                attMiddle = null;
                return attMiddle;
            }
            if (attLength == 0)
            {
                attMiddle = null;
                return attMiddle;
            }
            if (attLength == 1)
            {
                attMiddle.opSetItem(attItems[0]);
                return attMiddle;
            }
            if (attMiddle != null) return attMiddle;
            attMiddle.opSetItem(attItems[attLength / 2]);
            return attMiddle;
        }
        #endregion
        #region Setters
        public bool opSetFirst(clsDoubleLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        public bool opSetLast(clsDoubleLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        public bool opSetMiddle(clsDoubleLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        #endregion 
        #region Iterator
        public override bool opGo(int prmIdx)
        {
            if (!opIsValid(prmIdx)) return false;
            if (prmIdx < attLength / 2)
                opGoFirst();
            else opGoMiddle();
            while (attCurrentIdx < prmIdx)
                opGoNext();
            return true;
        }
        public override bool opGoFirstQuarter()
        {
            if (attFirstQuarter == null) return false;
            attCurrentItem = attFirstQuarter.opGetItem();
            attCurrentIdx = attLength / 4;
            return true;
        }
        public override bool opGoLastQuarter()
        {
            if (attLastQuarter == null) return false;
            attCurrentItem = attLastQuarter.opGetItem();
            attCurrentIdx = (attLength / 2) + (attLength / 4);
            return true;
        }
        public override void opGoBack()
        {
            base.opGoBack();
            attCurrentNode = attCurrentNode.opGetNext();
            attCurrentItem = attCurrentNode.opGetItem();
        }
        public override void opGoForward()
        {
            base.opGoForward();
            attCurrentNode = attCurrentNode.opGetNext();
            attCurrentItem = attCurrentNode.opGetItem();
        }
        #endregion
        #region Serialize/Deserialize
        public override bool opToItems(T[] prmArray)
        {
            if (prmArray == null) return false;
            if (prmArray.Length == 0) return false;
            if (prmArray.Length > attMaxCapacity) return false;
            attFirst = new clsDoubleLinkedNode<T>(prmArray[0]);
            attMiddle = attFirst;
            clsDoubleLinkedNode<T> varPreviousNode = attFirst;
            clsDoubleLinkedNode<T> varCurrentNode = attFirst;
            for (int varIdx = 1; varIdx < prmArray.Length; varIdx++)
            {
                varCurrentNode = new clsDoubleLinkedNode<T>(prmArray[varIdx]);
                varPreviousNode.opSetNext(varCurrentNode);
                if (varIdx == (prmArray.Length / 4)) attFirstQuarter = varCurrentNode;
                if (varIdx == (prmArray.Length / 2)) attMiddle = varCurrentNode;
                if (varIdx == (prmArray.Length / 4)) attFirstQuarter = varCurrentNode;
                if (varIdx == (prmArray.Length / 2) + (prmArray.Length / 4)) attLastQuarter = varCurrentNode;
                varPreviousNode = varCurrentNode;
            }
            attItems = prmArray;
            attLength = attItems.Length;
            attLast = varCurrentNode;
            return true;
        }
        #endregion
        #endregion
    }
}
