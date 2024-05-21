using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iList<T> where T : IComparable<T>
    {
        #region Operations
        #region CRUDs
        bool opAdd(T prmItem);
        bool opInsert(int Idx, T prmItem);
        bool opRemove(int Idx, ref T prmItem);
        #endregion
        #region Query
        int opFind(T Item);
        bool opExists(T Item);
        #endregion 
        #endregion
    }
}
