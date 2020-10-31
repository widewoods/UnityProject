using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int health;
    bool isDead = false;
    public Dissolve dissolve;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        dissolve = GetComponent<Dissolve>();
        gun = FindObjectOfType<FireGun>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        dissolve.StartDissolve();
        Destroy(gameObject, 1.1f);
        Destroy(gun);
        isDead = true;
    }
}
