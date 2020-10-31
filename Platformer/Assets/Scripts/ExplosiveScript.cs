using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveScript : MonoBehaviour
{
    public int explosionDmg;
    public float explosionRad;

    public GameObject explosionPrefab;
    public EnemyScript enemy;
    public PlayerScript player;

    CircleCollider2D radius;

    private void Start()
    {
        radius = GetComponent<CircleCollider2D>();
        radius.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Explode(explosionRad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<EnemyScript>();
            enemy.TakeDamage(explosionDmg);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerScript>();
            player.TakeDamage(explosionDmg);
        }
    }

    void Explode(float explosionRadius)
    {
        radius.radius = explosionRadius;
        radius.enabled = true;
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.21f);

        FindObjectOfType<SoundManager>().Play("Explosion");
    }
}
