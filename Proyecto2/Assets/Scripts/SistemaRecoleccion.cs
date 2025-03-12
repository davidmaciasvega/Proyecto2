using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaRecoleccion : MonoBehaviour
{
    public int cantidadMonedas = 0; // Inicializamos con 0

   private void Start()
{
    Debug.Log("SistemaRecoleccion está activo");
}



    private void OnTriggerEnter2D(Collider2D col)
    {
    Debug.Log("Colisión detectada con: " + col.gameObject.name);

    if (col.gameObject.tag == ("Player"))
    {
        Destroy(this.gameObject);
        cantidadMonedas++;
        Debug.Log("¡Moneda recogida! Cantidad: " + cantidadMonedas);
    }
}
}
