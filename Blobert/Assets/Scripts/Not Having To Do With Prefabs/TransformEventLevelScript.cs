using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransformEventLevelScript : MonoBehaviour {
    int i = 1;
	

    public float GetXPosition() {
        return this.transform.position.x;
    }

    public abstract void DoEvent();
}
