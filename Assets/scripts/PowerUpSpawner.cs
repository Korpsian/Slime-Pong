using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    public GameObject[] Powerups;

    public int xPosition = -40;
    public int xRange = 40;

    public int yPosition = -30;
    public int yRange = 30;

    public void SpawnPowerup()
    {
        int i = Random.Range(1, 10);
        int Powerup = Random.Range(0, Powerups.Length);

        if(i == 2 || i == 8)
        {
            Instantiate(Powerups[Powerup], new Vector2(Random.Range(xPosition, xRange), Random.Range(yPosition, yRange)), Quaternion.identity);
        }
    }
}
