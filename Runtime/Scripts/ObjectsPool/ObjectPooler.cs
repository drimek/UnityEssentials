using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEssentials.ObjectPooler;

namespace UnityEssentials.ObjectPooler
{
    public class ObjectPooler : MonoBehaviour
    {
        static GameObject _objectPooler;
        public static ObjectPooler Instance { private set; get; }
        List<ObjectPool> _pools=new List<ObjectPool>();
        Dictionary<string, ObjectPool> _poolDict = new Dictionary<string, ObjectPool>();

        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(Instance);
            }

            Instance = this;


            var objectPoolerSetUp = FindObjectOfType<ObjectPoolerSetUp>();

            if (objectPoolerSetUp == null)
            {

                var info = Resources.LoadAll<ObjectPoolInfoSO>("").ToList();

                for (int i = 0; i < info.Count; i++)
                {
                    var infEl = info[i];
                    ObjectPool pool;
                    if (info[i].isDynamic)
                    {
                        pool = new ObjectPoolDynamic(infEl._tag, infEl._size, infEl._prefab, infEl._instantiationPerFrame);

                    }
                    else
                    {
                        pool = new ObjectPoolStatic(infEl._tag, infEl._size, infEl._prefab, infEl._instantiationPerFrame);

                    }

                    _pools.Add(pool);
                }


                foreach (var pool in _pools)
                {
                    try
                    {
                        _poolDict.Add(pool._tag, pool);
                        InstantiatePool(pool);

                    }
                    catch (ArgumentException)
                    {
                        Debug.LogError("An pool with key " + pool._tag + " already exists.");
                    }

                }
            }
            else
            {

            }

        }



        [RuntimeInitializeOnLoadMethod]
        static void InitializeObjectPooler()
        {
            _objectPooler = new GameObject();
            _objectPooler.name = "ObjectPooler";
            _objectPooler.AddComponent(typeof(ObjectPooler));
            _objectPooler.isStatic = true;

            DontDestroyOnLoad(_objectPooler);
        }



        public void InstantiatePool(ObjectPool pool)
        {
            //Instantiate all at once
            if (pool._instantiationPerFrame <= -1)
            {
                for (int i = 0; i < pool._size; i++)
                {
                    InstantiateNewPoolable(pool);
                }
            }
            else
            {
                StartCoroutine(InstantiatePoolEI(pool));
            }

        }




        IEnumerator InstantiatePoolEI(ObjectPool pool)
        {

            int left = pool._size;

            while (left > 0)
            {

                int num = (left < pool._instantiationPerFrame) ? left : pool._instantiationPerFrame;
                left -= num;

                for (int i = 0; i < num; i++)
                {
                    InstantiateNewPoolable(pool);

                }

                yield return null;
            }
        }

        public static IPoolable PoolObject(string tag)
        {
            var pool = Instance._poolDict[tag];
            var result = pool.PoolObject();

            //if pool its empty just add another in and pool again
            if (result == null)
            {
                InstantiateNewPoolable(pool);
                result = pool.PoolObject();
            }


            result.Respawn();

            return result;
        }


        public static IPoolable PoolObject(string tag, Transform transform)
        {
            var result = PoolObject(tag);

            var mono = result as MonoBehaviour;

            mono.transform.position = transform.position;
            mono.transform.rotation = transform.rotation;

            return result;
        }


        public static IPoolable PoolObject(string tag, Vector3 position,Quaternion rotation)
        {
            var result = PoolObject(tag);

            var mono = result as MonoBehaviour;

            mono.transform.position = position;
            mono.transform.rotation = rotation;

            return result;
        }

       // int nr = 1;
        static void InstantiateNewPoolable(ObjectPool pool)
        {

            var poolable = Instantiate(pool._prefab).GetComponent<IPoolable>();
            var mono = poolable as MonoBehaviour;
            mono.transform.parent = Instance.gameObject.transform;

            poolable.OnFirstInstiation();
            poolable.Tag = pool._tag;
            pool.AddToPool(poolable);
        }

        public static void PutDown(IPoolable poolable) 
        {
            var pool = Instance._poolDict[poolable.Tag];
            var mono = poolable as MonoBehaviour;
            mono.transform.parent = Instance.gameObject.transform;
            pool.PutDown(poolable);
        }


    }
}