using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgLinked
{
    public class clsLinkedList<T> : clsADTLinked<T>, iList<T> where T : IComparable<T>
    {
        #region Builders
        public clsLinkedList()
        {
            attLength = 0;
            attItems = null;
            attMiddle = null;
        }
        public clsLinkedList(int prmCapacity)
        {
            try
            {
                if (prmCapacity < 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                }
                if (prmCapacity == 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                }
                if (attLength < 0) attLength = 0;
                attItems = new T[prmCapacity];
            }
            catch
            {
                attTotalCapacity = 100;
                attMaxCapacity = int.MaxValue / 16;
                attItems = new T[100];
            }
        }
        #endregion
        #region CRUDs
        public bool opAdd(T prmItem)
        {
            clsLinkedNode<T> newNode = new clsLinkedNode<T>(prmItem);
            attLength++;
            T[] prmArray = new T[attLength];
            prmArray[attLength - 1] = newNode.opGetItem();
            for (int i = 0; i < attLength - 1; i++)
            {
                prmArray[i] = attItems[i];
            }
            attItems = prmArray;
            attLast = newNode;
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
            attLastQuarter.opSetItem(attItems[attLength - 1]);
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
            prmItem = attItems[1];
            attMiddle.opSetItem(attItems[(attItems.Length / 2) - 1]);
            attLastQuarter.opSetItem(attItems[attItems.Length - 2]);
            if (attItems == null) return false;
            return true;
        } 
        #endregion
    }
}
