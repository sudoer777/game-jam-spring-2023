using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject trainCar;

    public Vector3 missileLocation;

    public GameObject explosion;

    public GameObject player;
    public Camera camera;
    public GameObject missile;
    public Sprite explodedTrainCar;

    private float startTime = -1.0f;
    private float originalCameraSize = 0.0f;
    private bool exploded = false;
    private GameObject bullet;

    void Update()
    {
        if (startTime >= 0.0f)
        {
            if (!exploded && Time.time - startTime >= 0.75f)
            {
                Destroy(bullet);
                Instantiate(explosion, missileLocation, Quaternion.identity);
                
                exploded = true;
            }

            if (Time.time - startTime >= 1.0f)
            {
                var sr = trainCar.GetComponent<SpriteRenderer>();
                sr.sprite = explodedTrainCar;
            }

            if (Time.time - startTime >= 2.0f)
            {
                var asraScript = player.GetComponent<Script.Asra.Movement>();
                asraScript.enabled = true;
                
                var switchCharScript = player.GetComponent<switchChar>();
                switchCharScript.enabled = true;
                
                camera.orthographicSize = 3.0f;

                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            startTime = Time.time;

            // var switchCharScript = player.GetComponent<switchChar>();
            // switchCharScript.enabled = false;

            var asraScript = player.GetComponent<Script.Asra.Movement>();
            // var cieraScript = player.GetComponent<Script.Ciara.Movement>();
            // var asraEnabled = asraScript.enabled;
            // var cieraEnabled = cieraScript.enabled;
            asraScript.enabled = false;
            // cieraScript.enabled = false;

            var rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, 0);

            var animator = player.GetComponent<Animator>();
            animator.Play("Idle");

            // originalCameraSize = camera.orthographicSize;
            camera.orthographicSize = 5.0f;

            bullet = Instantiate(missile, missileLocation + new Vector3(0.2f, 0.5f, 0.0f), Quaternion.FromToRotation(Vector3.right, Vector3.down));
        }
    }

}
