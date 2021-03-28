using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEssentials.ObjectPooler;

namespace UnityEssentials.ObjectPooler
{

    public class Poolable : MonoBehaviour, IPoolable
    {
        public string Tag { get; set; }

        public void Despawn()
        {
            ObjectPooler.PutDown(this);
            this.gameObject.SetActive(false);
        }

        public void OnFirstInstiation()
        {
            this.gameObject.SetActive(false);
        }

        public void Respawn()
        {

            this.gameObject.SetActive(true);

        }


    }
}