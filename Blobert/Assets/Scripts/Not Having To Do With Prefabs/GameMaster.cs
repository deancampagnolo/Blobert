using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;// not entirely sure why this is here

    public static Transform playerPrefab;
    public static GameObject evilMoopPrefab;
    public static Transform beginningSpawnPoint;
    public Transform playerPrefabForInspector;
    public GameObject evilMoopForInspector;
    public Transform beginningSpawnPointForInspector;

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

    private void forInspectorVars() {//FIXME I am pretty sure that this isn't right
        playerPrefab = playerPrefabForInspector;
        beginningSpawnPoint = beginningSpawnPointForInspector;
        evilMoopPrefab = evilMoopForInspector;
    }

    public static GameObject GetPlayer() {
        return player;
    }
    public static GameObject GetEvilMoop() {
        return evilMoopPrefab;
    }


    public static void KillPlayer() {
        print(player.name);
        Destroy(player);
        RespawnPlayer();
        print(player.name);
    }

    public static void DamagePlayer(int amount) {
        if(player == null) {
            print("OHNO2");
        }
        player.GetComponent<MainC>().Damage(amount);
    }

    public static void DamageEnemy(GameObject NPCObject, int amount) {
        NPCObject.GetComponent<ZombieAiScript>().Damage(amount);
    }

    public static void HealEnemy(GameObject NPCObject, int amount) {
        NPCObject.GetComponent<ZombieAiScript>().Heal(amount);
    }

    public static void RespawnPlayer() {
        print(levels.GetComponent<TransformEvents>().getCurrentScript().transform.name);
        player = Instantiate(playerPrefab, levels.GetComponent<TransformEvents>().getCurrentScript().transform.parent.position, beginningSpawnPoint.rotation).gameObject;
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
