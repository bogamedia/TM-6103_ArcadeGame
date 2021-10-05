using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeHelper : MonoBehaviour
{
    public string EscenaPortada;
    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EsperarCambioEscena());
    }

    private IEnumerator EsperarCambioEscena()
    {
        yield return new WaitForSeconds(timer);

        VolverPortada();
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
