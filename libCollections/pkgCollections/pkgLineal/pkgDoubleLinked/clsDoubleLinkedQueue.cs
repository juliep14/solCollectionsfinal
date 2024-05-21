using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgDoubleLinked
{
    public class clsDoubleLinkedQueue<T> : clsADTDoubleLinked<T>, iQueue<T> where T : IComparable<T>
    {
        #region Builders
        public clsDoubleLinkedQueue()
        {
            attLength = 0;
            attItems = null;
        } 
        #endregion
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            if (attItems == null)
            {
                T[] prmArray = new T[100];
                attItems = prmArray;
                return false;
            }
            attLastQuarter.opSetItem(attItems[attLength-2]);
            prmItem = attItems[0];
            return true;
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
            attFirstQuarter.opSetItem(attItems[attLength / 4]);
            attLastQuarter.opSetItem(attItems[1]);
            //attLast.opSetItem(attItems[attLength - 1]);
            return true;
        }
        public bool opPush(T prmItem)
        {
            clsDoubleLinkedNode<T> newNode = new clsDoubleLinkedNode<T>(prmItem);
            if (attItems == null)
            {
                attLength++;
                T[] array = new T[attLength];
                attItems = array;
                array[0] = newNode.opGetItem();
                attFirst = newNode;
                attFirstQuarter = newNode;
                attMiddle = newNode;
                attLastQuarter = newNode;
                attLast = newNode;
                return true;
            }
            attLength++;
            T[] prmArray = new T[attLength];
            prmArray[attLength - 1] = newNode.opGetItem();
            for (int i = 0; i <= attLength - 2; i++)
            {
                prmArray[i] = attItems[i];
            }
            attItems = prmArray;
            attLast = newNode;
            attItems = prmArray;
            return true;
        }
        #endregion
        public T opGetItemAtIndex() { return attLast.opGetItem(); }//return attItems[3];
    }
}
