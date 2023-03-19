using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject trainCar;

    public Vector3 missileLocation;

    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, missileLocation, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
