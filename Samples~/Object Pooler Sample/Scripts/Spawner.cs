using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEssentials;
using UnityEssentials.ObjectPooler;
using UnityEssentials;
public class Spawner : MonoBehaviour
{


    public List<string> _tags;
    public float _force;
    public float _freq;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {

            var obj = ObjectPooler.PoolObject(_tags.GetRandomElement(), this.transform) as MonoBehaviour;

            obj.transform.parent = this.transform;
            obj.GetComponent<Rigidbody>().AddForce(this.transform.forward * _force);

            yield return new WaitForSeconds(_freq);

        }
    }

}
