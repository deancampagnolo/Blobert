using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEvents : MonoBehaviour {
    [HideInInspector]
    private Transform pointOfNoReturn;
    private TransformEventLevelScript[] allPoints;
    private int currentEvent;
    private Object[] a;
    // Use this for initialization
    void Start() {
        currentEvent = 0;
        allPoints = GameObject.FindObjectsOfType<TransformEventLevelScript>();
        allPoints = (TransformEventLevelScript[])ReverseOrderOfArray(allPoints);
        print(allPoints.Length);

    }

    // Update is called once per frame
    void FixedUpdate() {
        if ((GameMaster.GetPlayer().transform.position.x > allPoints[currentEvent].GetXPosition())) {
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


        }
