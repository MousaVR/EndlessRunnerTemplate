using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField] Vector3Variable playerPos;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 diseredPosition = playerPos.Value + offset;
        transform.position = Vector3.Lerp(transform.position, diseredPosition, Time.deltaTime * 3);
    }
}
