﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(MainCController))]
public class BlobertShipController : MonoBehaviour {


    [SerializeField] private float speed = 1;
    private MainC mainCharacter;

    
    private bool left;
    private bool right;



    private KeyCode leftWalkKey;
    private KeyCode rightWalkKey;


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

        leftWalkKey = KeyCode.A;
        rightWalkKey = KeyCode.D;

    }



    private void FixedUpdate() {

        left = false;
        right = false;


        left = Input.GetKey(leftWalkKey);
        right = Input.GetKey(rightWalkKey);

        if(!(left && right)) {
            if (left) {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -1, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }else if (right) {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            } else {
                this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
        }

    }

    public bool isWalkingLeft() {
        return left;
    }

    public bool isWalkingRight() {
        return right;
    }

}
