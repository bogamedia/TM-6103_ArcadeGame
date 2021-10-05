using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singelton
    private static GameManager _instancia;
    public static GameManager instancia 
    {
        get 
        { 
            return _instancia;
        } 
    }

    //Miembros de clase privados
    private int _puntaje;

    public int ObtenerPuntaje()
    {
        return _puntaje;
    }

    public void RestaurarPuntaje()
    {
        _puntaje = 0;
    }

    public void SumarPuntaje(int valor)
    {
        _puntaje += valor;
    }

    private void Awake()
    {
        if (_instancia == null)
        {
            _instancia = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void Salir()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        //Operaciones ante el evento de cerrar la aplicación
        //Cerrar la conexión a la BD
        //Cerrar la lectura de archivos
        //Pausar el contador de tiempo de juego
    }


    public bool GuardarPuntaje(int posicion, int valor)
    {
        try
        {
            PlayerPrefs.SetInt("Pos" + posicion.ToString(), valor);
        }
        catch (System.Exception)
        {
            return false;
        }

        return true;
    }

    public int ObtenerPuntaje(int posicion)
    {
        return PlayerPrefs.GetInt("Pos" + posicion.ToString(), 0);
    }
}
