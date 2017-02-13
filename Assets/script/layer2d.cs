using UnityEngine;
using System.Collections;

public class layer2d {

    int _width; // 幅
    int _height; // 高さ
    int _outOfRange = -1; 
    int[] _values = null; // マップデータ

    public int Width
    {
        get { return _width; }
    }
    /// 高さ
    public int Height
    {
        get { return _height; }
    }
    public void Create(int width, int height)
    {
        _width = width;
        _height = height;
        _values = new int[Width * Height];
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
