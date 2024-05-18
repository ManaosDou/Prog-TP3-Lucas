using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemigosRestantes : MonoBehaviour
{
    public GameObject jugador;
    public TMP_Text TxtERestantes;
    public GameObject ButtonRestart;
    public GameObject ButtonMenu;
    public GameObject TxtGanar;
    public GameObject TxtPerder;
    private int ERestantes;

    void Start()
    {
        ActualizarTexto();
    }
    void FixedUpdate()
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
        }
    }
    private void Perder()
    {
        if (jugador == null)
        {
            TxtPerder.SetActive(true);
            ButtonMenu.SetActive(true);
            ButtonRestart.SetActive(true);
            DestruirDisparos();
        }
    }
    private void DestruirDisparos()
    {
        GameObject[] disparosJugador = GameObject.FindGameObjectsWithTag("DisparoJugador");

        foreach (GameObject disparo in disparosJugador)
        {
            Destroy(disparo);
        }
    }
}
