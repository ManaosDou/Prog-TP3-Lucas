using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonIniciar : MonoBehaviour
{
    public AudioClip sonidoBotones;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void VolverAJugar()
    {
        audioSource.PlayOneShot(sonidoBotones);
        SceneManager.LoadScene("Juego");
    }
}