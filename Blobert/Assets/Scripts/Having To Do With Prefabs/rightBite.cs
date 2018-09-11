using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightBite : MonoBehaviour {

    private MainC mainC;
	// Use this for initialization
	void Start () {
        mainC = this.transform.parent.parent.gameObject.GetComponent<MainC>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        print("there is a collision");
        if (collision.gameObject.tag.Equals("FriendlyAnimal")) {
            mainC.AddBloodLust(collision.gameObject.GetComponent<FriendlyAnimalScript>().Eaten());
        } else if (collision.gameObject.tag.Equals("Car")) {
            collision.gameObject.GetComponent<CarScript>().Activate();
        }
        //TODO implement eating an evil moop
    }
}
