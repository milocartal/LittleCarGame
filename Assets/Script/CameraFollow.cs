using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;

    //[SerializeField] private Transform target;
    //target = Transform.FindGameObjectsWithTag("Player");
    //GameObject[] target = GameObject.FindGameObjectsWithTag("Player");
    private GameObject targetPlayer;

    void Start()
    {
        targetPlayer = GameObject.FindWithTag("Player");
    }


// Update is called once per frame
void Update()
    {
        if (!targetPlayer)
        {
            targetPlayer = GameObject.FindWithTag("Player");
        }
        else
        {
            Vector3 targetPosition = targetPlayer.transform.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

    }
}
