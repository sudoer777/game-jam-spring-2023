using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject trainCar;

    public Vector3 missileLocation;

    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, missileLocation, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
