using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenu : MonoBehaviour
{
    public AudioClip sonidoBotones;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void VolverAMenu()
    {
        audioSource.PlayOneShot(sonidoBotones);
        SceneManager.LoadScene("Menu");
    }
}