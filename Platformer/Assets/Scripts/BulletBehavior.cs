using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public int bulletDamage = 20;
    public float bulletSpeed = 10f;
    Rigidbody2D rb;

    public GameObject bulletExplosionPrefab;

    public EnemyScript enemy;
    public PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<EnemyScript>();
            enemy.TakeDamage(bulletDamage);
            Destroy(gameObject);
            Explode();
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerScript>();
            player.TakeDamage(bulletDamage);
            Destroy(gameObject);
            Explode();
        }
        else
        {
            Destroy(gameObject);
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(bulletExplosionPrefab, transform.position, transform.rotation);
    }

    
}
