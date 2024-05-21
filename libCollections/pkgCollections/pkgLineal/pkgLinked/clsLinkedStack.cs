using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgLinked
{
    public class clsLinkedStack<T> : clsADTLinked<T>, iStack<T> where T : IComparable<T>
    {
        #region Builders
        public clsLinkedStack()
        {
            attLength = 0;
            attItems = null;
        }
        public clsLinkedStack(int prmCapacity)
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
        public bool opPeek(ref T prmItem)
        {
            if (attLength == 0)
            {
                prmItem = default;
                return false;
            }
            else
            {
                prmItem = attItems[0];
                attMiddle.opSetItem(attItems[attLength / 2]);
                attLastQuarter.opSetItem(attItems[attLength - 1]);
                return true;
            }
        }
        public bool opPop(ref T prmItem)
        {
            if (attItems == null) return false;
            prmItem = attItems[0];
            attLength--;
            T[] prmArray = new T[attLength];
            for (int i = 0; i < attLength; i++)
            {
                prmArray[i] = attItems[i + 1];
            }
            attItems = prmArray;
            attLastQuarter.opSetItem(attMiddle.opGetItem());
            return true;
        }
        public bool opPush(T prmItem)
        {
            clsLinkedNode<T> newNode = new clsLinkedNode<T>(prmItem);
            if (attFirst == null)
            {
                attLength++;
                T[] array = new T[attLength];
                array[0] = newNode.opGetItem();
                attItems = array;
                attFirst = newNode;
                attFirstQuarter = newNode;
                attMiddle = newNode;
                attLastQuarter = newNode;
                attLast = newNode;
                return true;
            }
            attLength++;
            T[] prmArray = new T[attLength];
            prmArray[0] = newNode.opGetItem();
            for (int i = 1; i <= attLength - 1; i++)
            {
                prmArray[i] = attItems[i - 1];
            }
            attItems = prmArray;
            attMiddle.opSetItem(attItems[attLength / 2]);
            attLastQuarter.opSetItem(attItems[(attLength / 2) + (attLength / 4)]);
            attFirst = newNode;
            return true;
        }
        #endregion
    }
}
