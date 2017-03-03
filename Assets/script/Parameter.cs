using UnityEngine;
using System.Collections;
/// <summary>
/// 成長レート
/// </summary>
public class Parameter {
    public static int HitPoint(int lv)
    {
        return 16 + (4 * lv);
    }
	public static int Attack(int lv)
    {
        return 3 + (2 * lv);
    }
    public static int Speed(int lv)
    {
        return 1 * lv;
    }
    public static int Cost(int lv)
    {
        return 3;
    }
    public static int LongRangeHP(int lv)
    {
        return 10 + (3 * lv);
    }
    public static int LongRangeATK(int lv)
    {
        return 2 + (2 * lv);
    }
    public static int Range(int lv)
    {
        return 1 * lv;
    }
}
