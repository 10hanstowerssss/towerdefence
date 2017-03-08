using UnityEngine;
using System.Collections;

public class RANGe : MonoBehaviour {

    MinionStatus status;
    // Use this for initialization
    void Start()
    {
        GameObject objstatus = gameObject.transform.parent.gameObject;
        status = objstatus.GetComponent<MinionStatus>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            status.rangeTriggerEnter(collider);
        }
    }
}
