using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEssentials.ObjectPooler;

public class SpawnBall : MonoBehaviour
{
    IPoolable poolable;
    // Start is called before the first frame update
    void Start()
    {
        poolable = GetComponent<IPoolable>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            poolable.Despawn();
        }
    }
}
