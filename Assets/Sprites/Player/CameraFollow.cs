using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] float smoothing;
    [SerializeField] Vector2 maxPos;
    [SerializeField] Vector2 minPos;

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3 (target.position.x, target.position.y, transform.position.z);
            targetPos.x = Mathf.Clamp(target.position.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp (transform.position, targetPos, smoothing);
        }
    }
}
