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
        public virtual T[] opToArray() //O(n)
        {
            if (attItems == null) //O(1)
            {
                return null;
            } 
            if (attLength == 0) //O(n)
            {
                T[] prmArray = new T[100];
                for (int i = 0; i < 100; i++)
                {
                    prmArray[i] = attItems[i];
                }
                return prmArray;
            } 
            if (attLength == attItems.Length / 2) //O(n)
            {
                T[] prmarray = new T[attItems.Length];
                for (int i = 0; i < attItems.Length; i++)
                {
                    prmarray[i] = attItems[i];
                }
                return prmarray;
            }
            if (attLength != attItems.Length) //O(n)
            {
                T[] array = new T[attLength + 1];
                for (int i = 0; i < attLength + 1; i++)
                {
                    array[i] = attItems[i];
                }
                return array;
            }
            T[] result = new T[attLength];
            for (int i = 0; i < attLength; i++) //O(n)
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
        public virtual bool opModify(int prmIdx, T prmItem) //O(1)
        {
            if (!opGo(prmIdx)) return false; //o1
            return opSetCurrentItem(prmItem);
        }
        public virtual bool opRetrieve(int prmIdx, ref T prmItem) //O(1)
        {
            if (attItems == null) return false; //O(1)
            if (prmIdx >= 0 && prmIdx < attLength) //O(1)
            {
                prmItem = attItems[prmIdx]; //O(1)
                return true;
            }
            else
            {
                prmItem = default(T);
                return false;
            }
        }
        public bool opReverse()//O(n)
        {
            T[] prmArray = new T[attLength];//O(1)
            prmArray.Reverse();//O(n)  implica iterar sobre el arreglo y cambiar de posición los elementos
            return true;
        }
        #endregion
        #region Sorting
        public bool opBubbleSort(bool prmByAscending) //O(N2)n²
        {
            if (attLength == 0) //1
            {
                attItems = null;
                return false;
            }
            attItems = this.opToArray();
            for (int i = 0; i < attLength - 1; i++) //n
            {
                for (int j = 0; j < attLength - i - 1; j++)//n
                {
                    if ((prmByAscending && attItems[j].CompareTo(attItems[j + 1]) > 0) || (!prmByAscending && attItems[j].CompareTo(attItems[j + 1]) < 0))
                    {
                        T temp = attItems[j];
                        attItems[j] = attItems[j + 1];
                        attItems[j + 1] = temp;
                    }
                }
            }
            if (prmByAscending) attItsOrderedAscending = true;
            else attItsOrderedDescending = true;
            this.opToItems(attItems, attLength);
            return true;

        }
        public bool opCocktailSort(bool prmByAscending) //O(n²)
        {
            if (attItems == null || attLength <= 1)//1
            {
                attItems = null;
                return false;
            }
            for (int i = 0; i < attLength / 2; i++) //o(n)
            {
                bool swapped = false;
                for (int j = i; j < attLength - i - 1; j++) //o(n)
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
            return true;
        }
        public bool opInsertSort(bool prmByAscending)//O(n²)
        {
            {
                if (attItems == null || attLength <= 1)//1
                {
                    attItems = null;
                    return false;
                }
                for (int i = 1; i < attLength; i++) //n
                {
                    T key = attItems[i];
                    int j = i - 1;

                    while (j >= 0 && ((prmByAscending && attItems[j].CompareTo(key) > 0) || (!prmByAscending && attItems[j].CompareTo(key) < 0)))//n
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
        public bool opMergeSort(bool prmByAscending) // O(nlogn)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }
            this.opToItems(attItems, attLength);
            attItsOrderedAscending = prmByAscending;
            attItsOrderedDescending = !prmByAscending;

            MergeSort(attItems, 0, attLength - 1, prmByAscending);
            return true;
        }
        private void MergeSort(T[] attItems, int left, int right, bool attItsOrderedAscending) //O(n)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2; //n
                MergeSort(attItems, left, middle, attItsOrderedAscending);
                MergeSort(attItems, middle + 1, right, attItsOrderedAscending);
                Merge(attItems, left, middle, right, attItsOrderedAscending);
            }
        }
        private void Merge(T[] attItems, int left, int middle, int right, bool ascending)//O(nlogn)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;
            T[] leftArray = new T[n1];
            T[] rightArray = new T[n2];
            Array.Copy(attItems, left, leftArray, 0, n1);
            Array.Copy(attItems, middle + 1, rightArray, 0, n2);
            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2) //n
            {
                if ((ascending && leftArray[i].CompareTo(rightArray[j]) <= 0) || (!ascending && leftArray[i].CompareTo(rightArray[j]) >= 0))
                {
                    attItems[k] = leftArray[i];
                    i++;
                }
                else
                {
                    attItems[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                attItems[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                attItems[k] = rightArray[j];
                j++;
                k++;
            }
        }
        private void Swap(T[] attItems, int i, int j)
        {
            T temp = attItems[i];
            attItems[i] = attItems[j];
            attItems[j] = temp;
        }
        private int Partition(T[] attItems, int low, int high, bool ascending)
        {
            T pivot = attItems[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if ((ascending && attItems[j].CompareTo(pivot) < 0) || (!ascending && attItems[j].CompareTo(pivot) > 0))
                {
                    i++;
                    Swap(attItems, i, j);
                }
            }
            Swap(attItems, i + 1, high);
            return i + 1;
        }
        private void QuickSort(T[] attItems, int low, int high, bool ascending)
        {
            if (low < high)
            {
                int partition = Partition(attItems, low, high, ascending);
                QuickSort(attItems, low, partition - 1, ascending);
                QuickSort(attItems, partition + 1, high, ascending);
            }
        }
        public bool opQuickSort(bool prmByAscending)
        {
            if (attLength == 0)
            {
                attItems = null;
                return false;
            }

            QuickSort(attItems, 0, attLength - 1, prmByAscending);
            this.opToItems(attItems, attLength);
            attItsOrderedAscending = prmByAscending;
            attItsOrderedDescending = !prmByAscending;
            return true;
        }

        #endregion
    }
    #endregion

}

