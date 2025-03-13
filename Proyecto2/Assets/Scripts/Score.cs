using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    private int score; // Puntos acumulados
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI NivelText;
    private FirebaseManager firebaseManager; // 🔥 Ahora lo obtenemos en `Start()`

    void Start()
    {

{
    {
    GameObject botonReset = GameObject.Find("BotonReset");
    if (botonReset != null)
    {
        Debug.Log("✅ Botón encontrado en Start.");
        StartCoroutine(VerificarBoton(botonReset));
    }
    else
    {
        Debug.LogError("❌ Botón NO encontrado en Start.");
    }
}

IEnumerator VerificarBoton(GameObject boton)
{
    while (true)
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Estado del botón: " + boton.activeSelf);
    }
}
}

        // 🔥 Obtener la instancia de FirebaseManager en la escena
        firebaseManager = FindFirstObjectByType<FirebaseManager>();

        if (firebaseManager == null)
        {
        Debug.LogError("❌ FirebaseManager no encontrado en la escena.");
        GameObject firebaseObj = new GameObject("FirebaseManager");
        firebaseManager = firebaseObj.AddComponent<FirebaseManager>();
        return;
        }

        // 🔥 Cargar las monedas guardadas en Firebase
        firebaseManager.CargarProgreso((monedas, nivel) =>
        {
            score = monedas; // Cargar la cantidad de monedas guardadas
            scoreText.text = "Score: " + score; 
            NivelText.text = "Nivel: " + (SceneManager.GetActiveScene().buildIndex + 1);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moneda")
        {
            if (firebaseManager == null)
            {
                Debug.LogError("❌ No se puede guardar, FirebaseManager no está inicializado.");
                return;
            }

            score++; // Aumentar el puntaje acumulado
            scoreText.text = "Score: " + score;

            // 🔥 Guardar progreso antes de destruir la moneda
            firebaseManager.GuardarProgreso(score, SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(collision.gameObject);
        }
    }
}
