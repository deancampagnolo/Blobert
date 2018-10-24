using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalHazards : MonoBehaviour {

   // private MainC mainC; //cant use this because it changes whenever main character dies
    public int damage = 10;
	// Use this for initialization
	void Start () {
        //mainC = GameMaster.GetPlayer().GetComponent<MainC>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision) {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Player")) {
            collision.gameObject.GetComponent<MainC>().Damage(damage);
        }
    }
}
