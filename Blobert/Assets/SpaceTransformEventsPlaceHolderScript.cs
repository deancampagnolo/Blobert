using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformEventsPlaceHolderScript : SpaceEvents {
    public override void DoEvent() {
        //theDialogueManager.SendDialogue("fabby", "hi");
        StartCoroutine(WasteTime());
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator WasteTime() {
        while (true) {
            yield return new WaitForSeconds(2f);
            print("FUCK");
        }
    }
}
