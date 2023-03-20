using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject trainCar;

    public Vector3 missileLocation;

    public GameObject explosion;

    public GameObject player;
    public Camera camera;
    public GameObject missile;

    private float startTime = -1.0f;
    private float originalCameraSize = 0.0f;

    void Update()
    {
        if (startTime >= 0.0f)
        {
            if (Time.time - startTime >= 1.0f)
            {
                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            startTime = Time.time;
            
            var asraScript = player.GetComponent<Script.Asra.Movement>();
            var cieraScript = player.GetComponent<Script.Ciara.Movement>();
            var asraEnabled = asraScript.enabled;
            var cieraEnabled = cieraScript.enabled;
            asraScript.enabled = false;
            cieraScript.enabled = false;

            originalCameraSize = camera.orthographicSize;
            camera.orthographicSize = 5.0f;

            // Instantiate(explosion, missileLocation, Quaternion.identity);
            // Instantiate(missile, missileLocation, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
