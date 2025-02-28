using UnityEngine;

public class DeathZ : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Asegúrate de que el Player tiene este Tag
        {
            collision.transform.position = new Vector3(-5, -1, 0); // Mueve al jugador
        }
    }
}
