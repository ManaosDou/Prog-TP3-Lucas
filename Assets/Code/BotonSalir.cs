using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonSalir : MonoBehaviour
{
    public AudioClip sonidoBotones;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Salir()
    {
        audioSource.PlayOneShot(sonidoBotones);
        Application.Quit();
    }
}