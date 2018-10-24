using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransformEventLevelScript : MonoBehaviour {
    public DialogueManager theDialogueManager;
    protected ObjectiveManager theObjectiveManager;
    protected bool isEventFinished;
    public bool skip;

    protected void Start() {
        
        theDialogueManager = GameMaster.getCanvas().transform.Find("DialogueBox").GetComponent<DialogueManager>();
        theObjectiveManager = theDialogueManager.transform.parent.Find("ObjectiveBox").GetComponent<ObjectiveManager>();
        isEventFinished = false;//just putting this as a placeholder value
        if (skip) {
            isEventFinished = skip;
        }
    }




    public float GetXPosition() {
        return this.transform.position.x;
    }

    public abstract void DoEvent();

    public bool IsScriptCompleted() {
        return isEventFinished;
    }

}
