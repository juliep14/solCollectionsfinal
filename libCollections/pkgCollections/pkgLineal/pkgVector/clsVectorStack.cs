using System;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorStack<T> : clsADTVector<T>, iStack<T> where T : IComparable<T>
    {
        #region Builders
        public clsVectorStack()
        {

        }
        public clsVectorStack(int prmCapacity) : base(prmCapacity)
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
                    attGrowingFactor = 100;
                }
                if (attLength < 0) attLength = 0;
                attItems = new T[prmCapacity];
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
            if (attLength != attTotalCapacity)
            {
                prmItem = attItems[attTotalCapacity - (attLength + 1)];
                for (int i = 0; i < attLength; i++)
                {
                    attItems[i] = attItems[i + 1];
                }
                attLength--;
                return true;
            }
            if (attLength == attTotalCapacity)
            {
                prmItem = attItems[attTotalCapacity - attLength];
                for (int i = 0; i < attLength - 1; i++)
                {
                    attItems[i] = attItems[i + 1];
                }
                attLength--;
                return true;
            }
            return true;
        }
        public bool opPush(T prmItem)
        {
            if (attLength == attTotalCapacity)
            {
                return false;
            }
            if (attTotalCapacity == attMaxCapacity) 
            {
                attItems[0] = prmItem;
                attLength = attMaxCapacity;
                return true;
            }
            if (attItsFlexible)
            {
                for (int i = attLength; i >= 1; i--)
                {
                    attItems[i] = attItems[i - 1];
                }
                attItems[0] = prmItem;
                if (attLength < attTotalCapacity) attLength++;
                return true;
            }
            else 
            {
                for (int i = attLength; i >= 1; i--)
                {
                    attItems[i] = attItems[i - 1];
                }
                attItems[0] = prmItem;
                if (attLength < attTotalCapacity) attLength++;
                return true;
            }
        }
        #endregion
    }
}
