using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgIterators;
using System;
using System.Linq;

namespace pkgServices.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTLineal<T> : clsIterator<T>, iADTLineal<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attTotalCapacity = 100;
        protected bool attItsOrderedAscending = false;
        protected bool attItsOrderedDescending = false;
        protected static int attMaxCapacity = int.MaxValue / 32;
        protected T[] attItems = new T[100];
        #endregion
        #region Builders
        public clsADTLineal()
        {
        }
        public clsADTLineal(int attLength)
        {
            try
            {
                if (attLength < 0) attLength = 0;
                T[] attItems = new T[attLength];
            }
            catch
            {
                T[] attItems = new T[attLength];
                attLength = 0;
                attItsOrderedAscending = false;
                attItsOrderedDescending = false;
            }
        }
        #endregion
        #region Operations
        #region Query
        public bool opItsEmpty()
        {
            throw new NotImplementedException();
        }
        public int opFind(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opExists(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opItsOrderedAscending()
        {
            if (attItems == null) return false;
            return attItsOrderedAscending;
        }
        public bool opItsOrderedDescending()
        {
            if (attItems == null) return false;
            return attItsOrderedDescending;

        }
        #endregion
        #region Getters
        public int opGetLength()
        {
            return attLength;
        }
        public static int opGetMaxCapacity()
        {
            return attMaxCapacity;
        }
        #endregion
        #region Serialize/Deserialize
        public virtual T[] opToArray()
        {
            if (attItems == null)
            {
                return null;
            }
            if (attLength == 0)
            {
                T[] prmArray = new T[100];
                for (int i = 0; i < 100; i++)
                {
                    prmArray[i] = attItems[i];
                }
                return prmArray;
            }
            if (attLength == attItems.Length / 2)
            {
                T[] prmarray = new T[attItems.Length];
                for (int i = 0; i < attItems.Length; i++)
                {
                    prmarray[i] = attItems[i];
                }
                return prmarray;
            }
            if (attLength != attItems.Length)
            {
                T[] array = new T[attLength + 1];
                for (int i = 0; i < attLength + 1; i++)
                {
                    array[i] = attItems[i];
                }
                return array;
            }
            T[] result = new T[attLength];
            for (int i = 0; i < attLength; i++)
            {
                result[i] = attItems[i];
            }
            return result;
        }
        public String opToString()
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray)
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray, int prmItemsCount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region CRUDs
        public virtual bool opModify(int prmIdx, T prmItem)
        {
            if (!opGo(prmIdx)) return false;
            return opSetCurrentItem(prmItem);
        }
        public virtual bool opRetrieve(int prmIdx, ref T prmItem)
        {
            if (attItems == null) return false;
            if (prmIdx >= 0 && prmIdx < attLength)
            {
                prmItem = attItems[prmIdx];
                return true;
            }
            else
            {
                prmItem = default(T);
                return false;
            }
        }
        public bool opReverse()
        {
            T[] prmArray = new T[attLength];
            prmArray.Reverse();
            return true;
        }


        #endregion
        #region Sorting
        public bool opBubbleSort(bool prmByAscending)
        {
            if (prmByAscending)
            {
                if (attLength == 0)
                {
                    attItems = null;
                    return false;
                }
                int lenght = attLength;
                attItems = this.opToArray();
                for (int i = 0; i < attLength - 1; i++)
                {
                    for (int j = 0; j < lenght - i - 1; j++)
                    {
                        if (attItems[j].CompareTo(attItems[j + 1]) > 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j + 1];
                            attItems[j + 1] = temp;
                        }
                    }
                }
                this.opToItems(attItems, attLength);
                attItsOrderedAscending = true;
                attItsOrderedDescending = false;
                return true;
            }
            else
            {
                if (attLength == 0)
                {
                    attItems = null;
                    return false;
                }
                int lenght = attLength;
                attItems = this.opToArray();
                for (int i = 0; i < lenght - 1; i++)
                {
                    for (int j = 0; j < lenght - i - 1; j++)
                    {
                        if (attItems[j].CompareTo(attItems[j + 1]) < 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j + 1];
                            attItems[j + 1] = temp;
                        }
                    }
                }
                this.opToItems(attItems, attLength);
                attItsOrderedAscending = false;
                attItsOrderedDescending = true;
                return true;
            }
        }
        public bool opCocktailSort(bool prmByAscending)
        {
            /*if (attItems == null || attLength <= 1) return false;
            for (int i = 0; i < attLength / 2; i++)
            {
                bool swapped = false;
                for (int j = i; j < attLength - i - 1; j++)
                {
                    if ((prmByAscending && attItems[j].CompareTo(attItems[j + 1]) > 0) ||
                        (!prmByAscending && attItems[j].CompareTo(attItems[j + 1]) < 0))
                    {
                        T temp = attItems[j];
                        attItems[j] = attItems[j + 1];
                        attItems[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break; 
                for (int j = attLength - 2 - i; j > i; j--)
                {
                    if ((prmByAscending && attItems[j].CompareTo(attItems[j - 1]) < 0) ||
                        (!prmByAscending && attItems[j].CompareTo(attItems[j - 1]) > 0))
                    {
                        T temp = attItems[j];
                        attItems[j] = attItems[j - 1];
                        attItems[j - 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) break; 
            }
            this.opToItems(attItems, attLength);
            attItsOrderedAscending = prmByAscending;
            attItsOrderedDescending = !prmByAscending;
            return true;*/
            if (prmByAscending)
            {
                if (attLength == 0)
                {
                    attItems = null;
                    return false;
                }
                attItems = this.opToArray();
                int length = attLength;
                for (int i = 0; i < length - 1; i++)
                {
                    bool swapped = false;
                    for (int j = i; j < length - i - 1; j++)
                    {
                        if (attItems[j].CompareTo(attItems[j + 1]) > 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j + 1];
                            attItems[j + 1] = temp;
                            swapped = true;
                        }
                    }
                    if (!swapped) break;

                    swapped = false;
                    for (int j = length - i - 2; j > i; j--)
                    {
                        if (attItems[j].CompareTo(attItems[j - 1]) < 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j - 1];
                            attItems[j - 1] = temp;
                            swapped = true;
                        }
                    }
                    if (!swapped) break;
                }
                this.opToItems(attItems, attLength);
                attItsOrderedAscending = true;
                return true;
            }
            else
            {
                if (attLength == 0)
                {
                    attItems = null;
                    return false;
                }
                attItems = this.opToArray();
                int lenght = attLength;
                int length = attLength;
                for (int i = 0; i < length - 1; i++)
                {
                    bool swapped = false;
                    for (int j = i; j < length - i - 1; j++)
                    {
                        if (attItems[j].CompareTo(attItems[j + 1]) < 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j + 1];
                            attItems[j + 1] = temp;
                            swapped = true;
                        }
                    }
                    if (!swapped) break;

                    swapped = false;
                    for (int j = length - i - 2; j > i; j--)
                    {
                        if (attItems[j].CompareTo(attItems[j - 1]) > 0)
                        {
                            T temp = attItems[j];
                            attItems[j] = attItems[j - 1];
                            attItems[j - 1] = temp;
                            swapped = true;
                        }
                    }
                    if (!swapped) break;
                }
                this.opToItems(attItems, attLength);
                attItsOrderedDescending = true;
                return true;
            }
        }
        public bool opInsertSort(bool prmByAscending)
        {
            {
                if (attItems == null || attLength <= 1)
                {

                    attItems = null;
                    return false;
                }

                for (int i = 1; i < attLength; i++)
                {
                    T key = attItems[i];
                    int j = i - 1;

                    while (j >= 0 && ((prmByAscending && attItems[j].CompareTo(key) > 0) ||
                                      (!prmByAscending && attItems[j].CompareTo(key) < 0)))
                    {
                        attItems[j + 1] = attItems[j];
                        j--;
                    }

                    attItems[j + 1] = key;
                }

                this.opToItems(attItems, attLength);
                attItsOrderedAscending = prmByAscending;
                attItsOrderedDescending = !prmByAscending;
                return true;
            }
        }
        public bool opMergeSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            return true;
        }
        public bool opQuickSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            //if (attItems == null || attLength <= 1) return false;
            return true;
        }
        #endregion
        #endregion
    }
}
