using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEvents : MonoBehaviour {
    [HideInInspector]
    private Transform pointOfNoReturn;
    private TransformEventLevelScript[] allPoints;
   
    private int currentEvent;

    private string[] orderOfEvents = new string[] { "TransformEventBeginning", "TransformEventLevel1", "TransformEventLevel4", "TransformEventPlaceHolder" };
    
    // Use this for initialization
    void Start() {
        currentEvent = 0;
        allPoints = GameObject.FindObjectsOfType<TransformEventLevelScript>();
        
        
        //allPoints = (TransformEventLevelScript[])ReverseOrderOfArray(allPoints);
        print(allPoints.Length);
        foreach (TransformEventLevelScript i in allPoints) {
            print(i);
        }
        OrganizeAllPoints();
        foreach (TransformEventLevelScript i in allPoints) {
            print(i);
        }

    }

    // Update is called once per frame
    void FixedUpdate() {
        //print(GameMaster.GetPlayer().transform.position.x);
        //print(allPoints[currentEvent].GetXPosition());
        if ((GameMaster.GetPlayer().transform.position.x > allPoints[currentEvent].GetXPosition()) && !allPoints[currentEvent].IsScriptCompleted()) {//and not completed
            allPoints[currentEvent].DoEvent();
            currentEvent++;
        }
    }

    private Object[] ReverseOrderOfArray(Object[] array) {
        Object temp;
        for(int i = 0; i<array.Length/2; i++) {
            temp = array[i];
            array[i] = array[array.Length-1-i];
            array[array.Length - 1 - i] = temp;
            i++;
        }

        return array;
    }

    private void OrganizeAllPoints() {
        for(int i = 0; i<allPoints.Length; i++) {
            if(!allPoints[i].name.Equals(orderOfEvents[i])) {//if it does not equal
                int index = GetIndexOfToStringInAllPoints(orderOfEvents[i], i);
                TransformEventLevelScript temp = allPoints[i];
                allPoints[i] = allPoints[index];
                allPoints[index] = temp;
            }
        }
        
    }

    private int GetIndexOfToStringInAllPoints(string theString, int minimumIndex) {
        for(int i = minimumIndex; i<allPoints.Length; i++) {
            print(allPoints[i].name);
            if (allPoints[i].name.Equals(theString)) {
                return i;
            }
        }
        throw new System.Exception("GetIndexOfToStringInAllPoints does not contain theString");
    }

 }

