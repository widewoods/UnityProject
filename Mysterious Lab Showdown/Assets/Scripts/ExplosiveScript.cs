using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveScript : MonoBehaviour
{
    public int explosionDmg;
    public float explosionRad;
    public float explosionPower;

    public GameObject explosionPrefab;
    public EnemyScript enemy;
    public PlayerScript player;
    public GameObject platform;
    public CameraShake cam;

    private Collider2D[] colliders;

    private void Start()
    {
        cam = FindObjectOfType<CameraShake>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            colliders = Physics2D.OverlapCircleAll(transform.position, explosionRad);
            foreach(Collider2D col in colliders)
            {
                if (col.gameObject.CompareTag("Player"))
                {
                    player = col.gameObject.GetComponent<PlayerScript>();
                    Explode(explosionPower, explosionRad, col.gameObject);
                    player.TakeDamage(explosionDmg);
                }
                if (col.gameObject.CompareTag("Enemy"))
                {
                    enemy = col.gameObject.GetComponent<EnemyScript>();
                    Explode(explosionPower, explosionRad, col.gameObject);
                    enemy.TakeDamage(explosionDmg);
                }

                else
                {
                    Explode(0, 0, gameObject);
                }
            }
        }
    }

    void Explode(float explosionPower, float explosionRadius, GameObject hitObject)
    {
        Vector3 hitObjectPos = hitObject.transform.position;
        Vector3 barrelPos = transform.position;
        Vector3 displacement = hitObjectPos - barrelPos;
        Vector3 direction = displacement.normalized;
        float distance = displacement.magnitude;

        if(hitObject.GetComponent<Rigidbody2D>() != null)
        {
            if(distance <= explosionRadius)
            {
                hitObject.GetComponent<Rigidbody2D>().AddForce(direction * explosionPower, ForceMode2D.Impulse);
                
            }
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.05f);
        FindObjectOfType<SoundManager>().Play("Explosion");
    }
}
