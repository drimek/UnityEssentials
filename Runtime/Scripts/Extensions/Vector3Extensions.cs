using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityEssentials
{
    public static class Vector3Extensions
    {

        public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null)
        {
            original.x = x ?? original.x;
            original.y = y ?? original.y;
            original.z = z ?? original.z;

            return original;
        }

        public static Vector3 Reverse(this Vector3 original)
        {
            original.x = -original.x;
            original.y = -original.y;
            original.z = -original.z;
            return original;
        }

        public static Vector3 RandomPointInRange(this Vector3 original,float range)
        {
            return original + UnityEngine.Random.insideUnitSphere * range;
        }

        public static Vector3 RandomDirection(this Vector3 original)
        {
            return ((original + UnityEngine.Random.insideUnitSphere)-original).normalized;
        }

    }
}
