using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject player;
    public GameObject gun;
    public ParticleSystem particle;
    public SpriteRenderer sprite;
    public BoxCollider2D coll;
    public Dissolve dissolve;

    public static int enemyCount;
    public float enemyHealth;

    public string mode;

    private Vector3 playerPos;
    private Vector3 gunPos;

    public bool isFlipped = false;
    bool isDead = false;

    public float bulletSpawnRate = 0.6f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount += 1;

        particle = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        dissolve = GetComponent<Dissolve>();

        gun.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (isFlipped)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            timer += Time.deltaTime;
            if (timer >= bulletSpawnRate)
            {
                Shoot(mode);
                timer = 0f;
            }
        }

    }

    void Shoot(string mode)
    {
        if(mode == "follow")
        {
            gun.transform.LookAt(player.transform);
            //playerPos = Camera.main.WorldToScreenPoint(player.transform.position);
            //gunPos = Camera.main.WorldToScreenPoint(gun.transform.position);

            //Vector2 direction;

            //direction.x = playerPos.x - gunPos.x;
            //direction.y = playerPos.y - gunPos.y;

            //float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            //gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        else if(mode == "straight")
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        
    }

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    void Die()
    {
        //sprite.enabled = false;
        coll.enabled = false;
        if (isFlipped)
        {
            Flip();
        }
        dissolve.StartDissolve();
        //particle.Play();
        Destroy(gameObject, 1.1f);
        Destroy(gun);
        isDead = true;

        enemyCount -= 1;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if(enemyHealth <= 0)
        {
            Die();
        }
    }
}
