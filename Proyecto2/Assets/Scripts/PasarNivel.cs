
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // Verifica que el objeto con el que colisiona tiene la etiqueta "Player"
        if (col.CompareTag("Player"))
        {
            // Carga la siguiente escena (de acuerdo al índice de la escena actual)
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}