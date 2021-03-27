using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityEssentials.ObjectPooler
{
    public class ComponentPool<T>:IComponentPool 
    {

        Dictionary<Collider, T> _componentDictionary = new Dictionary<Collider, T>();

        public ComponentPool() 
        {
                var dictType = typeof(Dictionary<,>);
                Type[] args = { typeof(Collider), typeof(T) };

                var constructedDictionary = dictType.MakeGenericType(args);

                _componentDictionary = Activator.CreateInstance(constructedDictionary) as Dictionary<Collider, T>;
        }


        

        public T GetComponent(Collider collider)
        {
            //if (!_componentDictionary.ContainsKey(collider))
            //{
            //    _componentDictionary.Add(collider, collider.gameObject.GetComponent<T>());
            //}

            return _componentDictionary[collider];
        }

        public bool TryGetComponent(Collider collider, out T component)
        {

            if (!_componentDictionary.ContainsKey(collider))
            {
                if(collider.gameObject.TryGetComponent(out T com))
                {
                    _componentDictionary.Add(collider, com);
                }
                else
                {
                    component = default;
                    return false;
                }
            }

            component = _componentDictionary[collider];
            return true;
        }

        public void Add(Collider collider)
        {
            _componentDictionary.Add(collider, collider.gameObject.GetComponent<T>());

        }

    }
}
