using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrain : MonoBehaviour
{
    public Sprite trainInside;
    public Sprite trainOutside;
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            var newTrain =
                collider.gameObject.transform.position.y > transform.position.y ? trainOutside : trainInside;
            var trainCars = GameObject.FindGameObjectsWithTag ("traincar");
            foreach (var trainCar in trainCars)
            {
                var spriteRenderer = trainCar.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = newTrain;
            }
        }
    }

}
