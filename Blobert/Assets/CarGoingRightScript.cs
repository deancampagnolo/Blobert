using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGoingRightScript : MonoBehaviour {
    private float speed = 5f;
    private float amountSpedUp = .5f;
    private bool isGoingRight;

    private void Awake() {// this has to be awake for it to work.
        isGoingRight = false;
    }

    public void GoRight() {
        
        isGoingRight = true;
        GameMaster.GetFabby().GetComponent<SpriteRenderer>().enabled = false;
        GameMaster.GetPlayer().transform.Find("Animatorz").GetComponent<SpriteRenderer>().enabled = false;
        GameMaster.GetPlayer().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void FixedUpdate() {
       
        if(isGoingRight) {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            speed += amountSpedUp;
            if (speed > 80f) {
                GameMaster.GetCamera().GetComponent<camera>().FreezeCamera();
            }
        }
    }
}
