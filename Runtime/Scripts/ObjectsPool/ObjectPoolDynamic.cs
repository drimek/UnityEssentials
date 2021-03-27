using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityEssentials.ObjectPooler
{
    /// <summary>
    /// Number of object is dynamic
    /// </summary>
    public class ObjectPoolDynamic : ObjectPool
    {


        public ObjectPoolDynamic(string tag, int size, GameObject prefab, int instantiationPerFrame) : base(tag, size, prefab, instantiationPerFrame)
        {
        }


        public override IPoolable PoolObject()
        {
            if (_queue.Count > 0)
            {
                var result = _queue.Dequeue();
                return result;
            }
            else
            {
                return default;
            }

        }

        public override void PutDown(IPoolable poolable)
        {
            _queue.Enqueue(poolable);
        }

    }
}


/*
public ObjectPoolDynamic(string tag, int size, GameObject prefab, int instantiationPerFrame) : base(tag, size, prefab, instantiationPerFrame)
{

}
*/