using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityEssentials.ObjectPooler
{
    [CreateAssetMenu(fileName = "ObjectPool", menuName = "ObjectPool", order = 1)]
    public class ObjectPoolInfoSO: ScriptableObject
    {
        public bool isDynamic=true;
        public string _tag = "tag";
        public int _size;
        public GameObject _prefab;
        public int _instantiationPerFrame = -1;

    }
}
