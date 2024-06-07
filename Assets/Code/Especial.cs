using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial : MonoBehaviour
{
    public GameObject prefabExplosion;
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion, 0.30f);
    }
}
