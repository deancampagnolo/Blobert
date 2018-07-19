using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventBeginningScript : TransformEventLevelScript {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void DoEvent() {
        print("yay it works");
    }
}
