using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformEvents : MonoBehaviour {
    
    private SpaceEvents[] allPoints;

    private int currentEvent;

    private string[] orderOfEvents = new string[] { "SpaceTransformEventsLevel1", "SpaceTransformEventsPlaceHolder" };

    // Use this for initialization
    void Start() {
        currentEvent = 0;
        allPoints = GameObject.FindObjectsOfType<SpaceEvents>();


        //allPoints = (TransformEventLevelScript[])ReverseOrderOfArray(allPoints);
        OrganizeAllPoints();
        RemoveSkipPoints();

        allPoints[currentEvent].DoEvent();
        currentEvent++;
        print(currentEvent);

    }

    // Update is called once per frame
    void FixedUpdate() {
        //print(GameMaster.GetPlayer().transform.position.x);
        

        if (allPoints[currentEvent].IsScriptCompleted()) {//I honestly don't know what is wrong with this code, if it changes the whole thing collapses :/
            allPoints[currentEvent].DoEvent();
            currentEvent++;
            print(currentEvent);
        }
    }


    public SpaceEvents getCurrentScript() {
        return allPoints[currentEvent - 1]; //because "current event" is technically next event
    }


    private void OrganizeAllPoints() {
        for (int i = 0; i < allPoints.Length; i++) {
            if (!allPoints[i].name.Equals(orderOfEvents[i])) {//if it does not equal
                int index = GetIndexOfToStringInAllPoints(orderOfEvents[i], i);
                SpaceEvents temp = allPoints[i];
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

        SpaceEvents[] newAllPoints = new SpaceEvents[counter];

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
            print("Name " + allPoints[i].name);
            print("String" + theString);
            if (allPoints[i].name.Equals(theString)) {
                return i;
            }
        }
        throw new System.Exception("GetIndexOfToStringInAllPoints does not contain theString");
    }

}
