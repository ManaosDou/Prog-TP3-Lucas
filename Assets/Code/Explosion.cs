using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Explosion : MonoBehaviour
{
    private int danio = 100;
    public float tiempo = 1f;
    public AudioClip sExplosion;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sExplosion);
        GetComponent<SpriteRenderer>()
            .DOFade(0f, tiempo)
            .OnComplete(() => Destroy(gameObject));

        Camara.Instancia.ScreenShake();
    }
    
    private void OnCollisionEnter2D(Collision2D colision)
    {
        var vidaObjeto = colision.gameObject.GetComponent<Salud>();
        if (vidaObjeto != null)
        {
            vidaObjeto.Daniar(danio);
        }
    }
}
