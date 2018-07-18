using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;// not entirely sure why this is here

    public static Transform playerPrefab;
    public static Transform beginningSpawnPoint;
    public Transform playerPrefabForInspector;
    public Transform beginningSpawnPointForInspector;
    public float fallOffMap;
    private static GameObject player;
    public static Vector2 rocketBlastOnPlayer;
    public static float minimumMomentumSpeed = 1f;//minimum speed needed to calculate momentum
    public static int momentumFactor = 20; // the speed divided by this is then subtracted to the speed (e.g. if speed is 30 with momentumFactor 4 then it would return 30 - (30/4);
    public static GameObject screenFlashRed;

    private void Awake() {
        forInspectorVars();
        player = GameObject.Find("Player");
    }

    private void Start() {
        screenFlashRed = GameObject.Find("Canvas").transform.Find("ScreenFlashRed").gameObject;
    }

    private void forInspectorVars() {//FIXME I am pretty sure that this isn't right
        playerPrefab = playerPrefabForInspector;
        beginningSpawnPoint = beginningSpawnPointForInspector;
    }

    public static GameObject GetPlayer() {
        return player;
    }


    public static void KillPlayer() {
        print(player.name);
        Destroy(player);
        RespawnPlayer(playerPrefab, beginningSpawnPoint);
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

    public static void RespawnPlayer(Transform playerPrefab, Transform beginningSpawnPoint) {
        player = Instantiate(playerPrefab, beginningSpawnPoint.position, beginningSpawnPoint.rotation).gameObject;
        //player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) {
            print("OHNO");
        }
    }

    public static void AddForceToNPC(GameObject theObject, Vector2 force) {
        theObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }

    public static void AddRocketBlastOnPlayer(Vector2 newVelocity) {
        rocketBlastOnPlayer += newVelocity;
    }

    public static Vector2 GetRocketBlastOnPlayer() {
        return rocketBlastOnPlayer;
    }

    public static Vector2 CalculateXMomentum(Vector2 Momentum) {
        if (Momentum.x > minimumMomentumSpeed) {
            return new Vector2(Momentum.x - (Momentum.x / momentumFactor), Momentum.y);
        }
        return new Vector2(0, Momentum.y);
    }

    public IEnumerator IsFallOff() {
        while (true) {
       
        }
    }
	


    private void FixedUpdate() {
        //print(player.name);
        rocketBlastOnPlayer = CalculateXMomentum(rocketBlastOnPlayer);
        if(player == null) {//FIXME I DONT KNOW WHY THIS BELONGS HERE
            player = GameObject.FindGameObjectWithTag("Player");
            print("reedoo");
        }
        if(player == null) {
            print("player is null");
        }
        /*if(player != null) {
            print("yay");
        }*/
    }

    public static IEnumerator flashScreenRed() {
        screenFlashRed.SetActive(true);
        yield return new WaitForSeconds(.2f);
        screenFlashRed.SetActive(false);

    }
    public void flashScreenRedStart() {
      // StartCoroutine
    }
}
