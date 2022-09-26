using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T:Component
{
    private List<T> _pool;
    private T _prefab;
    private Transform _parent;

    public ObjectPool(T prefab,int poolSize, Transform parent = null) 
    {
        _pool = new List<T>();
        _prefab = prefab;
        _parent = parent;
        GeneratePool(poolSize, _parent);
    }

    private void GeneratePool(int size, Transform parent = null)
    {
        if (_pool == null || _prefab == null) return;

        for (int i = 0; i < size; i++)
        {
            AddToPool(parent);
        }
    }

    private T AddToPool(Transform parent)
    {
        var instance = Object.Instantiate(_prefab, parent);
        instance.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        instance.transform.rotation = Quaternion.identity;
        _pool.Add(instance);
        instance.gameObject.SetActive(false);
        return instance;
    }

    public T GetFromPool()
    {
        if (_pool == null) return null;

        int poolSize = _pool.Count;
        T item = null;
        for (int i = 0; i < poolSize; i++)
        {
            item = _pool[i];

            if (!item.gameObject.activeInHierarchy) 
            {
                item.gameObject.SetActive(true);
                return item;
            }
        }

        item = AddToPool(_parent);
        item.gameObject.SetActive(true);
        return item;
    }
}
