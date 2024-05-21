using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgDoubleLinked
{
    public class clsDoubleLinkedList<T> : clsADTDoubleLinked<T>, iList<T> where T : IComparable<T>
    {
        #region Builders
        public clsDoubleLinkedList()
        {
            attLength = 0;
            attItems = null;
        } 
        #endregion
        #region CRUDs
        public bool opAdd(T prmItem)
        {
            clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmItem);
            newNode.opSetItem(prmItem);
            attLength++;
            T[] prmArray = new T[attLength];
            prmArray[attLength - 1] = prmItem;
            for (int i = 0; i < attLength - 1; i++)
            {
                prmArray[i] = attItems[i];
            }
            attItems = prmArray;
            return true;
        }
        public bool opInsert(int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opRemove(int prmIdx, ref T prmItem)
        {
            if (attItems == null) return false;
            if (prmIdx < 0)
            {
                attMiddle.opSetItem(attItems[(attLength / 2) - 1]);
                attLastQuarter.opSetItem(attItems[(attLength / 2)]);
                return false;
            }
            if (prmIdx == attLength)
            {
                attMiddle.opSetItem(attItems[(attLength / 2) - 1]);
                attLastQuarter.opSetItem(attItems[(attLength / 2)]);
                return false;
            }
            attLength--;
            T[] prmArray = new T[attLength];
            prmItem = attItems[prmIdx];
            for (int i = 0; i < attLength; i++)
            {
                if (i != prmIdx)
                {
                    prmArray[i] = attItems[i];
                }
                else
                {
                    i++;
                    prmArray[i - 1] = attItems[i];
                }
            }
            attLength = prmIdx;
            attItems = prmArray;
            attMiddle.opSetItem(attItems[attLength / 2]);
            attLastQuarter = attMiddle;
            attFirstQuarter.opSetItem(attItems[attLength / 4]);
            attLast.opSetItem(attItems[2]);
            return true;
        }
        public override bool opRetrieve(int prmIdx, ref T prmItem)
        {
            if (attItems == null) return false;
            if (prmIdx < 0 || prmIdx == attLength)
            {
                attMiddle.opSetItem(attItems[(attItems.Length / 2) - 1]);
                attLastQuarter.opSetItem(attItems[attItems.Length - 2]);
                return false;
            }
            prmItem = attItems[prmIdx];
            attMiddle.opSetItem(attItems[(attItems.Length / 2) - 1]);
            attLastQuarter.opSetItem(attItems[attItems.Length - 2]);
            return true;
        } 
        #endregion
    }
}
