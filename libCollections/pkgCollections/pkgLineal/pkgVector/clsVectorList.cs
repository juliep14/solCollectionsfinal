using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorList<T> : clsADTVector<T>, iList<T> where T : IComparable<T>
    {
        #region Attributes
        #endregion
        #region Builders
        public clsVectorList()
        {

        }
        public clsVectorList(int prmCapacity)
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
                if (prmCapacity == attMaxCapacity)
                {
                    prmCapacity = attMaxCapacity;
                    attTotalCapacity = attMaxCapacity;
                    attGrowingFactor = 0;
                }
                if (prmCapacity == (attMaxCapacity - 1))
                {
                    attGrowingFactor = 1;
                    attTotalCapacity = (attMaxCapacity - 1);
                }

                if (attLength < 0) attLength = 0;
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
        public bool opAdd(T prmItem)
        {
            if (attLength >= attTotalCapacity)
            {
                return false;
            }
            if (attTotalCapacity == attLength)
            {
                attItems[attTotalCapacity - 1] = prmItem;
                attLength++;
                return true;
            }
            else
            {
                attItems[attLength] = prmItem;
                attLength++;
                return true;
            }
        }
        public bool opInsert(int prmIdx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opRemove(int prmIdx, ref T prmItem)
        {
            if (attLength == 0) return false;
            if (prmIdx < 0 || prmIdx == attLength)
            {
                attLength--;
                return false;
            }
            prmItem = attItems[prmIdx];
            if (attLength == attTotalCapacity)
            {
                T[] prmArray = new T[attTotalCapacity];
                prmArray = attItems;
                for (int i = prmIdx; i < attLength; i++)
                {
                    prmArray[i] = attItems[i + 1];
                }
                attItems = prmArray;
                attLength--;
                return true;
            }
            else
            {
                if (prmIdx == attLength - 1)
                {
                    T[] prmArray = new T[attTotalCapacity];
                    prmArray = attItems;
                    attItems = prmArray;
                    attLength--;
                    return true;
                }
                else
                {
                    T[] prmArray = new T[attTotalCapacity];
                    prmArray = attItems;
                    for (int i = prmIdx; i < attTotalCapacity - 1; i++)
                    {
                        prmArray[i] = attItems[i + 1];
                    }
                    attItems = prmArray;
                    attLength--;
                    return true;
                }
            }
        }
        #endregion
        #region Query
        public bool opModify(ref int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opRemove(ref int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}