using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRightScript : MonoBehaviour {

    private float speed = 80f;

    private void FixedUpdate() {

         this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.GetComponent<Rigidbody2D>().velocity.y);
           
            
    }


}
