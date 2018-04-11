using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    public float width;
    public float height;
    private List<Side> sides = new List<Side>();

    //旋转速度
    public float Speed = 1;

	// Use this for initialization
	void Start () {
        //创建4条边，没条边占比 0.25
        for(int i = 0; i < 4; i++)
        {
            GameObject sideObject = new GameObject();
            Side side = sideObject.AddComponent<Side>();
            side.width = width;
            side.height = height;
            side.position = 0.25f * i;
            side.length = 0.25f;
            side.type = i + 1;
            sides.Add(side);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        for(int i = 0; i < sides.Count; i++)
        {
            sides[i].Change(sides[i].position + 0.001f * Speed, sides[i].length);
        }
    }
}
