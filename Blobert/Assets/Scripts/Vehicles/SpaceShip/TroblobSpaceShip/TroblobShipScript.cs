using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroblobShipScript : MonoBehaviour {

    [SerializeField] private int numberOfEngines;
    private int currentNumberOfEngines;
    private GameObject[] Engines;
    [SerializeField] GameObject explosion;
    [SerializeField] private int engineHealth;
    private int engineHealthCounter = 0;

    private void Start() {
        Engines = GameObject.FindGameObjectsWithTag("Engine");
        currentNumberOfEngines = numberOfEngines;
    }

    private GameObject GetEngine(int engineNumber) {
        foreach(GameObject engine in Engines) {
            if (engine != null && engine.name.Equals("Engine" + engineNumber)){
                return engine;
            }
        }
        throw new System.Exception("Engine" + engineNumber+" Does Not Exist");
    }

    public int GetEnginesRemaining() {
        return currentNumberOfEngines;
    }

    public void Damage() {
        engineHealthCounter++;
        if (engineHealthCounter >= engineHealth) {
            engineHealthCounter = 0;
            print(currentNumberOfEngines);
            GameObject theEngine = GetEngine(numberOfEngines - currentNumberOfEngines + 1);
            Instantiate(explosion, theEngine.transform.position, theEngine.transform.rotation, this.transform);
            Destroy(theEngine.transform.Find("PoisonWater (1)").gameObject);//+1 bc of naming issues
            currentNumberOfEngines--;
        }
    }
}
