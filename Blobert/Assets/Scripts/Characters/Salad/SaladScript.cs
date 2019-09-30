using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladScript : MonoBehaviour {
    [SerializeField] private float rotationRange = 0;
    private float rotationAmount;
    private int damage = 99;
    bool alreadyHitShip = false;
	// Use this for initialization
	void Start () {
        rotationAmount = Random.Range(rotationRange*-1, rotationRange);
  
	}
	
	void FixedUpdate () {
        this.transform.Rotate(0, 0, rotationAmount);

	}

    private void OnCollisionEnter2D(Collision2D collision) {
        print(collision.gameObject.tag);
        if (!alreadyHitShip && collision.gameObject.tag.Equals("BlobertSpaceShip"))
        {
            collision.transform.Find("Player").GetComponent<MainC>().Damage(damage);
            alreadyHitShip = true;
            
        }
    }
}
