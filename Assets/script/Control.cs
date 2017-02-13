using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
    MobSpawn spawns;
    int _money;
    /// <summary>
    /// 所持金
    /// </summary>
    public int Money
    {
        get { return _money; }
    }
    void Start()
    {
        _money = 20;
        spawns = GetComponent<MobSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
    }
    void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(PlayControl("soldier", 1));
        }
    }
    private IEnumerator PlayControl(string s, int i)
    {
        switch (s)
        {
            case "soldier":
                spawns.Spawn();
                break;
        }
        yield return new WaitForSeconds(0.1f);
    }
}
