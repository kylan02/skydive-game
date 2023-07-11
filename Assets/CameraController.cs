using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothness = 0.05f;

    private void LateUpdate() {
        Vector3 targetPosition = player.position + offset;
        Vector3 lerpPosition = Vector3.Lerp(transform.position, targetPosition, smoothness);
        lerpPosition.y = targetPosition.y;
        transform.position = lerpPosition;
    }
}
