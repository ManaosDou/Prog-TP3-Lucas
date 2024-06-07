using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemigosRestantes : MonoBehaviour
{
    public static EnemigosRestantes Instancia { get; private set; }

    public GameObject jugador;
    public TMP_Text TxtERestantes;
    public GameObject ButtonRestart;
    public GameObject ButtonMenu;
    public GameObject TxtGanar;
    public GameObject TxtPerder;
    private int ERestantes;
    public bool gameOver = true;
    public AudioClip perder;
    public AudioClip ganar;
    private AudioSource audioSource;
    public AudioSource musica;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ActualizarTexto();
    }
    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Verificar()
    {
        ActualizarTexto();
        Ganar();
        Perder();
    }
    private void ActualizarTexto()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        ERestantes = enemigos.Length;
        TxtERestantes.text = "Enemigos restantes: " + ERestantes.ToString();
    }
    private void Ganar()
    {
        if (ERestantes == 0)
        {
            TxtGanar.SetActive(true);
            ButtonMenu.SetActive(true);
            ButtonRestart.SetActive(true);
            DestruirDisparos();
            if (musica != null)
        {
            musica.Stop();
            audioSource.PlayOneShot(ganar);
        }
            gameOver = false;
        }
    }
    private void Perder()
    {
        if (jugador == null && gameOver)
        {
            TxtPerder.SetActive(true);
            ButtonMenu.SetActive(true);
            ButtonRestart.SetActive(true);
            DestruirDisparos();
            if (musica != null)
        {
            musica.Stop();
            audioSource.PlayOneShot(perder);
        }
            gameOver = false;
        }
    }
    private void DestruirDisparos()
    {
        GameObject[] disparosJugador = GameObject.FindGameObjectsWithTag("DisparoJugador");

        foreach (GameObject disparo in disparosJugador)
        {
            Destroy(disparo);
        }

        GameObject[] disparosEnemigo = GameObject.FindGameObjectsWithTag("DisparoEnemigo");

        foreach (GameObject disparo in disparosEnemigo)
        {
            Destroy(disparo);
        }
    }
}
