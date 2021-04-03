using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityEssentials
{
    public static class Vector2Extensions
    {


        public static Vector2 With(this Vector2 original, float? x = null, float? y = null)
        {
            original.x = x ?? original.x;
            original.y = y ?? original.y;

            return original;
        }

        public static Vector2 Reverse(this Vector2 original)
        {
            original.x = -original.x;
            original.y = -original.y;
            return original;
        }

        public static Vector2 RandomPointInRange(this Vector2 original, float range)
        {
            return original + UnityEngine.Random.insideUnitCircle * range;
        }

        public static Vector2 RandomDirection(this Vector2 original)
        {
            return ((original + UnityEngine.Random.insideUnitCircle) - original).normalized;
        }


    }
}
