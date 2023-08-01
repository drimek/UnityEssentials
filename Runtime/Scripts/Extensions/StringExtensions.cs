using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.kompotentertainment.unityessentials.Packages.UnityEssentials.Runtime.Scripts.Extensions
{
    public static class StringExtensions
    {
       public static string Capitalize(this string input) =>
       input switch
       {
/*           null => throw new ArgumentNullException(nameof(input)),
           "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
           _ => input[0].ToString().ToUpper() + input[1..].ToLower()
*/       };

    }
}
