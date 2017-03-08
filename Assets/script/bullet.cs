using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
    public Transform target;
    private const float speed = 5.0f;
    int _damage;
    public int Damagee
    {
        get { return _damage; }
    }
    // Use this for initialization
    void Start () {
        _damage = 7;
	
	}
	
	// Update is called once per frame
	void Update () {
        //float ss = Time.deltaTime * speed;
        //float angleDir = transform.eulerAngles.z * (Mathf.PI / 180.0f);
        //Vector3 dir = new Vector3(Mathf.Cos(angleDir), Mathf.Sin(angleDir), 0.0f);
        if (target)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), 3f);
            transform.position += transform.forward * speed;
            if (Vector3.Distance(transform.position, target.transform.position) <= 0.1f)
            {
                if (target.GetComponent<enemy>())
                {
                    //target.GetComponent<enemy>().takeDamage(atk);
                }
                GameObject.Destroy(this.gameObject);
            }
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
