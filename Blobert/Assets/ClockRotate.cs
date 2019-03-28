using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockRotate : MonoBehaviour {

    [SerializeField] private float maxRotation = 1f;
    private Vector3 theRotation;
	// Use this for initialization
	void Start () {
        theRotation = new Vector3(Random.Range(maxRotation * -1, maxRotation), Random.Range(maxRotation * -1, maxRotation), Random.Range(maxRotation * -1, maxRotation));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Rotate(theRotation);
	}
}
