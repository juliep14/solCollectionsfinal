using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iIterator<T> where T : IComparable<T>
    {
        #region Operations
        #region Movement
        bool opGoFirst();
        bool opGoPrevious();
        bool opGoMiddle();
        bool opGoNext();
        bool opGoLast();
        bool opGo(int prmIdx);
        void opGoBack();
        void opGoForward();
        #endregion
        #region Getters
        int opGetLenght();
        int opGetCurrentIdx();
        T opGetCurrentItem();
        #endregion
        #region Setters
        bool opSetCurrentItem(T prmContent);
        #endregion
        #region Query
        bool opIsValid(int prmIdx);
        bool opIsThereNext();
        bool opIsTherePrevious();
        #endregion 
        #endregion
    }
}
