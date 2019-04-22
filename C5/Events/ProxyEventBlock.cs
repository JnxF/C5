// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;

namespace C5
{
    /// <summary>
    /// Tentative, to conserve memory in GuardedCollectionValueBase
    /// This should really be nested in Guarded collection value, only have a guardereal field
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    internal sealed class ProxyEventBlock<T>
    {
        ICollectionValue<T> proxy, real;

        internal ProxyEventBlock(ICollectionValue<T> proxy, ICollectionValue<T> real)
        { this.proxy = proxy; this.real = real; }

        event CollectionChangedHandler<T> collectionChanged;
        CollectionChangedHandler<T> collectionChangedProxy;
        internal event CollectionChangedHandler<T> CollectionChanged
        {
            add
            {
                if (collectionChanged == null)
                {
                    if (collectionChangedProxy == null)
                        collectionChangedProxy = delegate (object sender) { collectionChanged(proxy); };
                    real.CollectionChanged += collectionChangedProxy;
                }
                collectionChanged += value;
            }
            remove
            {
                collectionChanged -= value;
                if (collectionChanged == null)
                    real.CollectionChanged -= collectionChangedProxy;
            }
        }

        event CollectionClearedHandler<T> collectionCleared;
        CollectionClearedHandler<T> collectionClearedProxy;
        internal event CollectionClearedHandler<T> CollectionCleared
        {
            add
            {
                if (collectionCleared == null)
                {
                    if (collectionClearedProxy == null)
                        collectionClearedProxy = delegate (object sender, ClearedEventArgs e) { collectionCleared(proxy, e); };
                    real.CollectionCleared += collectionClearedProxy;
                }
                collectionCleared += value;
            }
            remove
            {
                collectionCleared -= value;
                if (collectionCleared == null)
                    real.CollectionCleared -= collectionClearedProxy;
            }
        }

        event ItemsAddedHandler<T> itemsAdded;
        ItemsAddedHandler<T> itemsAddedProxy;
        internal event ItemsAddedHandler<T> ItemsAdded
        {
            add
            {
                if (itemsAdded == null)
                {
                    if (itemsAddedProxy == null)
                        itemsAddedProxy = delegate (object sender, ItemCountEventArgs<T> e) { itemsAdded(proxy, e); };
                    real.ItemsAdded += itemsAddedProxy;
                }
                itemsAdded += value;
            }
            remove
            {
                itemsAdded -= value;
                if (itemsAdded == null)
                    real.ItemsAdded -= itemsAddedProxy;
            }
        }

        event ItemInsertedHandler<T> itemInserted;
        ItemInsertedHandler<T> itemInsertedProxy;
        internal event ItemInsertedHandler<T> ItemInserted
        {
            add
            {
                if (itemInserted == null)
                {
                    if (itemInsertedProxy == null)
                        itemInsertedProxy = delegate (object sender, ItemAtEventArgs<T> e) { itemInserted(proxy, e); };
                    real.ItemInserted += itemInsertedProxy;
                }
                itemInserted += value;
            }
            remove
            {
                itemInserted -= value;
                if (itemInserted == null)
                    real.ItemInserted -= itemInsertedProxy;
            }
        }

        event ItemsRemovedHandler<T> itemsRemoved;
        ItemsRemovedHandler<T> itemsRemovedProxy;
        internal event ItemsRemovedHandler<T> ItemsRemoved
        {
            add
            {
                if (itemsRemoved == null)
                {
                    if (itemsRemovedProxy == null)
                        itemsRemovedProxy = delegate (object sender, ItemCountEventArgs<T> e) { itemsRemoved(proxy, e); };
                    real.ItemsRemoved += itemsRemovedProxy;
                }
                itemsRemoved += value;
            }
            remove
            {
                itemsRemoved -= value;
                if (itemsRemoved == null)
                    real.ItemsRemoved -= itemsRemovedProxy;
            }
        }

        event ItemRemovedAtHandler<T> itemRemovedAt;
        ItemRemovedAtHandler<T> itemRemovedAtProxy;
        internal event ItemRemovedAtHandler<T> ItemRemovedAt
        {
            add
            {
                if (itemRemovedAt == null)
                {
                    if (itemRemovedAtProxy == null)
                        itemRemovedAtProxy = delegate (object sender, ItemAtEventArgs<T> e) { itemRemovedAt(proxy, e); };
                    real.ItemRemovedAt += itemRemovedAtProxy;
                }
                itemRemovedAt += value;
            }
            remove
            {
                itemRemovedAt -= value;
                if (itemRemovedAt == null)
                    real.ItemRemovedAt -= itemRemovedAtProxy;
            }
        }
    }
}