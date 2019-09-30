using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceEvents : TransformEventLevelScript {
    protected float scrollingSpeedX;

    protected SpaceGameMaster sgm;
    //protected DialogueManager theDialogueManager;
    //protected ObjectiveManager theObjectiveManager;


    protected void Start() {

        base.Start();
        sgm = GameObject.Find("GM").GetComponentInChildren<SpaceGameMaster>();
        //theDialogueManager = base.theDialogueManager;
        //theObjectiveManager = base.theObjectiveManager;
        scrollingSpeedX = 10;
    }

    //public abstract bool SpaceFinished();
}
