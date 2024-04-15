using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCamera : MonoBehaviour
{   
    float GetCameraLookAhead()
    {
        float scale = PlayerStats.instance.velocity.x / PlayerStats.instance.maxSpeed;
        return scale * PlayerStats.instance.cameraLookAhead;
    }
    private void Update()
    {
        Vector2 offsetPos = new(GetCameraLookAhead(), PlayerStats.instance.yCameraOffset);
        Vector2 targetPos = (Vector2) transform.position + offsetPos;
        Vector2 desiredPos = Vector2.Lerp(Camera.main.transform.position, targetPos, PlayerStats.instance.cameraMoveSpeed * Time.deltaTime);

        Camera.main.transform.position = new(desiredPos.x, desiredPos.y, -PlayerStats.instance.ScreenSize);
    }
}
