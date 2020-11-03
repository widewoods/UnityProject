using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;

    bool isDissolving = false;
    public float fade = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    StartDissolve();
        //}
        if (isDissolving)
        {
            fade -= Time.deltaTime;

            if(fade <= 0)
            {
                fade = 0f;
                isDissolving = false;

                Destroy(gameObject);
            }

            material.SetFloat("_Fade", fade);
        }
    }

    public void StartDissolve()
    {
        isDissolving = true;
    }
}
