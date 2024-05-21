using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iADTLinked<T> where T : IComparable<T>
    {
        #region Operations
        #region Getters
        clsLinkedNode<T> opGetFirst();
        clsLinkedNode<T> opGetMiddle();
        clsLinkedNode<T> opGetLast();
        #endregion
        #region Setters
        bool opSetFirst(clsLinkedNode<T> prmNode);
        bool opSetMiddle(clsLinkedNode<T> prmNode);
        bool opSetLast(clsLinkedNode<T> prmNode);
        #endregion 
        #endregion
    }
}
