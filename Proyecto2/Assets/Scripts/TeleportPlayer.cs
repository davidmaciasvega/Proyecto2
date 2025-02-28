using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
       private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           transform.position = new Vector3(-5, -1, 0);
        }
    }
}
