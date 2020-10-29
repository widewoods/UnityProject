using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject player;
    public GameObject gun;

    public string mode;

    private Vector3 playerPos;
    private Vector3 gunPos;

    public bool flipped = false;

    public float bulletSpawnRate = 0.6f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    { 
        gun.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (flipped)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= bulletSpawnRate)
        {
            Shoot(mode);
            timer = 0f;
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
}
