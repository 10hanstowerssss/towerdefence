using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Control : MonoBehaviour
{
    MobSpawn spawns;
    private bool pause;
    private float times;
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
        pause = false;
        //StartCoroutine(Loop());
        //GetComponent<Text>().text = (Money).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        times += Time.deltaTime;
        if (times >= 1.0f)
        {
            times = 0.0f;
            TimetoMoney();
            //Debug.Log(Money);
        }
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
                if (_money >= 5)
                {
                    spawns.Spawn();
                    _money -= 5;
                }
                break;
        }
        yield return new WaitForSeconds(0.1f);
    }
    private IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            TimetoMoney();
            //GetComponent<Text>().text = (Money).ToString();
        }
    }
    void TimetoMoney()
    {
        if (pause == false)
        {
            _money++;
        }
    }
    public void OnUnit1()
    {

    }
    public void OnUnit2()
    {

    }
    public void OnUnit3()
    {

    }
    public void OnUnit4()
    {

    }
    public void OnUnit5()
    {

    }
}
