using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace UnityEssentials
{
    public static class TransformExtensions
    {

        public static bool IsBehind(this Transform main, Transform who)
        {
            var toMain = who.DirectionTowards(main);

            return Vector3.Dot(toMain, who.forward) < 0;
        }

        public static Vector3 DirectionTowards(this Transform original, Transform where)
        {
            return (where.position - original.position).normalized;
        }

        public static Vector3 DirectionTowards(this Transform original, Vector3 where)
        {
            return (where - original.position).normalized;
        }
    }


}

