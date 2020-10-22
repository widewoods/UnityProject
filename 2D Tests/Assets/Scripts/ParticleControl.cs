using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem dust;
    // Start is called before the first frame update
    void Start()
    {
        dust = gameObject.GetComponent<ParticleSystem>();
        dust.Emit(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
