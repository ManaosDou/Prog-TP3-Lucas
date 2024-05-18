using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public GameObject prefabDisparoEnemigo;
    void Start()
    {
       StartCoroutine(DisparoE()); 
    }
    IEnumerator DisparoE()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 8));
            Disparar();
        }
    }
    void Disparar()
    {
        Vector3 puntoDisparo = transform.position + Vector3.down;
        Instantiate(prefabDisparoEnemigo, puntoDisparo, Quaternion.identity);
    }
}
