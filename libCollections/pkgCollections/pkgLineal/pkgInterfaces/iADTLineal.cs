using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iADTLineal<T> where T : IComparable<T>
    {
        #region Operations
        #region Getters
        int opGetLength();
        #endregion
        #region Query
        int opFind(T prmItem);
        bool opExists(T prmItem);
        bool opItsEmpty();
        bool opIsValid(int prmIdx);
        bool opItsOrderedAscending();
        bool opItsOrderedDescending();
        #endregion
        #region Serialize/Deserialize
        T[] opToArray();
        string opToString();
        bool opToItems(T[] prmArray);
        //bool opToItems(T[] prmArray, bool prmItsOrderedAscending);
        #endregion
        #region CRUDs
        bool opModify(int prmIdx, T prmItem);
        bool opRetrieve(int prmIdx, ref T prmItem);
        bool opBubbleSort(bool prmByAscending);
        bool opCocktailSort(bool prmByAscending);
        bool opInsertSort(bool prmByAscending);
        bool opMergeSort(bool prmByAscending);
        bool opQuickSort(bool prmByAscending);

        #endregion 
        #endregion
    }
}
