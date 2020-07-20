using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public float damageAmount = 10f;

    public GameObject hitParticlePrefab;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteorite"))
        {
            Meteorite meteorite = collision.gameObject.GetComponent<Meteorite>();

            if (meteorite != null)
            {
                FindObjectOfType<Score>().AddPoints(10);
                meteorite.DestroyMeteorite();

                GameObject particles = Instantiate(hitParticlePrefab, transform.position, transform.rotation);
                Destroy(particles, 5f);
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                FindObjectOfType<Score>().AddPoints(20);
                enemy.Damage(damageAmount);

                GameObject particles = Instantiate(hitParticlePrefab, transform.position, transform.rotation);
                Destroy(particles, 5f);
                Destroy(this.gameObject);
            }
        }
    }
}
