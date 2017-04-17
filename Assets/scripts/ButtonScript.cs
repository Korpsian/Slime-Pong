using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    public void Restart ()
    {
        Debug.Log("Button Press");
        
    }

    public void StartGame ()
    {
        SceneManager.LoadScene("testumgebung", LoadSceneMode.Single);
    }

}
