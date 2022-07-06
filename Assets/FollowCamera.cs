using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject actor;
    [SerializeField] int cameraDistanceToActor = -10;
    void LateUpdate()
    {
        transform.position = actor.transform.position + new Vector3 (0, 0, cameraDistanceToActor);
    }
}
