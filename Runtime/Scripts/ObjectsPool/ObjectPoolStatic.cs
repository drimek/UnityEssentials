using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEssentials.ObjectPooler;

namespace UnityEssentials.ObjectPooler
{
    /// <summary>
    /// Number of object doesnt change 
    /// </summary>
    public class ObjectPoolStatic:ObjectPool
    {

        public ObjectPoolStatic(string tag, int size, GameObject prefab, int instantiationPerFrame) : base(tag, size, prefab, instantiationPerFrame)
        {
        }


        public override IPoolable PoolObject()
        {
            var result = _queue.Dequeue();
            _queue.Enqueue(result);
            return result;
        }

        //Youre not putting down anything
        public override void PutDown(IPoolable poolable)
        {
        }




    }
}
