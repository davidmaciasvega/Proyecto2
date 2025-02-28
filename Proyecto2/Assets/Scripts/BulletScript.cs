using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public interface IBulletScript
{
    void DestroyBullet();
    void SetDirection(Vector3 direction);
}

public interface IBulletScript1
{
    void DestroyBullet();
    void SetDirection(Vector3 direction);
}

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class BulletScript : MonoBehaviour, IBulletScript, IBulletScript1
{
    public float Speed;
    public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = Direction * Speed;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}