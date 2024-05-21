using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgLinked;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTLinked<T> : clsADTLineal<T>, iADTLinked<T> where T : IComparable<T>
    {
        #region Attributes
        protected clsLinkedNode<T> attFirst;
        protected clsLinkedNode<T> attFirstQuarter;
        protected clsLinkedNode<T> attMiddle;
        protected clsLinkedNode<T> attLastQuarter;
        protected clsLinkedNode<T> attLast;
        protected clsLinkedNode<T> attCurrentNode;
        #endregion
        #region Operations
        #region Builders
        protected clsADTLinked() { }
        #endregion
        #region Getters
        public clsLinkedNode<T> opGetFirst()
        {
            if (attItems == null)
            {
                return attFirst;
            }
            if (attLength == 0)
            {
                attFirst = null;
                return attFirst;
            }
            attFirst.opSetItem(attItems[0]);
            return attFirst;
        }
        public clsLinkedNode<T> opGetFirstQuarter()
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
            attFirstQuarter.opSetItem(attItems[attLength/4]);
            return attFirstQuarter;
        }
        public clsLinkedNode<T> opGetLast()
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
            if (attLength != attItems.Length)
            {
                attLast.opSetItem(attItems[attLength]);
                return attLast;
            }
            attLast.opSetItem(attItems[attLength-1]);
            return attLast;
        }
        public clsLinkedNode<T> opGetLastQuarter()
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
            if (attLastQuarter != null) return attLastQuarter;
            if (attItems.Length == 4)
            {
                attLastQuarter.opSetItem(attItems[attItems.Length - 2]);
                return attLastQuarter;
            }
            attLastQuarter.opSetItem(attItems[(attLength / 4) + (attLength / 2)]);
            return attLastQuarter;
        }
        public clsLinkedNode<T> opGetMiddle()
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
            if (attMiddle != null) return attMiddle;
            if (attItems.Length == attLength && attMiddle != null)
            {
                attMiddle.opSetItem(attItems[(attItems.Length / 2) - 1]);
                return attMiddle;
            }
            attMiddle.opSetItem(attItems[attLength / 2]);
            return attMiddle;
        }
        #endregion
        #region Setters
        public bool opSetFirst(clsLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        public bool opSetLast(clsLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        public bool opSetMiddle(clsLinkedNode<T> prmNode)
        {
            attMiddle = prmNode;
            return true;
        }
        #endregion
        #region Iterator
        public override bool opGoFirst()
        {
            if (attFirst == null) return false;
            attCurrentItem = attFirst.opGetItem();
            attCurrentIdx = 0;
            return true;
        }
        public override bool opGo(int prmIdx)
        {
            if (!opIsValid(prmIdx)) return false;
            if (prmIdx < attLength / 4) opGoFirst();
            if (prmIdx >= attLength / 4 && prmIdx < attLength / 2) opGoFirstQuarter();
            if (prmIdx >= attLength / 2 && prmIdx < attLength / 4) opGoMiddle();
            if ((prmIdx >= attLength / 2 + attLength / 4) && prmIdx < attLength) opGoLastQuarter();
            while (attCurrentIdx < prmIdx)
                opGoNext();
            return true;
        }
        public override bool opGoFirstQuarter()
        {
            return base.opGoFirstQuarter();
        }
        public override bool opGoLastQuarter()
        {
            return base.opGoLastQuarter();
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
            attFirst = new clsLinkedNode<T>(prmArray[0]);
            attMiddle = attFirst;
            clsLinkedNode<T> varPreviousNode = attFirst;
            clsLinkedNode<T> varCurrentNode = attFirst;
            for (int varIdx = 1; varIdx < prmArray.Length; varIdx++)
            {
                varCurrentNode = new clsLinkedNode<T>(prmArray[varIdx]);
                varPreviousNode.opSetNext(varCurrentNode);
                if (varIdx == (prmArray.Length / 4)) attFirstQuarter = varCurrentNode;
                if (varIdx == (prmArray.Length / 2)) attMiddle = varCurrentNode;
                if (varIdx == (prmArray.Length / 2 + prmArray.Length / 4)) attLastQuarter = varCurrentNode;
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
