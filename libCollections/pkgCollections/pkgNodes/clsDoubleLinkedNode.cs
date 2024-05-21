using pkgServices.pkgCollections.pkgNodes.pkgInterfaces;
using System;

namespace pkgServices.pkgCollections.pkgNodes
{
    public class clsDoubleLinkedNode<T> : clsNode<T>, iDoubleLinkedNode<T> where T : IComparable<T>
    {
        #region Attributes
        public clsDoubleLinkedNode<T> attNext;
        public clsDoubleLinkedNode<T> attPrevious;
        #endregion
        #region Operations
        #region Builders
        public clsDoubleLinkedNode() { }
        public clsDoubleLinkedNode(T prmItem)
        {
            attItem = prmItem;
        }
        #endregion
        #region Getters
        public clsDoubleLinkedNode<T> opGetNext()
        {
            return attNext;
        }
        public clsDoubleLinkedNode<T> opGetPrevious()
        {
            return attPrevious;
        }
        #endregion
        #region Setters
        public bool opSetNext(clsDoubleLinkedNode<T> prmNode)
        {
            attNext = prmNode;
            return true;
        }
        public bool opSetPrevious(clsDoubleLinkedNode<T> prmNode)
        {
            attPrevious = prmNode;
            return true;
        }
        #endregion
        #endregion
    }
}
