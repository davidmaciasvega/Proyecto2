    using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    public GameObject endCanvas; // Arrastra tu Canvas aquí desde el inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu jugador tenga la etiqueta "Player"
        {
            endCanvas.SetActive(true); // Activa el Canvas
        }
    }
}
