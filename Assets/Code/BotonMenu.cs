using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenu : MonoBehaviour
{
    public void VolverAMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}