// This file is part of the C5 Generic Collection Library for C# and CLI
// See https://github.com/sestoft/C5/blob/master/LICENSE.txt for licensing details.

using System;

namespace C5
{
    /// <summary>
    /// Holds the real events for a collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    internal sealed class EventBlock<T>
    {
        internal EventTypeEnum events;

        event CollectionChangedHandler<T> collectionChanged;
        internal event CollectionChangedHandler<T> CollectionChanged
        {
            add
            {
                collectionChanged += value;
                events |= EventTypeEnum.Changed;
            }
            remove
            {
                collectionChanged -= value;
                if (collectionChanged == null)
                    events &= ~EventTypeEnum.Changed;
            }
        }
        internal void raiseCollectionChanged(object sender)
        { collectionChanged?.Invoke(sender); }

        event CollectionClearedHandler<T> collectionCleared;
        internal event CollectionClearedHandler<T> CollectionCleared
        {
            add
            {
                collectionCleared += value;
                events |= EventTypeEnum.Cleared;
            }
            remove
            {
                collectionCleared -= value;
                if (collectionCleared == null)
                    events &= ~EventTypeEnum.Cleared;
            }
        }
        internal void raiseCollectionCleared(object sender, bool full, int count)
        { collectionCleared?.Invoke(sender, new ClearedEventArgs(full, count)); }
        internal void raiseCollectionCleared(object sender, bool full, int count, int? start)
        { collectionCleared?.Invoke(sender, new ClearedRangeEventArgs(full, count, start)); }

        event ItemsAddedHandler<T> itemsAdded;
        internal event ItemsAddedHandler<T> ItemsAdded
        {
            add
            {
                itemsAdded += value;
                events |= EventTypeEnum.Added;
            }
            remove
            {
                itemsAdded -= value;
                if (itemsAdded == null)
                    events &= ~EventTypeEnum.Added;
            }
        }
        internal void raiseItemsAdded(object sender, T item, int count)
        { itemsAdded?.Invoke(sender, new ItemCountEventArgs<T>(item, count)); }

        event ItemsRemovedHandler<T> itemsRemoved;
        internal event ItemsRemovedHandler<T> ItemsRemoved
        {
            add
            {
                itemsRemoved += value;
                events |= EventTypeEnum.Removed;
            }
            remove
            {
                itemsRemoved -= value;
                if (itemsRemoved == null)
                    events &= ~EventTypeEnum.Removed;
            }
        }
        internal void raiseItemsRemoved(object sender, T item, int count)
        { itemsRemoved?.Invoke(sender, new ItemCountEventArgs<T>(item, count)); }

        event ItemInsertedHandler<T> itemInserted;
        internal event ItemInsertedHandler<T> ItemInserted
        {
            add
            {
                itemInserted += value;
                events |= EventTypeEnum.Inserted;
            }
            remove
            {
                itemInserted -= value;
                if (itemInserted == null)
                    events &= ~EventTypeEnum.Inserted;
            }
        }
        internal void raiseItemInserted(object sender, T item, int index)
        { itemInserted?.Invoke(sender, new ItemAtEventArgs<T>(item, index)); }

        event ItemRemovedAtHandler<T> itemRemovedAt;
        internal event ItemRemovedAtHandler<T> ItemRemovedAt
        {
            add
            {
                itemRemovedAt += value;
                events |= EventTypeEnum.RemovedAt;
            }
            remove
            {
                itemRemovedAt -= value;
                if (itemRemovedAt == null)
                    events &= ~EventTypeEnum.RemovedAt;
            }
        }
        internal void raiseItemRemovedAt(object sender, T item, int index)
        { itemRemovedAt?.Invoke(sender, new ItemAtEventArgs<T>(item, index)); }
    }
}