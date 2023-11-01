using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace UnityEssentials
{
    public static class Utils
    {
        private static List<GameObject> _prefabs;
        
        public static GameObject GetPrefab(string name)
        {
            _prefabs ??= GetAllPrefabs();
            return _prefabs.First(x => x.name.Equals(name));
        }
        
        
        public static List<GameObject> GetAllPrefabs()
        {
            var result = new List<GameObject>();
            string[] guids = AssetDatabase.FindAssets("t:prefab");

            foreach (var guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                GameObject go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                result.Add(go);
            }
            return result;

        }




        /// <summary>
        /// Adds newly (if not already in the list) found assets.
        /// Returns how many found (not how many added)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="assetsFound">Adds to this list if it is not already there</param>
        /// <returns></returns>
        public static List<T> GetAssets<T>(string path =null) where T : UnityEngine.Object
        {
            var assetsFound = new List<T>();
            path ??= "Assets";
            string[] filePaths = System.IO.Directory.GetFiles(path);

            if (filePaths != null && filePaths.Length > 0)
            {
                for (int i = 0; i < filePaths.Length; i++)
                {
                    UnityEngine.Object obj = UnityEditor.AssetDatabase.LoadAssetAtPath(filePaths[i], typeof(T));
                    if (obj is T asset)
                    {
                        if (!assetsFound.Contains(asset))
                        {
                            assetsFound.Add(asset);
                        }
                    }
                }
            }
            return assetsFound;
        }

    }
}
