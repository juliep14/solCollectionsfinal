using System;

namespace pkgServices.pkgCollections.pkgNodes.pkgInterfaces
{
    public interface iNode<T> where T : IComparable<T>
    {
        T opGetItem();
        bool opSetItem(T prmContent);
    }
}
