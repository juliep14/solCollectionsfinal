using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgDoubleLinked
{
    public class clsDoubleLinkedStack<T> : clsADTDoubleLinked<T>, iStack<T> where T : IComparable<T>
    {
        #region Builders
        public clsDoubleLinkedStack()
        {
            attLength = 0;
            attItems = null;
        }
        #endregion
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            if (attItems == null) return false;
            prmItem = attItems[0];
            attLastQuarter.opSetItem(attItems[attLength - 1]);
            return true;
        }
        public bool opPop(ref T prmItem)
        {
            if(attItems== null) return false;
            prmItem = attItems[0];
            attLength--;
            T[] prmArray = new T[attLength];
            for (int i = 1; i <= attLength; i++)
            {
                prmArray[i-1] = attItems[i];
            }
            attItems = prmArray;
            attLastQuarter.opSetItem(attMiddle.opGetItem());
            return true;
        }
        public bool opPush(T prmItem)
        {
            clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmItem);
            if(attLength == attMaxCapacity-1) 
            {
                T[] prmarray = new T[attLength + 1];
                prmarray[0] = newNode.opGetItem();
                for (int i = 1; i <= attLength; i++)
                {
                    prmarray[i] = attItems[i - 1];
                }
                attItems = prmarray;
                attFirst = newNode;
                attLength++;
                return true;
            }
            if (attLength == 0) 
            {
                T[] prmArray = new T[attLength + 1];
                prmArray[0] = newNode.opGetItem();
                for (int i = 1; i <= attLength; i++)
                {
                    prmArray[i] = attItems[i - 1];
                }
                attItems = prmArray;
                attFirst = newNode;
                attFirstQuarter = newNode;
                attMiddle = newNode;
                attLastQuarter = newNode;
                attLast = newNode;
                attLength++;
                return true;
            }
            T[] array = new T[attLength + 1];
            array[0] = newNode.opGetItem();
            for (int i = 1; i <= attLength; i++)
            {
                array[i] = attItems[i - 1];
            }
            attItems = array;
            attLength++;
            attFirstQuarter.opSetItem(attItems[(attLength/2)-1]);
            attMiddle.opSetItem(attItems[attLength / 2]);
            //attLast.opSetItem(attItems[attLength - 1]);
            attLastQuarter.opSetItem(attItems[attLength - 2]);
            attFirst = newNode;
            attLength = attLength / 2;
            return true;
        }
        public T opGetItemIndex() { return attItems[3]; }
        #endregion
    }
}
