﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroblobFortressTransformEvents : MonoBehaviour {
    [HideInInspector]
    private Transform pointOfNoReturn;
    private TransformEventLevelScript[] allPoints;

    private int currentEvent;

    private string[] orderOfEvents = new string[] { "FortressTransformEventBeginning", "FortressTransformEventLevel1", "FortressTransformEventLevel2",
        "FortressTransformEventLevel3", "FortressTransformEventLevel4", "FortressTransformEventTakeoff", "FortressTransformEventBlobertTakeoff", "FortressTransformEventPlaceHolder" };

    // Use this for initialization
    void Start() {
        currentEvent = 0;
        allPoints = GameObject.FindObjectsOfType<TransformEventLevelScript>();


        //allPoints = (TransformEventLevelScript[])ReverseOrderOfArray(allPoints);
        OrganizeAllPoints();
        RemoveSkipPoints();

    }

    // Update is called once per frame
    void FixedUpdate() {
        //print(GameMaster.GetPlayer().transform.position.x);
        if ((GameMaster.GetPlayer().transform.position.x > allPoints[currentEvent].GetXPosition()) && !allPoints[currentEvent].IsScriptCompleted()) {//and not completed
            allPoints[currentEvent].DoEvent();
            currentEvent++;
            print(currentEvent);
        }
    }


    public TransformEventLevelScript getCurrentScript() {
        return allPoints[currentEvent - 1]; //because "current event" is technically next event
    }

    private Object[] ReverseOrderOfArray(Object[] array) {
        Object temp;
        for (int i = 0; i < array.Length / 2; i++) {
            temp = array[i];
            array[i] = array[array.Length - 1 - i];
            array[array.Length - 1 - i] = temp;
            i++;
        }

        return array;
    }

    private void OrganizeAllPoints() {
        for (int i = 0; i < allPoints.Length; i++) {
            if (!allPoints[i].name.Equals(orderOfEvents[i])) {//if it does not equal
                int index = GetIndexOfToStringInAllPoints(orderOfEvents[i], i);
                TransformEventLevelScript temp = allPoints[i];
                allPoints[i] = allPoints[index];
                allPoints[index] = temp;
            }
        }

    }

    private void RemoveSkipPoints() {
        int counter = 0;

        for (int i = 0; i < allPoints.Length; i++) {
            if (allPoints[i].IsScriptCompleted()) {
                allPoints[i] = null;
            } else {
                counter++;
            }
        }

        TransformEventLevelScript[] newAllPoints = new TransformEventLevelScript[counter];

        int currentNewIndex = 0;

        for (int i = 0; i < allPoints.Length; i++) {
            if (allPoints[i] != null) {
                newAllPoints[currentNewIndex] = allPoints[i];
                currentNewIndex++;
            }
        }
        allPoints = newAllPoints;
    }

    private int GetIndexOfToStringInAllPoints(string theString, int minimumIndex) {
        for (int i = minimumIndex; i < allPoints.Length; i++) {

            if (allPoints[i].name.Equals(theString)) {
                return i;
            }
        }
        throw new System.Exception("GetIndexOfToStringInAllPoints does not contain theString");
    }

}
