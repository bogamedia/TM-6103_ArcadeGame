using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector3 _posInicial;
    private Rigidbody rigidBody;
    private float velX, velY;
    private float jump;
    private bool enPiso;
    private float tiempoDeJuego;
    private int puntaje;

    public float velocidad = 1.5f;
    public float fuerzaVertical = 2f;
    public float tiempoTranscurrido = 0f;
    public float tiempoLimite = 30;
    public Text txt_tiempotranscurrido;
    public Text txt_puntajeacual;
    public Text txt_tiempolimiteactual;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();



        puntaje = 0;

        _posInicial = 
            new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z
            );
    }

    public void IncrementarPuntaje(int valor)
    {
        puntaje += valor;
        Debug.Log("Puntaje actual: " + puntaje.ToString());
    }

    public void ModificarTiempo(float valor)
    {
        tiempoDeJuego -= valor;
        Debug.Log("Tiempo con reducción: " + tiempoDeJuego.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //actualizar interfaces graficas
        txt_tiempotranscurrido.text = tiempoTranscurrido.ToString();
        txt_puntajeacual.text = puntaje.ToString();
        txt_tiempolimiteactual.text = (tiempoLimite-tiempoDeJuego).ToString();


        //Contador de tiempo
        tiempoTranscurrido += Time.deltaTime;
        tiempoDeJuego += Time.deltaTime;

        if(tiempoDeJuego > tiempoLimite)
        {
            FinDeJuego();
        }

        velX = Input.GetAxis("Horizontal");// -1 .... -0.5 .... 0 .... 0.5 .... 1
        velY = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        enPiso = Physics.Raycast(this.transform.position, Vector3.down, 1.02f);

        //mueve el personaje
        if (velX != 0 || velY != 0)
        {
            rigidBody.velocity = (new Vector3(velX, 0, velY)) * velocidad;
        }

        //hace que el personaje salte
        if(enPiso && jump >= 0.3f)
        {
            rigidBody.AddForce(Vector3.up * fuerzaVertical);
        }


        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter ha sido presionado");

            transform.position = new Vector3(_posInicial.x, _posInicial.y, _posInicial.z);

            rigidBody.velocity = Vector3.zero;
        }
    }

    public void Alerta()
    {
        Debug.Log("Conexion con un trigger establecida");
    }

    public void FinDeJuego()
    {
        Debug.Log("Juego Finalizado");
        GameManager.instancia.CambiarEscena("Perdida");
    }
}
