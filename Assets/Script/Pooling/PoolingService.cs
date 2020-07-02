using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingService<T> : SingletonBehaviour<PoolingService<T>> where T : class
{
    private List<poolingItem<T>> pooledItems = new List<poolingItem<T>>();   

    public virtual T GetItem()
    {
        if(pooledItems.Count > 0)
        {
            poolingItem<T> dataStructure = pooledItems.Find(i => !i.isActive);
            if (dataStructure != null)
            {
                dataStructure.isActive = true;
                return dataStructure.item;
            }
        }
        return CreateNewPooledItem();
    }

    public virtual void ReturnItem(T item)
    {
        poolingItem<T> poolingItem = pooledItems.Find(i => i.item.Equals(item));
        poolingItem.isActive = false;
    }

    private T CreateNewPooledItem()
    {
        poolingItem<T> poolItem = new poolingItem<T>();
        poolItem.item = CreateItem();
        poolItem.isActive = true;
        pooledItems.Add(poolItem);
        //print(pooledItems.Count + "Instance Created" );
        return poolItem.item;
    }

    protected virtual T CreateItem()
    {
        return (T)null;
    }

    public class poolingItem<U>
    {
        public U item;
        public bool isActive;
    }
}
