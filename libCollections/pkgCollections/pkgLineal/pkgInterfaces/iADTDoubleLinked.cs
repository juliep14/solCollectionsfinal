using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iADTDoubleLinked<T> where T : IComparable<T>
    {
        #region Getters
        clsDoubleLinkedNode<T> opGetFirst();
        clsDoubleLinkedNode<T> opGetMiddle();
        clsDoubleLinkedNode<T> opGetLast(); 
        #endregion
        #region Setters
        bool opSetFirst(clsDoubleLinkedNode<T> prmNode);
        bool opSetMiddle(clsDoubleLinkedNode<T> prmNode);
        bool opSetLast(clsDoubleLinkedNode<T> prmNode); 
        #endregion
    }
}
