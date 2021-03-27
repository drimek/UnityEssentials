using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEssentials.ObjectPooler {
    /// <summary>
    /// So U cant use Gameobject as Key do so GetHashcode is extremly slow cause some thread safety issues. 
    /// 
    /// Ok for now this is pretty much usless
    /// </summary>
    public class ComponentPooler : MonoBehaviour
    {
        public static ComponentPooler Instance { private set; get; }

        Dictionary<Type, IComponentPool> _componentDictionary = new Dictionary<Type, IComponentPool>();

        // Start is called before the first frame update
        void Awake()
        {
            Instance = this;


            _componentDictionary.Add(typeof(Rigidbody), new ComponentPool<Rigidbody>());
        }

        public void Add(Collider col)
        {
            var b=_componentDictionary[typeof(Rigidbody)] as ComponentPool<Rigidbody>;
            b.Add(col);
        }

        public T PullComponent<T>(Collider collider)
        {
            var type = typeof(T);

          //  Debug.Log("type " + type.ToString());

            //if (!_componentDictionary.ContainsKey(type))
            //{
            //    _componentDictionary.Add(type, new ComponentPool<T>());
            //}

            var pool = _componentDictionary[type] as ComponentPool<T>;

            return pool.GetComponent(collider);
        }


    }

    
}