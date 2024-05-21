using System;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorQueue<T> : clsADTVector<T>, iQueue<T> where T : IComparable<T>
    {
        #region Attributes
        //protected T[] attItems = new T[100];
        #endregion
        #region Operations
        #region Builders
        public clsVectorQueue()
        {

        }
        public clsVectorQueue(int prmCapacity)
        {
            try
            {
                if (prmCapacity == attMaxCapacity) attGrowingFactor = 0;
                if (prmCapacity < 0) prmCapacity = 0;
                if (prmCapacity == 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                    attGrowingFactor = 100;
                }
                if (prmCapacity == attMaxCapacity - 1)
                {
                    attTotalCapacity = prmCapacity;
                }
                attItems = new T[prmCapacity];
                attTotalCapacity = prmCapacity;
            }
            catch
            {
                attTotalCapacity = 100;
                attMaxCapacity = int.MaxValue / 16;
                attItems = new T[100];
                attItsFlexible = false;
                attGrowingFactor = 100;
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
                return true;
            }
        }
        public bool opPop(ref T prmItem)
        {
            if (attLength == 0)
            {
                return false;
            }
            T[] prmArray = new T[attTotalCapacity];
            if (attTotalCapacity == attLength)
            {
                prmItem = attItems[0];
                prmArray[attLength - 1] = attItems[attLength - 1];
                for (int i = 0; i < attLength - 1; i++)
                {
                    attItems[i] = attItems[i + 1];
                }
                attLength--;
                return true;
            }
            else
            {
                prmItem = attItems[0];
                prmArray[attLength] = attItems[attLength];
                for (int i = 0; i < attLength; i++)
                {
                    prmArray[i] = attItems[i + 1];
                }
                attItems = prmArray;
                attLength--;
                return true;
            }
        }
        public bool opPush(T prmItem)
        {
            if (attLength == attTotalCapacity)
            {
                return false;
            }
            if (attMaxCapacity == attTotalCapacity)
            {
                attItems[attTotalCapacity - 1] = prmItem;
                attLength++;
                return true;
            }
            attItems[attLength] = prmItem;
            attLength++;
            return true;
        }
        #endregion 
        #endregion
    }
}