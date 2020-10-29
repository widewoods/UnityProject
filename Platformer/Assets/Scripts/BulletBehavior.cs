using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 10f;
    Rigidbody2D rb;

    public GameObject bulletExplosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.right * Time.deltaTime * bulletSpeed);
        rb.velocity = transform.right * bulletSpeed;

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Explode();
            Destroy(collision.gameObject);
        }

        else if (!collision.gameObject.CompareTag("Player"))
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
