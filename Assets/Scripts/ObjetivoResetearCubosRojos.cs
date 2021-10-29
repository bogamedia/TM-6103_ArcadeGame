using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoResetearCubosRojos : Objetivo
{

    public int puntos = 1;
    public float cambioVelocidad;
    public GameObject prefabTiempoNegativo;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();

            player.IncrementarPuntaje(puntos, cambioVelocidad);

            GameObject.Instantiate(prefabTiempoNegativo);
            var obetivoTiempo = prefabTiempoNegativo.GetComponent<ObjetivoTiempo>();
            obetivoTiempo.ReposicionarNuevo();

            //player.Alerta();
        }

        base.OnTriggerEnter(other);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
