using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladScript : MonoBehaviour {
    [SerializeField] private float rotationRange = 0;
    private float rotationAmount;
	// Use this for initialization
	void Start () {
        rotationAmount = Random.Range(rotationRange*-1, rotationRange);
  
	}
	
	void FixedUpdate () {
        this.transform.Rotate(0, 0, rotationAmount);

	}
}
