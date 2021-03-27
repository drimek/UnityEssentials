using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace UnityEssentials.ObjectPooler
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "ObjectPoolerSetUp", menuName = "ObjectPooler/ObjectPoolerSetUp", order = 1)]
    public class ObjectPoolerSetUp : ScriptableObject
    {
        public List<ObjectPool> pools;
    }
}