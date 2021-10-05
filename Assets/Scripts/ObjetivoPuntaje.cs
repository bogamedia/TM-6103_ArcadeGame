using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoPuntaje : Objetivo
{
    public int puntos = 1;
    public GameObject prefabTiempoNegativo;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            //player.Alerta();
            player.IncrementarPuntaje(puntos);

            GameObject.Instantiate(prefabTiempoNegativo);
            var obetivoTiempo = prefabTiempoNegativo.GetComponent<ObjetivoTiempo>();
            obetivoTiempo.ReposicionarNuevo();
        }

        base.OnTriggerEnter(other);
    }
}
