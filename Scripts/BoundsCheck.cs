using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BoundsCheck : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 0.7f;
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]

    public float camWidth;
    public float camHeight;

    [HideInInspector]
    public bool offRight, offLeft, offUp, offDown;

    public bool isOnScreen = true;

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {

        Vector2 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            offRight = true;
        }

        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            offLeft = true;
        }

        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            offUp = true;
        }

        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            offDown = true;
        }

        isOnScreen = !(offRight || offLeft || offUp || offDown);

        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }

    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Vector2 boundSize = new Vector2(camWidth * 2, camHeight * 2);

        Gizmos.DrawWireCube(Vector2.zero, boundSize);
    }
}
