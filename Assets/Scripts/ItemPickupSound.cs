using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupSound : MonoBehaviour
{
    public AudioSource pickupSound;

    void OnCollisionEnter(Collision collision)
    {
        pickupSound.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
