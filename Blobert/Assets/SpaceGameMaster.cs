using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGameMaster : MonoBehaviour {

    [SerializeField] private GameObject troblobShip;
    [SerializeField] private GameObject blobertShip;
    [SerializeField] private float scrollingSpeedY;


	// Use this for initialization
	void Start () {
        SetScrollingSpeedY();   
	}

    private void SetScrollingSpeedY() {
        troblobShip.GetComponent<Rigidbody2D>().velocity = troblobShip.GetComponent<Rigidbody2D>().velocity + new Vector2(0, scrollingSpeedY);
        blobertShip.GetComponent<Rigidbody2D>().velocity = blobertShip.GetComponent<Rigidbody2D>().velocity + new Vector2(0, scrollingSpeedY);
    }
	
    public GameObject GetTroblobShip() {
        return troblobShip;
    }

    public GameObject GetBlobertShip() {
        return blobertShip;
    }

	// Update is called once per frame
	void FixedUpdate () {
		


	}
}
