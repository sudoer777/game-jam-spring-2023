using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamera : MonoBehaviour
{
    // private Vector3 offset = new Vector3(0f, 2.130828f, -10f);
    private Vector3 offset = new Vector3(0f, 0.25f, -10f);
    public float smoothTime = 0.05f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
