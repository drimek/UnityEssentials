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

    }
}
