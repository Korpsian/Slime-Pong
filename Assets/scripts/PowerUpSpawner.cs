using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    // Use this for initialization

    // Update is called once per frame
    void Update () {
        StartCoroutine(ExecuteAfterTime(10f));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Zeitverzögert");
        // Code to execute after the delay
    }

}
