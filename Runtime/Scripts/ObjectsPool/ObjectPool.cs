using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityEssentials.ObjectPooler
{
    public abstract class ObjectPool
    { 
        protected Queue<IPoolable> _queue = new Queue<IPoolable>();
        public string _tag="tag";
        public int _size;
        public GameObject _prefab;
        public int _instantiationPerFrame=-1;


        public ObjectPool(string tag, int size, GameObject prefab, int instantiationPerFrame) =>
            (_tag, _size, _prefab, _instantiationPerFrame) = (tag, size, prefab, instantiationPerFrame);


        public abstract IPoolable PoolObject();

        public abstract void PutDown(IPoolable poolable);

        public void AddToPool(IPoolable poolable)
        {
            _queue.Enqueue(poolable);
        }

    }
}