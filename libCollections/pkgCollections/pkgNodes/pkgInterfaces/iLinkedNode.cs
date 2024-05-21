using System;

namespace pkgServices.pkgCollections.pkgNodes.pkgInterfaces
{
    public interface iLinkedNode<T> where T : IComparable<T>
    {
        #region Getters
        clsLinkedNode<T> opGetNext();
        #endregion
        #region Setters
        bool opSetNext(clsLinkedNode<T> prmNode); 
        #endregion
    }
}
