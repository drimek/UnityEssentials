using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  UnityEssentials
{
    public static class  RandomExtensions
    {

        /// <summary>
        /// binary rool with propability for true in permilles
        /// </summary>
        /// <param name="random"></param>
        /// <param name="proportion"></param>
        /// <returns></returns>
        public static bool BinaryRoll(this System.Random random,int propability=500)
        {
            int res = random.Next(0, 1000);

            return res < propability;
        }


        public static double NextGaussianDouble(this Random r, double mean = 0, double standardDeviation = 1)
        {
            double u, v, S;

            do
            {
                u = 2.0 * r.NextDouble() - 1.0;
                v = 2.0 * r.NextDouble() - 1.0;
                S = u * u + v * v;
            }
            while (S >= 1.0);

            double fac = Math.Sqrt(-2.0 * Math.Log(S) / S);
            return u * fac * standardDeviation + mean;
        }

        public static IList<T> NextWeightedElements<T>(this Random random, IList<T> source, int[] weights = null, int returnSize = 1)
        {

            int sourceLength = source.Count;
            if (weights == null)
            {
                weights = new int[sourceLength];
                for (int i = 0; i < sourceLength; i++)
                {
                    weights[i] = 1;
                }
            }

            if (weights.Length != source.Count)
            {
                throw new ArgumentOutOfRangeException($"Weights length is {weights.Length} but should be {source.Count}");
            }

            var _weightSum = weights.Sum(x => x);

            var result = new List<T>(returnSize);

            for (int i = 0; i < returnSize; i++)
            {
                var rolled = random.Next(_weightSum);

                int currentWeightSum = -1;

                for (int j = 0; j < sourceLength; j++)
                {
                    currentWeightSum += weights[j];
                    if (currentWeightSum >= rolled)
                    {
                        result.Add(source[j]);
                        break;
                    }
                }
            }

            return result;
        }

        public static T NextWeightedElement<T>(this Random random, IList<T> source, int[] weights = null)
        {

            int sourceLength = source.Count;
            if (weights == null)
            {
                //weights = Enumerable.Range(0, 1).ToArray();
                weights = new int[sourceLength];
                for (int i = 0; i < sourceLength; i++)
                {
                    weights[i] = 1;
                }
            }

            if (weights.Length != source.Count)
            {
                throw new ArgumentOutOfRangeException($"Weights length is {weights.Length} but should be {source.Count}");
            }

            var _weightSum = weights.Sum(x => x);

            T result = default;

            var rolled = random.Next(_weightSum);

            int currentWeightSum = -1;

            for (int j = 0; j < sourceLength; j++)
            {
                currentWeightSum += weights[j];
                if (currentWeightSum >= rolled)
                {
                    result = source[j];
                    break;
                }
            }

            return result;
        }
        public static T NextWeightedElement<T>(this Random random, IList<(T element, int weight)> elementToWeight)
        {

            int sourceLength = elementToWeight.Count;

            var _weightSum = elementToWeight.Sum(x => x.weight);

            T result = default;

            var rolled = random.Next(_weightSum);

            int currentWeightSum = -1;

            for (int j = 0; j < sourceLength; j++)
            {
                currentWeightSum += elementToWeight[j].weight;
                if (currentWeightSum >= rolled)
                {
                    result = elementToWeight[j].element;
                    break;
                }
            }

            return result;
        }

    }
}
