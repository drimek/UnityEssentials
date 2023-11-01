using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityEssentials
{
    public class Timer
    {
        private float _waitFor;
        private float _waited;

        public float Left => _waited;

        public bool Stopped => _waited >= _waitFor;

        public Timer(float days=0, float hours=0, float minutes = 0, float seconds = 0)
        {
            _waitFor = seconds+minutes*60+hours*3600+days*3600*24;
            _waited = 0;
        }

        public void Reset()
        {
            _waited = _waitFor;
        }

        public bool TryTickTimer(float time)
        {
            if (_waited >= _waitFor) return false;
            _waited += time;
            return true;
        }

    }
}
