using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAnimalScript : MonoBehaviour {

    public int bloodLustPoints;
    public int defaultSavageryPoints = 10;
    private bool isAlive;

	// Use this for initialization
	void Start () {
        createFriendlyAnimal();
        isAlive = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void createFriendlyAnimal() {
        bloodLustPoints = defaultSavageryPoints;
    }

    public bool IsAlive() {
        return isAlive;
    }

    public int Eaten() {
        isAlive = false;
        this.transform.rotation = new Quaternion(180, 0, 0, 0);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //Destroy(this.gameObject);

        return bloodLustPoints;
    }
}
