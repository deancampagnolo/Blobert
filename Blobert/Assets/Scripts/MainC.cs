﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MainC : MonoBehaviour {

    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private LayerMask whatIsGround;
    public int health = 100;

    private Transform groundCheck;//position marking where to check if the player is grounded
    
    const float groundedRadius = .2f;
    private bool grounded; //true if player is grounded
    //may need ceiling check if sliding
    private Animator anim;//reference to mainCharacter component
    private Rigidbody2D rigidbody2D;
    private bool facingRight = true;
    private Vector2 currentWalkingSpeed;
    private Vector2 walkingVelocity;

    // Use this for initialization
    private void Awake () {
       
        anim = transform.Find("Animatorz").GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        //anim = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
    private void FixedUpdate() {
        grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for(int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject.CompareTag("Ground")) {
                grounded = true;
            }
        }
        anim.SetBool("Grounded", grounded);

        if (IsPlayerDead()) {
            GameMaster.KillPlayer();
            print("kill");//FIXME KILL PLAYER DOESN"T WORK
        }
        //print(rigidbody2D.velocity.x);
        //DecrimentWalkingSpeed();
        //rigidbody2D.
        //rigidbody2D.velocity = currentWalkingSpeed;
    }

    public void Move(float move, bool jump) {

        if(move > .1) {
            anim.SetBool("FacingRight", true);
        } else if(move < -.1) {
            anim.SetBool("FacingRight", false);
        }

        anim.SetFloat("Speed", move);

        //currentWalkingSpeed = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
        walkingVelocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
        SetVelocity();

        if(grounded && jump) {//why is the anim bool suggested here?

            grounded = false;
            anim.SetBool("Grounded", false);
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));

        }
    }

    public void SetVelocity() {
        rigidbody2D.velocity = walkingVelocity + GameMaster.GetRocketBlastOnPlayer();
    }

    public void Attack(String attack, bool value) {
        anim.SetBool(attack, value);//FIXME FIGURE OUT HOW TO DO ANIM UNTIL IT FINISHES.
    }

    public void AddToCurrentSpeed(Vector2 vector2) {
        rigidbody2D.velocity = currentWalkingSpeed;
    }

    public void Damage(int amount) {
        health -= amount;
        print(health);
    }
    public bool IsPlayerDead() {
        if (health <= 0) {
            return true;
        }
        return false;
    }

}
