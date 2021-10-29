using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoResetearCubosRojos : Objetivo
{

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();

            if (player.cubosRojos == 5)
            {
                player.cubosRojos--;
            }

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
