using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressTransformEventPlaceHolderScript : TransformEventLevelScript {


    new void Start() {
        base.Start();
    }

    public override void DoEvent() {
        throw new System.Exception("Don't go this far");
    }

    // Use this for initialization
  
	
	// Update is called once per frame
	void Update () {
		
	}
}
