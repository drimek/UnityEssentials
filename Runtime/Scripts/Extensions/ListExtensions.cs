using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace UnityEssentials{

    public static class ListExtensions
    {
        public static T First<T>(this List<T> list)
        {
            return list[0];
        }

        public static T Last<T>(this List<T> list)
        {
            return list[list.Count-1];
        }

        public static void Shuffle<T>(this List<T> list, System.Random random)
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                int next = random.Next(i, list.Count);
                var temp = list[i];
                list[i] = list[next];
                list[next] = temp;
            }
        }

        public static void Shuffle<T>(this List<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int next = UnityEngine.Random.Range(i, list.Count);

                var temp = list[i];
                list[i] = list[next];
                list[next] = temp;
            }
        }


        public static T GetRandomElement<T>(this List<T> list, System.Random random)
        {
            if (list.Count == 0) return default;
            int next = random.Next(0, list.Count);

            return list[next];
        }

        public static T GetRandomElement<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
        public static T GetRandomElementInNormalDistribution<T>(this IList<T> list, System.Random r, double mean = 0, double standardDeviation = 1)
        {
            var next = r.NextGaussianDouble(mean: mean, standardDeviation: standardDeviation);

            double length = (float)standardDeviation * 3f * 2f;
            double halfLength = length / 2f;

            int index = next switch
            {
                double _ when next <= -halfLength => 0,
                double _ when next >= halfLength => list.Count - 1,
                _ => (int)Math.Floor((next + halfLength) / length * list.Count)
            };

            return list[index];
        }

        public static Type GetListType<T>(this List<T> _)
        {
            return typeof(T);
        }

    }

}
