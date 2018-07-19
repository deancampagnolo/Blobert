using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAnimalScript : MonoBehaviour {

    public int bloodLustPoints;
    public int defaultSavageryPoints = 10;
	// Use this for initialization
	void Start () {
        createFriendlyAnimal();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void createFriendlyAnimal() {
        bloodLustPoints = defaultSavageryPoints;
    }

    public int Eaten() {
        this.transform.rotation = new Quaternion(180, 0, 0, 0);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //Destroy(this.gameObject);

        return bloodLustPoints;
    }
}
