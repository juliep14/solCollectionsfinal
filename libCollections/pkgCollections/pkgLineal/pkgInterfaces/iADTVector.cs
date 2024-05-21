using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iADTVector<T> where T : IComparable<T>
    {
        #region Operations
        #region Getters
        int opGetTotalCapacity();
        int opGetAvailableCapacity();
        int opGetGrowingFactor();
        #endregion
        #region Setters
        bool opSetGrowingFactor(int prmValue);
        bool opSetCapacity(int prmValue);
        bool opSetFlexible();
        bool opSetInflexible();
        #endregion
        #region Query
        bool opItsFull();
        bool opItsFlexible();
        #endregion 
        #endregion
    }
}
