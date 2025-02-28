using UnityEngine;

public class ProfesorM : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 8f;
    public float jumpForce = 12f;
    private Rigidbody2D rigidbody2D;
    private float horizontal;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float lastShoot;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        // Detección de suelo usando Raycast
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.2f, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector2.down * 0.2f, Color.red);

        // Cambiar la escala del personaje según la dirección del movimiento
        if (horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-3, 3, 1);
        }
        else if (horizontal > 0.0f)
        {
            transform.localScale = new Vector3(3, 3, 1);
        }

        // Detectar entrada de salto (Space o flecha hacia arriba)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Detectar disparo (tecla E)
        if (Input.GetKey(KeyCode.E) && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector2 direction;
        if (transform.localScale.x == 3)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }

        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(direction.x * 0.6f, 0, 0), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 10; // Usar velocity en lugar de linearVelocity
    }

    void FixedUpdate()
    {
        // Movimiento horizontal preservando velocidad vertical
        rigidbody2D.linearVelocity = new Vector2(horizontal * speed, rigidbody2D.linearVelocity.y);
    }
}
