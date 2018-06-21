using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (MainCController))]
public class MainCController : MonoBehaviour {

    private MainC mainCharacter;
    private bool jump;
    // Use this for initialization
    private void Awake() {
        mainCharacter = GetComponent<MainC>();

    }

    // Update is called once per frame
    private void Update () {

        if (!jump) {
            jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
	}


    private void FixedUpdate() {
        bool bite = false;
        bool legBlast = false;
        bool slide = false;
        
        bite = Input.GetKey(KeyCode.J);
        legBlast = Input.GetKey(KeyCode.K);
        slide = Input.GetKey(KeyCode.LeftAlt);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");

        mainCharacter.Move(h, jump);

        
        mainCharacter.Attack("Bite",bite);

        mainCharacter.Attack("LegBlast", legBlast);


        jump = false;
    }

}
