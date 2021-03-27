using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace  UnityEssentials
{
    public static class ColorExtensions
    {

        public static Color With(this Color color, float? r=null, float? g=null, float? b = null, float? a=null)
        {
            Color result;

            result.r = (r == null) ? color.r : r.Value;
            result.g = (g == null) ? color.g : g.Value;
            result.b = (b == null) ? color.b : b.Value;
            result.a = (a == null) ? color.a : a.Value;

            return result;
        }

    }
}
