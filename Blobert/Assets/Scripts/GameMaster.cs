using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;// not entirely sure why this is here

    public Transform playerPrefab;
    public Transform spawnPoint;
    public float fallOffMap;

    public static void KillPlayer(BlobertScript player) {
        Destroy(player.gameObject);
        gm.RespawnPlayer();
    }

    public static void DamageEnemy(GameObject NPCObject, int amount) {
        NPCObject.GetComponent<NPCStats>().Damage(amount);
    }

    public static void HealEnemy(GameObject NPCObject, int amount) {
        NPCObject.GetComponent<NPCStats>().Heal(amount);
    }

    public void RespawnPlayer() {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public IEnumerator IsFallOff() {
        while (true) {

        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
