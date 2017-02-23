using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Control : MonoBehaviour
{
    MobSpawn spawns;
    Slider _slider;
    int _TacticsGauge;
    public int TacticsGauge
    {
        get { return _TacticsGauge; }
    }
    private bool pause;
    private float times;
    style Style;
    /// <summary>
    /// 戦闘態勢
    /// </summary>
    public enum style
    {
        Defensive,
        Offensive,
        Normal,
    }
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
        _TacticsGauge = 30;
        _slider = GameObject.Find("TacticalGauge").GetComponent<Slider>();
        spawns = GetComponent<MobSpawn>();
        Style = style.Normal;
        _slider.value = TacticsGauge;
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
        if (Style == style.Offensive || Style == style.Defensive)
        {
            Style = style.Normal;
        }
    }
    void KeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(PlayControl("soldier", 1));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Style = style.Defensive;
            BattleStyle(Style);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Style = style.Offensive;
            BattleStyle(Style);
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
            case "Archer":
                break;
            case "Lancer":
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
        StartCoroutine(PlayControl("soldier", 1));
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
    public void OnSpecialSkill()
    {
        if (TacticsGauge == 100)
        {

        }
    }
    public void BattleStyle(style _styletype)
    {
        switch (_styletype)
        {
            case style.Normal:
                break;
            case style.Offensive:
                _TacticsGauge--;
                if (_TacticsGauge <= 0)
                {
                    _TacticsGauge = 0;
                }
                _slider.value = TacticsGauge;
                break;
            case style.Defensive:
                _TacticsGauge++;
                if (_TacticsGauge >= 100)
                {
                    _TacticsGauge = 100;
                }
                _slider.value = TacticsGauge;
                break;
        }
    }
    private bool gamespeed;
    public void GameSpeed()
    {
        if (gamespeed == false)
        {
            Time.timeScale = 2;
            gamespeed = true;
        }
        else
        {
            Time.timeScale = 1;
            gamespeed = false;
        }
    }
}
