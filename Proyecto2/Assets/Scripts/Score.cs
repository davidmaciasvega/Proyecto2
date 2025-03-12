using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;

    void Start()
    {
        score = 0;
        Debug.Log("Score está activo");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moneda")
        {
            score++; // Incrementar el score
            Debug.Log("¡Moneda recogida! Cantidad: " + score);

            Destroy(collision.gameObject); // Destruir la moneda, no el Player
        }
    }
}
