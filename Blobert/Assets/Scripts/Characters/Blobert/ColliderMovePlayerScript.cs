﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMovePlayerScript : MonoBehaviour {

    [SerializeField] private float theForceUpwards;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        print("there was a collision");
        if (collision.gameObject.tag.Equals("Player")) {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0) { //only works if player is going downwards
                collision.gameObject.GetComponent<MainC>().ForceUpwards(theForceUpwards);
            }
        }
    }
}
