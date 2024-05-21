using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iQueue<T> where T:IComparable<T>
    {
        #region Operations
        #region CRUDs
        bool opPush(T prmItem);
        bool opPop(ref T prmItem);
        bool opPeek(ref T prmItem);
        #endregion 
        #endregion
    }
}
