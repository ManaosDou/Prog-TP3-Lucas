using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonIniciar : MonoBehaviour
{
    public void VolverAJugar()
    {
        SceneManager.LoadScene("Juego");
    }
}