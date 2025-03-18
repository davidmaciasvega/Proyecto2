using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Lógica personalizada: saltar de "Inicio" (índice 0) al "Nivel 1"
            if (currentSceneIndex == 0) 
            {
                SceneManager.LoadScene(1); // Nivel 1 (índice 1)
            }
            else
            {
                // Pasar al siguiente nivel normalmente
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }
}
