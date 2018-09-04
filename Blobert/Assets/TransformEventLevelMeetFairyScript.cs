using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevelMeetFairyScript : TransformEventLevelScript {

    //[SerializeField] private GameObject fabbyFairyPrefab;
    new void Start() {
        base.Start();
    }

    public override void DoEvent() {
        theDialogueManager.SendDialogue("fabby","Y0 w4z p0pp1n b10B3rt!");
        theDialogueManager.SendDialogue("fabby", "eye mah just f0110w yue");
        theDialogueManager.SendDialogue("fabby", "ahsk m3 1f u");
    } 

    // Use this for initialization
   
	
	// Update is called once per frame
	void Update () {
		
	}
}
