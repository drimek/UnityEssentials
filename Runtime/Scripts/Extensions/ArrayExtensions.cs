using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEssentials
{
    public static class ArrayExtensions
    {
        public static T First<T>(this T[] list)
        {
            return list[0];
        }

        public static T Last<T>(this T[] list)
        {
            return list[list.Length - 1];
        }

        public static void Shuffle<T>(this T[] list, System.Random random)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                int next = random.Next(i, list.Length);
                var temp = list[i];
                list[i] = list[next];
                list[next] = temp;
            }
        }

        public static void Shuffle<T>(this T[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                int next = UnityEngine.Random.Range(i, list.Length);

                var temp = list[i];
                list[i] = list[next];
                list[next] = temp;
            }
        }


        public static T GetRandomElement<T>(this T[] list, System.Random random)
        {
            int next = random.Next(0, list.Length);

            return list[next];
        }

        public static T GetRandomElement<T>(this T[] list)
        {
            return list[UnityEngine.Random.Range(0, list.Length)];
        }

        public static Type GetListType<T>(this T[] _)
        {
            return typeof(T);
        }
    }
}
