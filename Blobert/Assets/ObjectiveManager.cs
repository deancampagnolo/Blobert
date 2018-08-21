

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour {
    [SerializeField] private int timesToFlash = 5;

    private Text theText;//the Text class can only be obtained here by importing UnityEngine.UI
 
    // Use this for initialization
    void Start() {
        theText = this.transform.Find("Text").GetComponent<Text>();
    }

    public void SendObjective(string lines) {//this is what other methods would be typing.
        ChangeText(lines);

    }

    private void ChangeText(string text) {
        theText.text = text;
        StartCoroutine(FlashTextRed());
    }

    private IEnumerator FlashTextRed() {
        for (int i = 0; i < timesToFlash*2; i++) {//times to flash is *2 because that would be a whole cycle of a flash

            if (theText.color.Equals(Color.green)) {//if objective complete
                break;
            }

            if (i % 2 == 0) {
               theText.color = Color.red;
            } else {
                theText.color = Color.white;
            }
          
            yield return new WaitForSeconds(.5f);
        }
    }

    public void ObjectiveCompleted() {
        print("ObjectiveCompleted");
        theText.color = Color.green;
    }
}
