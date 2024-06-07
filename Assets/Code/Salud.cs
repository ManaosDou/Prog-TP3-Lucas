using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Salud : MonoBehaviour
{
    public int vida = 100;
    public AudioClip muerteJugador;
    public AudioClip muerteEnemigo;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Daniar(int danio)
    {
        vida -= danio;
        if (vida <= 0)
        {
            GetComponent<SpriteRenderer>()
                .DOFade(0f, 0.5f)
                .OnComplete(() => Destroy(gameObject));
            if (gameObject.CompareTag("Jugador"))
            {
                audioSource.PlayOneShot(muerteJugador);
            }
            else if (gameObject.CompareTag("Enemigo"))
            {
                audioSource.PlayOneShot(muerteEnemigo);
            }
        }
    }
    private void OnDestroy()
    {
        if (EnemigosRestantes.Instancia != null)
            {
                EnemigosRestantes.Instancia.Verificar();
            }
    }
}
