using UnityEngine;
using System.Collections;
/// <summary>
/// 成長レート
/// </summary>
public class Parameter {
    public static int HitPoint(int lv)
    {
        return 20 + (4 * lv);
    }
	public static int Attack(int lv)
    {
        return 5 + (2 * lv);
    }
    public static int Speed(int lv)
    {
        return 1 * lv;
    }
}
