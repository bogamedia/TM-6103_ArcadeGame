using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoTiempo : Objetivo
{
    public float tiempo, cambioVelocidad;
    public Material positivo;
    public Material negativo;
    public bool reposicionar = true;

    private void Start()
    {
        if (tiempo > 0)
        {
            this.GetComponent<Renderer>().material = positivo;
        }
        else
        {
            this.GetComponent<Renderer>().material = negativo;
        }

    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Le mandamos la operacion de tiempo
            var player = other.GetComponent<Player>();
            player.ModificarTiempo(tiempo, cambioVelocidad);
        }
        if (reposicionar)
        {
            base.OnTriggerEnter(other);
        }
    }

    public void ReposicionarNuevo()
    {
        base.Reposicionar();
    }

    public void ReposicionarEspecial()
    {
        base.ReposicionarEspecial();
    }

}
