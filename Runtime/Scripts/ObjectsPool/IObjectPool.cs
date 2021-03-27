using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEssentials.ObjectPooler
{
    public interface IObjectPool
    {
        void AddToPool(IPoolable poolable);

    }
}
