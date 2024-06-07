using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;
using TMPro;


public class Jugador : MonoBehaviour
{
    public EnemigosRestantes scriptRestantes;
    //disparo
    public GameObject prefabDisparoJugador;
    public Transform puntoDisparo;
    private bool puedeDisparar = true;
    //movimiento
    private Vector2 direccionMovimiento;
    public float velocidadMovimiento = 6f;
    //especial
    public TMP_Text txtEspecial;
    public GameObject prefabEspecial;
    public GameObject spriteEspecial;
    public Camera camaraPrincipal;
    public float potenciaDisparo = 1;
    private bool puedeDispararEspecial = true;
    //audio
    public AudioClip cargaEspecial;
    public AudioClip disparo;
    public AudioClip especial;
    private AudioSource audioSource;
    void Start()
    {
        txtEspecial.text = "Disparo especial cargado"; 
        audioSource = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {
        Mover();
    }
    public void OnMove(InputValue input)
    {
        direccionMovimiento = input.Get<Vector2>();
    }
    void Mover()
    {
        Vector3 movimiento = new Vector3(direccionMovimiento.x, 0, 0) * velocidadMovimiento * Time.deltaTime;
        transform.position += movimiento;
    }
    void OnFire (InputValue input)
    {
        if (scriptRestantes.gameOver == true){
        if (puedeDisparar == true)
        {
            Disparar();
        }
        }
    }
    void Disparar()
    {
        audioSource.PlayOneShot(disparo);
        Vector3 puntoDisparo = transform.position + Vector3.up;
        Instantiate(prefabDisparoJugador, puntoDisparo, Quaternion.identity);
        puedeDisparar = false;
        StartCoroutine(Esperar());
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(0.5f);
        puedeDisparar = true;
    }
    void OnFire1(InputValue input)
    {
        if (scriptRestantes.gameOver == true){
        if (puedeDispararEspecial)
        {
            audioSource.PlayOneShot(especial);
            var origen = transform.position + Vector3.up;

            var goDisparo = Instantiate(prefabEspecial);

            // El disparo arranca en mi posicion
            goDisparo.transform.position = origen;

            // Conviero la posicion del mouse (en coordenadas de pantalla) a posicion en el mundo.
            // Lo tiene que hacer la camara porque es la unica que entiende que se esta viendo y adonde.
            var mouseEnMundo = camaraPrincipal.ScreenToWorldPoint(Input.mousePosition);

            // El vector de direccion es destino - origen
            // El vector tiene que estar normalizado porque es una direccion. Quiero que su
            // longitud sea igual a 1.
            Vector3 vectorDiferencia = mouseEnMundo - origen;
            var direccionDisparo = vectorDiferencia.normalized;
            direccionDisparo.z = 0f;

            // Lanzo el disparo en la direccion que calcule
            var rbDisparo = goDisparo.GetComponent<Rigidbody2D>();
            rbDisparo.AddForce(direccionDisparo * potenciaDisparo, ForceMode2D.Impulse);

            // Calculo la rotacion que tengo que darle al proyectil para que mire hacia adonde quiero
            float angulo = Mathf.Atan2(direccionDisparo.y, direccionDisparo.x) * Mathf.Rad2Deg;
            goDisparo.transform.eulerAngles = new Vector3(0, 0, angulo);

            // Deshabilitar la capacidad de disparar el misil hasta que pase el tiempo de recarga
            puedeDispararEspecial = false;
            txtEspecial.text = "Recargando disparo especial";
            spriteEspecial.SetActive(false);
            StartCoroutine(RecargarMisil());
        }
        }
    }
    IEnumerator RecargarMisil()
    {
        yield return new WaitForSeconds(5);
        puedeDispararEspecial = true;
        audioSource.PlayOneShot(cargaEspecial);
        spriteEspecial.SetActive(true);
        txtEspecial.text = "Disparo especial cargado";
    }
}
