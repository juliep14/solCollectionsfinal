using pkgServices.pkgCollections.pkgNodes.pkgInterfaces;
using System;

namespace pkgServices.pkgCollections.pkgNodes
{
    public class clsLinkedNode<T> : clsNode<T>, iLinkedNode<T> where T : IComparable<T>
    {
        #region Attributes
        public clsLinkedNode<T> attNext;
        #endregion
        #region Operations
        #region Builders
        public clsLinkedNode()
        {
        }
        public clsLinkedNode(T prmItem)
        {
            attItem = prmItem;
        }
        #endregion
        #region Getters
        public clsLinkedNode<T> opGetNext()
        {
            return attNext;
        }
        #endregion
        #region Setters
        public bool opSetNext(clsLinkedNode<T> prmNode)
        {
            return opGetNext() == prmNode;
        }
        #endregion 
        #endregion
    }
}
