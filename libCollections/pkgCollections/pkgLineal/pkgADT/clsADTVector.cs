using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT
{
    public class clsADTVector<T> : clsADTLineal<T>, iADTVector<T> where T : IComparable<T>
    {
        #region Attributes
        //protected int attTotalCapacity = 100;
        protected bool attItsFlexible = false;
        protected int attGrowingFactor = 100;
        #endregion
        #region Operations
        #region Builders
        protected clsADTVector()
        {

        }
        protected clsADTVector(int prmCapacity)
        {
            try
            {
                if (prmCapacity == attMaxCapacity) attGrowingFactor = 0;
                attTotalCapacity = prmCapacity;
                attItems = new T[prmCapacity];
            }
            catch
            {
                base.attLength = 0;
                attItsOrderedAscending = false;
                attItsOrderedDescending = false;
                attTotalCapacity = 100;
                attItems = new T[100];
                attItsFlexible = false;
                attGrowingFactor = 100;
            }
        }
        #endregion
        #region Getters
        public int opGetTotalCapacity()
        {
            if (attTotalCapacity > attMaxCapacity)
            {
                attTotalCapacity = 100;
                return attTotalCapacity;
            }
            if (attTotalCapacity < 0)
            {
                attTotalCapacity = 100;
                return attTotalCapacity;
            }
            if (attTotalCapacity == attMaxCapacity)
            {
                attTotalCapacity = attMaxCapacity;
                return attTotalCapacity;
            }
            return attTotalCapacity;
        }
        public int opGetAvailableCapacity()
        {
            return attTotalCapacity - attLength;
        }
        public int opGetGrowingFactor()
        {
            if (attItsFlexible)
            {
                attGrowingFactor = 100;
                return attGrowingFactor;
            }
            else
            {
                if (attMaxCapacity == attTotalCapacity)
                {
                    attGrowingFactor = 0;
                    return attGrowingFactor;
                }
                if ((attMaxCapacity - 1) == attTotalCapacity)
                {
                    attGrowingFactor = 1;
                    return attGrowingFactor;
                }
                if (attTotalCapacity > 0)
                {
                    attGrowingFactor = 100;
                    return attGrowingFactor;
                }
                attGrowingFactor = attTotalCapacity - attLength;
                return attGrowingFactor;
            }
        }
        /*public static int opGetMaxCapacity()
        {
            return attMaxCapacity;
        }*/
        #endregion
        #region Setters
        public bool opSetGrowingFactor(int prmValue)
        {
            attGrowingFactor = prmValue;
            return true;
        }
        public bool opSetCapacity(int prmValue)
        {
            attTotalCapacity = prmValue;
            return true;
        }
        public bool opSetFlexible()
        {
            if (attTotalCapacity == attMaxCapacity - 1)
            {
                T[] prmArray = new T[attMaxCapacity];
                Array.Copy(attItems, prmArray, attTotalCapacity);
                for (int i = attMaxCapacity - 1; i < attMaxCapacity; i++)
                {
                    prmArray[i] = default(T);
                }
                //attLength = attTotalCapacity-1;
                attItems = prmArray;
                attTotalCapacity = attMaxCapacity;
                attItsFlexible = false;
                return attItsFlexible;
            }
            T[] newArray = new T[attTotalCapacity + 100];
            Array.Copy(attItems, newArray, attTotalCapacity);
            for (int i = attTotalCapacity; i < attTotalCapacity + 100; i++)
            {
                newArray[i] = default(T);
            }
            attItems = newArray;
            attTotalCapacity = attTotalCapacity + 100;
            attItsFlexible = true;
            return attItsFlexible;
        }
        public bool opSetInflexible()
        {
            attItsFlexible = false;
            return false;
        }
        #endregion
        #region Query
        public bool opItsFull()
        {
            throw new NotImplementedException();
        }
        public bool opItsFlexible()
        {
            if (attItsFlexible) return true;
            else return false;
        }
        #endregion
        #region Serialize/Deserialize
        public override T[] opToArray()
        {
            if (attLength == attMaxCapacity)
            {
                T[] prmArray = new T[attTotalCapacity];
                for (int i = 0; i < attTotalCapacity; i++)//-1
                {
                    prmArray[i] = attItems[i];
                }
                return prmArray;
            }
            if (attTotalCapacity == attMaxCapacity)
            {
                T[] prmArray = new T[attTotalCapacity];
                for (int i = 0; i < attTotalCapacity - 1; i++)
                {
                    prmArray[i] = attItems[i];
                }
                return prmArray;
            }
            T[] result = new T[attTotalCapacity];
            for (int i = 0; i < attTotalCapacity; i++)
            {
                result[i] = attItems[i];
            }
            return result;
        }
        public override bool opToItems(T[] prmArray)
        {
            if (prmArray == null) return false;
            if (prmArray.Length == 0) return false;
            if (attItems.Length > attMaxCapacity) return false;
            attItems = prmArray;
            attLength = attItems.Length;
            attTotalCapacity = attItems.Length;
            if (attMaxCapacity - attLength > 100)
                attGrowingFactor = attMaxCapacity - attLength;
            attItsOrderedAscending = false;
            attItsOrderedDescending = false;
            return true;
        }
        public override bool opToItems(T[] prmArray, int prmItemsCount)
        {
            if (prmArray == null) return false;
            if (prmArray.Length == 0) return false;
            if (prmArray.Length > attMaxCapacity) return false;
            if (prmItemsCount < 0) return false;
            attItems = prmArray;
            attLength = prmItemsCount;
            attTotalCapacity = prmArray.Length;
            if (attMaxCapacity - attLength < 100)
                attGrowingFactor = attMaxCapacity - attLength;
            return true;
        }
        #endregion
        #region Iterator
        public override bool opGo(int prmIdx)
        {
            if (!opIsValid(prmIdx)) return false;
            attCurrentIdx = prmIdx;
            attCurrentItem = attItems[attCurrentIdx];
            return true;
        }
        public override bool opGoFirst()
        {
            if (!opIsValid(0)) return false;
            attCurrentIdx = 0;
            attCurrentItem = attItems[attCurrentIdx];
            return true;
        }
        public override void opGoBack()
        {
            base.opGoBack();
            attCurrentItem = attItems[attCurrentIdx];
        }
        public override void opGoForward()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
