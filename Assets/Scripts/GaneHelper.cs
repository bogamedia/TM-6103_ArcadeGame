using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaneHelper : MonoBehaviour
{
    public string EscenaPortada;
    public string PuntajeFinal = "1000";
    public Text txtPuntajeFinal;

    private void Start()
    {
        //Al iniciar el juego, vamos a desplegar en pantalla el puntaje final del jugador

        PuntajeFinal = GameManager.instancia.ObtenerPuntaje().ToString();
        txtPuntajeFinal.text = PuntajeFinal;
    }

    public void VolverPortada()
    {
        try
        {
            GameManager.instancia.CambiarEscena(EscenaPortada);
        }
        catch (System.Exception ex)
        {
            Debug.Log("El GameManager no está en la escena");
        }
    }

}
