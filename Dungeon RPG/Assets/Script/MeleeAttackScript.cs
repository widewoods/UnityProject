using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Todo: Add inventory to hold multiple items

public class MeleeAttackScript : MonoBehaviour
{
    public MeleeWeaponData weaponData;

    private GameObject weapon;

    public GameObject player;

    public GameObject trail;

    void Start()
    {
        trail.SetActive(false);
        weapon = gameObject;
        transform.parent = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Swing(weaponData.swingSpeed));
            //Swing(weaponData.swingSpeed);
        }
    }

    IEnumerator Swing(float swingSpeed)
    {
        trail.SetActive(true);

        weapon.transform.localRotation = Quaternion.Euler(0f, 0f, -105f);

        //Add swing animation
        int i = 0;
        while (i < 50)
        {
            weapon.transform.localRotation = Quaternion.Slerp(weapon.transform.localRotation, Quaternion.Euler(0f, 0f, 15f), Time.deltaTime * swingSpeed);
            yield return new WaitForEndOfFrame();
            i++;
        }
        yield return null;

        weapon.transform.localRotation = Quaternion.Euler(0f, 0f, -45f);

        trail.SetActive(false);
    }
}
