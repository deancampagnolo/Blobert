﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;// not entirely sure why this is here

    public static int whichLevel;
    public static Transform playerPrefab;
    public static GameObject evilMoopPrefab;
    public static GameObject troblobShipPrefab;
    public static Transform beginningSpawnPoint;
    public int whichLevelForInspector;
    public Transform playerPrefabForInspector;
    public GameObject evilMoopForInspector;
    public Transform beginningSpawnPointForInspector;
    public GameObject troblobshipPrefabForInspector;
    

    private static GameObject player;
    private static float mainCWalkingVelocityX;
    private static float mainCRocketBlastVelocityX;
    private static float mainCOtherVelocity;
    private static Vector2 mainCCurrentVelocity;

    public static Vector2 rocketBlastOnPlayer;
    public static float minimumMomentumSpeed = 1f;//minimum speed needed to calculate momentum
    public static int momentumFactor = 100; // the speed divided by this is then subtracted to the speed (e.g. if speed is 30 with momentumFactor 4 then it would return 30 - (30/4);
    public static GameObject screenFlashRed;
    public static GameObject canvas;
    private static GameObject levels;

    private void Awake() {
        forInspectorVars();
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
        levels = GameObject.Find("Levels");
    }

    private void Start() {
        
        screenFlashRed = canvas.transform.Find("ScreenFlashRed").gameObject;
        mainCWalkingVelocityX = 0;
        mainCRocketBlastVelocityX = 0;
        mainCOtherVelocity = 0;
        mainCCurrentVelocity = Vector2.zero;
    }

    private void FixedUpdate() {

        if (player == null) {//FIXME I DONT KNOW WHY THIS BELONGS HERE
            player = GameObject.FindGameObjectWithTag("Player");
            print("reedoo");
        }
        if (player == null) {
            print("player is null");
        }
    }

    public static GameObject getCanvas() {
        return canvas;
    }

    public static GameObject GetLevels() {
        return levels;
    }

    public static GameObject GetFabby() {
        return GameObject.FindGameObjectWithTag("FabbyTheFairy");
    }

    private void forInspectorVars() {//FIXME I am pretty sure that this isn't right
        playerPrefab = playerPrefabForInspector;
        beginningSpawnPoint = beginningSpawnPointForInspector;
        evilMoopPrefab = evilMoopForInspector;
        whichLevel = whichLevelForInspector;
        troblobShipPrefab = troblobshipPrefabForInspector;
    }

    public static GameObject GetPlayer() {
        return player;
    }
    public static GameObject GetEvilMoop() {
        return evilMoopPrefab;
    }

    public static GameObject GetCamera() {
        return GameObject.Find("Main Camera");
    }

    public static void KillPlayer() {

        if (whichLevel != 3) {
            print(player.name);
            Destroy(player);
            RespawnPlayer();
            print(player.name);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public static void DamagePlayer(int amount) {
        if(player == null) {
            print("OHNO2");
        }
        player.GetComponent<MainC>().Damage(amount);
    }

    public static void UseBloodlust(int amount) {
        
        player.GetComponent<MainC>().SubtractBloodLust(amount);
    }

    public static void AddBloodlust(int amount) {
       
        player.GetComponent<MainC>().AddBloodLust(amount);
    }

    public static int GetBloodlust() {
        return player.GetComponent<MainC>().GetBloodLust();
    }

    public static void DamageEnemy(GameObject NPCObject, int amount) {
        NPCObject.GetComponent<ZombieAiScript>().Damage(amount);
    }

    public static void DamageShip(GameObject NPCObject) {
        NPCObject.GetComponent<TroblobShipScript>().Damage();
    }

    public static void HealEnemy(GameObject NPCObject, int amount) {
        NPCObject.GetComponent<ZombieAiScript>().Heal(amount);
    }

    public static void RespawnPlayer() {

        switch (whichLevel) {
            case 1:
                //print(levels.GetComponent<TransformEvents>().getCurrentScript().transform.name);
                player = Instantiate(playerPrefab, levels.GetComponent<TransformEvents>().getCurrentScript().transform.parent.position, beginningSpawnPoint.rotation).gameObject;
                break;
            case 2:
                print(levels.GetComponent<TroblobFortressTransformEvents>().getCurrentScript().transform.position);
                //print(levels.GetComponent<TroblobFortressTransformEvents>().getCurrentScript().transform.name);
                player = Instantiate(playerPrefab, levels.GetComponent<TroblobFortressTransformEvents>().getCurrentScript().transform.position, beginningSpawnPoint.rotation).gameObject;
                break;
            default:
                throw new System.Exception("Respawn in Not A Valid Level");
                break;
        }
        
        //player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) {
            print("OHNO");
        }
    }


    private static float CalculateMomentum(float velocity) {
        if (Mathf.Abs(velocity) > minimumMomentumSpeed) {
            return velocity - (velocity / momentumFactor);
        } else {
            return 0;
        }
    }

    public static IEnumerator flashScreenRed() {
        screenFlashRed.SetActive(true);
        yield return new WaitForSeconds(.2f);
        screenFlashRed.SetActive(false);

    }

    public static void SetMainCWalkingVelocity(Vector2 amount) {
        if (Mathf.Abs(amount.x) >= Mathf.Abs(mainCWalkingVelocityX)) {
            mainCWalkingVelocityX = amount.x;
        } else {
           mainCWalkingVelocityX = CalculateMomentum(mainCWalkingVelocityX);
        }
    }


    public static void SetMainCRocketBlastVelocity(Vector2 amount) {
        mainCRocketBlastVelocityX = CalculateMomentum(mainCRocketBlastVelocityX);
        mainCRocketBlastVelocityX += amount.x;

        /*if (Mathf.Abs(amount.x) > mainCRocketBlastVelocityX) {// this code snippit is if i wanted the rocket blast to go a fixed speed
            mainCRocketBlastVelocityX = amount.x;
        } else {
            mainCRocketBlastVelocityX = CalculateMomentum(mainCRocketBlastVelocityX);
        }*/
        
    }

    /*public static void SetMainCOtherVelocity(Vector2 amount) {
        mainCOtherVelocity = CalculateMomentum(mainCOtherVelocity);
        mainCOtherVelocity += amount;
    }*/

    public static Vector2 GetMainCVelocity() {
        CalculateMainCVelocity();
        return mainCCurrentVelocity;
    }

    public static void SetMainCVelocityToZero() {//not sure if this is the most optimal way to do this.
        mainCWalkingVelocityX = 0;
        mainCRocketBlastVelocityX = 0;
    }

    private static void CalculateMainCVelocity() {
        //if(mainCWalkingVelocity < player.GetComponent<MainC>().GetMaxSpeed())
        mainCCurrentVelocity = new Vector2(mainCWalkingVelocityX, 0) + player.GetComponent<MainC>().GetMainCVelocityY() + new Vector2(mainCRocketBlastVelocityX, 0);// + mainCOtherVelocity;//other velocity not used yet 
    }
}
