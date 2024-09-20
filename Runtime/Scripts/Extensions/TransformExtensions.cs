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

        public static Vector3 DirectionTo(this Transform original, Transform target)
        {
            return (target.position - original.position).normalized;
        }

        public static Vector3 DirectionTo(this Transform original, Vector3 target)
        {
            return (target - original.position).normalized;
        }
    }


}

