using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float explosionRadius = 1.2f;

    public float projectileSpeed = 10f;
    private Transform _circle;
    private Collider2D _playerCollider;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    public AudioSource _audioSource;
    public AudioClip _audioClip;

    private bool canPlay = true;

    public float jumpForce = 30f;

    public GameObject splash;

    //void Update() => transform.right = rb.velocity;

    private void Start()
    {
        GameObject circle = GameObject.FindGameObjectWithTag("Circle");
        _circle = circle.transform;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerCollider = player.GetComponent<Collider2D>();
        // set projectile speed from player prefs

        Physics2D.IgnoreCollision(_playerCollider, GetComponent<Collider2D>());
        SetStraightVelocity();
    }

    public void setJumpForce(float jumpForce)
    {
        this.jumpForce = jumpForce;
    }

    void Update() => transform.right = rb.velocity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target")
        {
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }

        if (collision.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Enemny")
        {
            Destroy(gameObject);
        }


    }
    void SetStraightVelocity()
    {
        //projectileSpeed = PlayerPrefs.GetFloat("ProjectileSpeed");
        var direction = (_circle.position - transform.position).normalized;
        //transform.position+=
        rb.velocity = direction * projectileSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (explosionEffect)
        //{
        //    Instantiate(explosionEffect, transform.position, Quaternion.identity);
        //}
        rb.velocity = Vector2.zero;

        Debug.Log("on collision enter called");
        // Notify PlayerController
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Player"))
            {
                nearbyObject.GetComponent<PlayerController>()?.TriggerExplosionJump(transform.position, jumpForce);
            }
        }
        if (canPlay)
        {
            canPlay = false;
            _audioSource.PlayOneShot(_audioClip);
            GameObject splashEffect = Instantiate(splash, transform.position, Quaternion.identity);
        }

        Invoke("Destroy", 0.1f);

    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
