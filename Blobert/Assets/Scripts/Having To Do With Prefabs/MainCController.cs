using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (MainCController))]
public class MainCController : MonoBehaviour {

    private MainC mainCharacter;

    private bool bite;
    private bool legBlast;
    private bool slide;
    private bool jump;
    private bool leftWalk;
    private bool rightWalk;

    private KeyCode biteKey;
    private KeyCode legBlastKey;
    private KeyCode slideKey;
    private KeyCode jumpKey;
    private KeyCode leftWalkKey;
    private KeyCode rightWalkKey;
    private int directionWalking;

    // Use this for initialization
    private void Awake() {
        mainCharacter = GetComponent<MainC>();
        
    }

    private void Start() {
        switch (SystemInfo.deviceType) {
            case DeviceType.Desktop:
                DesktopKeySetup();
                break;
            case DeviceType.Handheld:
                throw new System.Exception("HandheldKeys not implemented yet");//TODO HANDHELD KEY IMPLEMENTATION
                break;
            case DeviceType.Console:
                throw new System.Exception("ConsoleKeys not implemented yet"); //TODO CONSOLE KEY IMPLEMENTATION
                break;                   
        }
    }

    

    private void DesktopKeySetup() {
        biteKey = KeyCode.J;
        legBlastKey = KeyCode.K;
        slideKey = KeyCode.LeftAlt;
        jumpKey = KeyCode.Space;
        leftWalkKey = KeyCode.A;
        rightWalkKey = KeyCode.D;

    }



    private void FixedUpdate() {
      
        bite = false;
        legBlast = false;
        slide = false;
        jump = false;
        leftWalk = false;
        rightWalk = false;


        
        bite = Input.GetKey(biteKey);
        legBlast = Input.GetKey(legBlastKey);
        slide = Input.GetKey(slideKey);
        jump = Input.GetKeyDown(jumpKey);
        leftWalk = Input.GetKey(leftWalkKey);
        rightWalk = Input.GetKey(rightWalkKey);

        if (leftWalk && !rightWalk) {
            directionWalking = -1;
        } else if (rightWalk && !leftWalk) {
            directionWalking = 1;
        } else if (leftWalk && rightWalk) {
            directionWalking = 2;
        }
        else if(!leftWalk && !rightWalk) {
            directionWalking = 0;
        }
       

        mainCharacter.Move(directionWalking);

        mainCharacter.Jump(jump);

        
        mainCharacter.Attack("Bite",bite);

        mainCharacter.Attack("LegBlast", legBlast);
        
    }

    public bool isBitePressed() {
        return bite;//I'm not sure if when this is called it is ran before or after fixedUpdate
    }

    public bool isLegBlastPressed() {
        return legBlast;//I'm not sure if when this is called it is ran before or after fixedUpdate
    }

    public bool isJumpPressed() {
        return jump;//I'm not sure if when this is called it is ran before or after fixedUpdate
    }

    public bool isWalkingLeft() {
        return leftWalk;
    }

    public bool isWalkingRight() {
        return rightWalk;
    }

    public string getBiteKey() {
        return biteKey.ToString();
    }

    public string getLegBlastKey() {
        return legBlastKey.ToString();
    }

    public string getJumpKey() {
        return jumpKey.ToString();
    }

}
