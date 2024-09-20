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
            var result = original;
            result.x = x ?? original.x;
            result.y = y ?? original.y;
            result.z = z ?? original.z;

            return result;
        }

        public static Vector3 Reverse(this Vector3 original)
        {
            var result = original;
            result.x = -original.x;
            result.y = -original.y;
            result.z = -original.z;
            return result;
        }
        public static bool IsWithinRangeOf(this Vector3 vector, Vector3 point, float range = 0)
        {
            return Vector3.Distance(vector, point) <= range;
        }

        public static Vector3 RandomPointInRange(this Vector3 original,float range)
        {
            return original + UnityEngine.Random.insideUnitSphere * range;
        }

        public static Vector3 RandomDirection(this Vector3 original)
        {
            return ((original + UnityEngine.Random.insideUnitSphere)-original).normalized;
        }

        public static Vector3 DirectionTo(this Vector3 original, Vector3 target)
        {
            return (target - original).normalized;
        }
        
        public static Vector3 DirectionTo(this Vector3 original, Transform target)
        {
            return (target.position - original).normalized;
        }
        
        public static Vector3 DirectionTo(this Vector3 original, GameObject target)
        {
            return (target.transform.position - original).normalized;
        }
        
    }
}
