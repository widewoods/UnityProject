using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    //bool isDead = false;
    public Dissolve dissolve;
    public GameObject gun;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        dissolve = GetComponent<Dissolve>();
        gun = FindObjectOfType<FireGun>().gameObject;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Platform");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) 
        {
            Debug.Log("Died");
            Die();
        }
        healthBar.SetHealth(currentHealth);

    }

    public void Die()
    {
        dissolve.StartDissolve();
        Destroy(gameObject, 1.1f);
        Destroy(gun);
        //isDead = true;
    }
}
