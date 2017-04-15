using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool IsLeftPlayer = false;
    public float XSpeed = 0.65f;
    public float YSpeed = 0.65f;
    public float YBoundryRange = 17.5f;
    public float XBoundryRange = 30;
    public float XBoundryMinimumRange = 0.5f;

    private bool WasPressedLastFrame = false;

    void Start()
    {
    }

    public void FixedUpdate()
    {
        XPlayerMovement();
        YPlayerMovement();
    }

    private void XPlayerMovement()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (!WasPressedLastFrame)
            {
                MovePlayerToCenter();
            }
            WasPressedLastFrame = true;
        }
        else
        {
            WasPressedLastFrame = false;
        }

    }

    private void MovePlayerToCenter()
    {
        float direction = XSpeed;

        if (IsLeftPlayer)
        {
            gameObject.transform.position = new Vector2( Mathf.Clamp(gameObject.transform.position.x + direction, -XBoundryRange, -XBoundryMinimumRange), gameObject.transform.position.y);
        }
        else
        {
            direction *= -1;

            gameObject.transform.position = new Vector2(Mathf.Clamp(gameObject.transform.position.x + direction, XBoundryMinimumRange, XBoundryRange), gameObject.transform.position.y);
        }


    }

    private void YPlayerMovement()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y + Input.GetAxisRaw("Vertical") * YSpeed, -YBoundryRange, YBoundryRange));
    }
}
