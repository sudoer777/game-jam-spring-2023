using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrain : MonoBehaviour
{
    public Sprite trainInside;
    public Sprite trainOutside;
    public GameObject blackout;
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            var playerIsOutside = collider.gameObject.transform.position.y > transform.position.y;
            var newTrain = playerIsOutside ? trainOutside : trainInside;
            
            var trainCars = GameObject.FindGameObjectsWithTag ("traincar");
            foreach (var trainCar in trainCars)
            {
                var spriteRenderer = trainCar.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = newTrain;
            }

            var trainConnectorCovers = GameObject.FindGameObjectsWithTag("train_connector_cover");
            foreach (var trainConnectorCover in trainConnectorCovers)
            {
                var spriteRenderer = trainConnectorCover.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = playerIsOutside;
            }

            var blackoutSr = blackout.GetComponent<SpriteRenderer>();
            blackoutSr.enabled = !playerIsOutside;
        }
    }

}
