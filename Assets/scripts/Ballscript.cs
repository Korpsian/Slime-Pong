using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscript : MonoBehaviour {

    Animator anim;

	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 5) * 5;

        anim = GetComponent<Animator>();
	}
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        anim.SetBool("kollision", true);
        
    }

}
