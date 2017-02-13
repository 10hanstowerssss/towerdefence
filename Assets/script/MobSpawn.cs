using UnityEngine;
using System.Collections;

public class MobSpawn : MonoBehaviour {

    int money;
    Control control;
    public GameObject Spawnpoint;
    private GameObject Soldier;
    //private GameObject Archer;
    //private GameObject Gunner;
	void Start () {
        Soldier = (GameObject)Resources.Load("Prefab/mob");
        if (control == null)
        {
            control = GetComponent<Control>();
        }
	}
	
	void Update () {
        
	}
    public void Spawn()
    {
        money = control.Money;
        if (money >= 5)
        {
            //Money -= 5;
            Instantiate(Soldier, Spawnpoint.transform.position, Quaternion.identity);
        }
    }
}
