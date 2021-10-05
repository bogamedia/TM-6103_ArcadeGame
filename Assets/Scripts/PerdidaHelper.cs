using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerdidaHelper : MonoBehaviour
{
    public string EscenaPortada;

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
