using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public static class GlobalUtils

    {        /// <summary>
             /// Adds newly (if not already in the list) found assets.
             /// Returns how many found (not how many added)
             /// </summary>
             /// <typeparam name="T"></typeparam>
             /// <param name="path"></param>
             /// <param name="assetsFound">Adds to this list if it is not already there</param>
             /// <returns></returns>
        public static List<T> GetAssetsFromPath<T>(string path) where T : UnityEngine.Object
        {
            var assetsFound = new List<T>();
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
