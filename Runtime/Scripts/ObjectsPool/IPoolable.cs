using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEssentials.ObjectPooler
{
    public interface IPoolable
    {
        string Tag { get; set; }
        void OnFirstInstiation();
        void Respawn();
        void Despawn();
    }
}
