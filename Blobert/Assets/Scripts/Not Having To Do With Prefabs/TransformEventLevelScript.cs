using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransformEventLevelScript : MonoBehaviour {
    public DialogueManager theDialogueManager;
    protected ObjectiveManager theObjectiveManager;

    protected void Start() {
        
        theDialogueManager = GameMaster.getCanvas().transform.Find("DialogueBox").GetComponent<DialogueManager>();
        theObjectiveManager = theDialogueManager.transform.parent.Find("ObjectiveBox").GetComponent<ObjectiveManager>();

    }




    public float GetXPosition() {
        return this.transform.position.x;
    }

    public abstract void DoEvent();

    public virtual bool IsScriptCompleted() {//supposed to be overrided
        return false;
    }

}
