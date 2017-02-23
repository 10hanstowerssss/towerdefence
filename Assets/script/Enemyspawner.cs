using UnityEngine;
using System.Collections;

public class Enemyspawner : MonoBehaviour {

    public GameObject Spawnpoint;
    private GameObject Soldier;
    enemy es;
    //private GameObject Archer;
    //private GameObject Gunner;
	void Start () {
        Soldier = (GameObject)Resources.Load("Prefab/Enemy");
        InvokeRepeating("Spawn", 3.0f,3.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Spawn()
    {
        Instantiate(Soldier, Spawnpoint.transform.position, Quaternion.identity);
    }
}
