using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEventLevelMeetFairyScript : TransformEventLevelScript {

    private GameObject fairySpawnPoint;
    [SerializeField] private GameObject fabbyFairyPrefab;
    new void Start() {
        base.Start();
        fairySpawnPoint = this.transform.parent.Find("FairySpawnPoint").gameObject;
    }

    public override void DoEvent() {
        if (GameObject.Find("FabbyTheFairy") == null) {
            Instantiate(fabbyFairyPrefab, fairySpawnPoint.transform.position, fairySpawnPoint.transform.rotation);
        }

        theDialogueManager.SendDialogue("fabby","Y0 w4z p0pp1n b10B3rt!");
        theDialogueManager.SendDialogue("fabby", "eye mah just f0110w yue");
        theDialogueManager.SendDialogue("fabby", "ahsk m3 questioinz 1f u w4nT");
    } 

    // Use this for initialization
   
	
	// Update is called once per frame
	void Update () {
		
	}
}
