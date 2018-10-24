using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FireLegCannonLeft(int i) {
        
        transform.Find("leftBlastPoint").gameObject.GetComponent<LegCannon>().Fire(i);
       
    }
}
