using System;
using System.Collections;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    public Transform target;
    public float yOffset = 2f;
    public float damping = 1;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;

    float offsetZ;
    Vector3 lastTargetPosition;
    Vector3 currentVelocity;
    Vector3 lookAheadPos;
    
    //Use this for initialization
    private void Start()
    {
        lastTargetPosition = target.position;
        offsetZ = (transform.position - target.position).z;
        transform.parent = null;
    }
    //Update is called once per frame
    void Update()
    {
        if (!target) return;
        //only update lookahead pos if accelerating or changed direction
        float xMoveDelta = (target.position - lastTargetPosition).x;
        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            lookAheadPos = Vector3.right * (lookAheadFactor * Mathf.Sign(xMoveDelta));
        }
        else
        {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ + Vector3.up*yOffset;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);
        transform.position = newPos;
        lastTargetPosition = target.position;
    }
}
