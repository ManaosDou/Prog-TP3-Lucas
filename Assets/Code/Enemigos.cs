using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemigos : MonoBehaviour
{
    public EnemigosRestantes scriptRestantes;
    private int danio = 100;
    public GameObject prefabDisparoEnemigo;
    private bool direccion;
    private bool bajar = false;
    public float velocidadMovimiento = 2f;
    public float distanciaBajar = 1f;
    private Vector3 posicionInicial;
    public AudioClip disparo;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        direccion = Mathf.FloorToInt(transform.position.y) % 2 == 0; // Alternar dirección según Y
        StartCoroutine(DisparoE());
        StartCoroutine(MoverEnemigos());
    }
    private void OnCollisionEnter2D(Collision2D colision)
    {
        var vidaObjeto = colision.gameObject.GetComponent<Salud>();
        if (vidaObjeto != null)
        {
            vidaObjeto.Daniar(danio);
            GetComponent<SpriteRenderer>()
            .DOFade(0f, 0.5f)
            .OnComplete(() => Destroy(gameObject));
        }
    }
    IEnumerator DisparoE()
    {
        while (true)
        {
            if (scriptRestantes.gameOver == true){
            yield return new WaitForSeconds(Random.Range(2, 8));
            Disparar();
            }
            yield return null;
        }
    }
    void Disparar()
    {
        audioSource.PlayOneShot(disparo);
        Vector3 puntoDisparo = transform.position + Vector3.down;
        Instantiate(prefabDisparoEnemigo, puntoDisparo, Quaternion.identity);
    }
    IEnumerator MoverEnemigos()
    {
        while (true)
        {
            if (scriptRestantes.gameOver == true){
            Vector3 movimiento = direccion ? Vector3.left : Vector3.right;
            Vector3 nuevaPosicion = transform.position + movimiento * velocidadMovimiento * Time.deltaTime;

            if (bajar)
            {
                nuevaPosicion.y -= distanciaBajar;
                direccion = !direccion;
                bajar = false;
            }

            transform.position = nuevaPosicion;
            }
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Pared"))
        {
            Bajar();
        }
    }
    public void Bajar()
    {
        bajar = true;
    }
}
