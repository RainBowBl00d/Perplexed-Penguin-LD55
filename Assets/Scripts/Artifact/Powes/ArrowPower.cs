using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPower : MonoBehaviour
{
    float maxRange = 3f;
    float minRange = 0.5f;
    float farEnough = 20f;
    float closeEnough = 2f;
    [SerializeField] float zOffset;
    [SerializeField] float yOffset;
    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 closestPoint = FindClosestArtifact(playerPos);
        if (closestPoint == Vector2.zero)
        {
            gameObject.transform.position = playerPos + Vector2.up * yOffset;
            gameObject.transform.Rotate(new(0, 0, 1f), Space.World);
        }
        else
        {
            float dist = Vector2.Distance(playerPos, closestPoint);

            Vector2 arrowPos = new();

            arrowPos = InterpolatedPosition(playerPos, closestPoint);

            Vector2.ClampMagnitude(arrowPos, maxRange);



            float rotation = GetQuaternion(closestPoint, playerPos) - zOffset;

            gameObject.transform.SetPositionAndRotation(arrowPos, Quaternion.Euler(0, 0, rotation));
            gameObject.transform.position = arrowPos;
        }

    }
    Vector2 FindClosestArtifact(Vector2 playerPos)
    {
        GameObject[] artifacts = GameObject.FindGameObjectsWithTag("Artifact");

        float minDist = float.MaxValue;
        Vector2 closestPoint = new Vector2();
        foreach (GameObject artifact in artifacts)
        {
            if (minDist > Vector2.Distance(artifact.transform.position, playerPos) && artifact !=  gameObject)
                {
                minDist = Vector2.Distance(artifact.transform.position, playerPos);
                closestPoint = artifact.transform.position;
            }
        }
        return closestPoint;
    }
    public Vector2 InterpolatedPosition(Vector2 playerPos, Vector2 targetPos)
    {
        Vector2 direction = targetPos - playerPos;

        float distance = direction.magnitude;

        float interpolitedDistance = Mathf.Lerp(closeEnough, farEnough, distance);

        float clampedDistance = Mathf.Clamp(interpolitedDistance, minRange, maxRange);

        Vector2 targetPosition = playerPos + direction.normalized * clampedDistance;

        return targetPosition;
    }

    float GetQuaternion(Vector2 pointTowards, Vector2 playerPos)
    {
        Vector2 direction = pointTowards - playerPos;
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return rotation;
    }
}
