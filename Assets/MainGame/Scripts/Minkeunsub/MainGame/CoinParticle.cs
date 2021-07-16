using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticle : MonoBehaviour
{

    public float destroyDelay;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyCoin", destroyDelay);
    }

    void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
