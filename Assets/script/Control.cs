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
    public Text texted;
    style Style;
    /// <summary>
    /// 戦闘態勢
    /// </summary>
    public enum style
    {
        Defensive,
        Offensive,
        Normal,
        MAX,
    }
    static int _money;
    /// <summary>
    /// 所持金
    /// </summary>
    public static int Money
    {
        get { return _money; }
        set { _money += value; }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _money = 20;
        _plusmoney = 1;
        _TacticsGauge = 30;
        texted.text = "資金: 0";
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TacticsGauge == 100)
            {
                OnSpecialSkill();
            }
        }
        Style = style.Normal;
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
                    texted.text = "資金: " + Money.ToString();
                }
                break;
            case "Archer":
                break;
            case "Magic":
                if(_money>=7)
                {
                    spawns.SpawnMagicUser();
                    _money -= 7;
                    texted.text = "資金: " + Money.ToString();
                }
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
    int _plusmoney;
    public int Plusmoney
    {
        get { return _plusmoney; }
        set { _plusmoney += value; }
    }
    void TimetoMoney()
    {
        if (pause == false)
        {
            _money+=Plusmoney;
        }
        texted.text = "資金: " + Money.ToString();
    }
    public static void Enemykill()
    {
        _money += 3;
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
        StartCoroutine(PlayControl("Magic", 1));
    }
    public void OnUnit4()
    {

    }
    public void OnUnit5()
    {
        Time.timeScale = 0;
    }
    public void OnSpecialSkill()
    {
        while (TacticsGauge >= 0)
        {
            _TacticsGauge--;
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
            case style.MAX:
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
