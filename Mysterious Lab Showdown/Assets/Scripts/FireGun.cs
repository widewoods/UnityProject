using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpawnRate = 1f;
    private float timer;
    public CameraShake cam;
    public GameObject muzzle;

    private void Start()
    {
        cam = FindObjectOfType<CameraShake>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //On mouse click create bullet moving forward
        if (Input.GetButton("Fire1"))
        {
            
            if(timer >= bulletSpawnRate)
            {
                Shoot();
                timer = 0f;
            }   
            
        }
    }
     
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        StartCoroutine(cam.Shake(3, 3, 0.1f));
        FindObjectOfType<SoundManager>().Play("BulletShot");
        StartCoroutine(ActivateMuzzleFlash(0.07f));
    }

    IEnumerator ActivateMuzzleFlash(float waitTime)
    {
        muzzle.SetActive(true);

        yield return new WaitForSeconds(waitTime);

        muzzle.SetActive(false);
    }
}
