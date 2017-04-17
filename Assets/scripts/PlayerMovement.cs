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

    GameObject Manager;
    GameObject Ball;

    //Vector zum Abrufen der Startposition
    Vector2 StartPosition;

    //Variablen für das einsetzen der Input Achsen
    private string InputAxeHorizontal = "SP2 Horizontal";
    private string InputAxeVertikal = "SP2 Vertikal";

    //Dient zum raufzählen, wenn der Spieler 3 mal gedrückt hat bewegt er sich ein stück in die mitte
    private int Counter = 0;

    void Start()
    {
        //Dient zum zurücksetzen der Spieler
        StartPosition = transform.position;

        //Wenn Linker spieler, ersetze input achsen durch die von SP1
        if (IsLeftPlayer == true)
        {
            InputAxeHorizontal = "SP1 Horizontal";
            InputAxeVertikal = "SP1 Vertikal";
        }

        Manager = GameObject.Find("Score Manager");
        Ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public void FixedUpdate()
    {
        XPlayerMovement();
        YPlayerMovement();
    }

    private void XPlayerMovement()
    {
        //Wenn Button von Horizontal Achse gedrückt wird und größer als 0 Setze Counter rauf
        if (Input.GetButtonDown(InputAxeHorizontal) && Input.GetAxisRaw(InputAxeHorizontal) > 0)
        {
            Debug.Log ("Counter + 1");
            Counter = Counter + 1;

            //Wenn Counter = 3 Bewege Player und setze Counter zurück
                if (Counter == 1)
                {
                    Debug.Log("Reset Counter + MovePlayerToCenter()");
                    Counter = 0;
                    MovePlayerToCenter();
                }

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
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y + Input.GetAxisRaw(InputAxeVertikal) * YSpeed, -YBoundryRange, YBoundryRange));
    }

    //Wenn Kollision mit ball, bewege ein schritt zurück
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Kollision");
        if(col.gameObject.tag == "Ball")
        {
            Vector2 objectPosition = transform.position;
            Debug.Log("HIT Geh zurück!");

            if (IsLeftPlayer == true)
            {
                objectPosition.x = objectPosition.x - 1f;
                transform.position = objectPosition;
            }
            else
            {
                objectPosition.x = objectPosition.x + 1f;
                transform.position = objectPosition;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PointSP1")
        {
            Manager.GetComponent<ScoreManager>().SP1 = Manager.GetComponent<ScoreManager>().SP1 + 1;
            Destroy(Ball);
            Manager.GetComponent<ScoreManager>().UpdateScore();
        }

        if (col.gameObject.tag == "PointSP2")
        {
            Manager.GetComponent<ScoreManager>().SP2 = Manager.GetComponent<ScoreManager>().SP2 + 1;
            Destroy(Ball);
            Manager.GetComponent<ScoreManager>().UpdateScore();
        }
    }

    public void JumpBack()
    {
        transform.position = StartPosition;
    }

}

