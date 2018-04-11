using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lib;

public class Side : MonoBehaviour {

    public float width;
    public float height;
    public float position;
    public float length;
    public int type;
    private float widthPercent;
    private float heightPercent;
    private List<GameObject> sides = new List<GameObject>();

    private void Start()
    {
        Draw();
    }

    public void Change(float position,float length)
    {
        if(position >= 1)
        {
            position -= 1;
        }
        if(length > 1)
        {
            length = 1;
        }
        this.position = position;
        this.length = length;
        while(sides.Count > 0)
        {
            GameObject obj = sides[sides.Count - 1];
            Destroy(obj);
            sides.RemoveAt(sides.Count - 1);
        }
        Draw();
    }

    void Draw()
    {
        float len = width * 2 + height * 2;
        widthPercent = width / len;
        heightPercent = height / len;
        float pos = position;
        float length = this.length;
        int index = GetPositionIndex(pos);
        while (length > 0)
        {
            if (length > GetSideLength(pos, index))
            {
                DrawSide(pos, index, GetSideLength(pos, index));
                length -= GetSideLength(pos, index);
                pos += GetSideLength(pos, index);
                index++;
                if (index == 5)
                {
                    index = 1;
                    pos = 0;
                }
            }
            else
            {
                DrawSide(pos, index, length);
                length = 0;
            }
        }
    }

    void OnCollision(lib.Event e)
    {
        Bullet bullet = e.Data as Bullet;
        Destroy(bullet.gameObject);
        GameVO.Instance.score.Value = (int)GameVO.Instance.score.Value + (bullet.Type == type ? 1 : 0);
        GameVO.Instance.combo.Value = bullet.Type == type ? (int)GameVO.Instance.combo.Value + 1 : 0;
    }
    
    void DrawSide(float pos,int index, float len)
    {
        if(index == 1)
        {
            Texture2D txt2d = ResourceManager.GetResource<Texture2D>("image/side/" + type);
            GameObject obj = new GameObject();
            (obj.AddComponent<SideLine>()).dispatcher.AddListener("Collision", OnCollision);
            BoxCollider2D c2d = obj.AddComponent<BoxCollider2D>();
            c2d.offset = new Vector2(0.005f,0.005f * txt2d.height);
            c2d.size = new Vector2(0.01f, 0.01f * txt2d.height);
            SpriteRenderer spr = obj.AddComponent<SpriteRenderer>();
            UnityEngine.Rect rec = new UnityEngine.Rect(0, 0, txt2d.width, txt2d.height);
            Sprite sp = Sprite.Create(txt2d, rec, new Vector2(0, 1));
            spr.sprite = sp;
            obj.transform.position = new Vector3(-width * 0.5f / 100, ((pos - GetSideStart(index)) / heightPercent) * height / 100 - height * 0.5f / 100);
            obj.transform.localScale = new Vector3(height*len/heightPercent, 1);
            obj.transform.Rotate(0, 0, 90f);
            sides.Add(obj);
        }
        else if(index == 2)
        {
            Texture2D txt2d = ResourceManager.GetResource<Texture2D>("image/side/" + type);
            GameObject obj = new GameObject();
            (obj.AddComponent<SideLine>()).dispatcher.AddListener("Collision", OnCollision);
            BoxCollider2D c2d = obj.AddComponent<BoxCollider2D>();
            c2d.offset = new Vector2(0.005f, 0.005f * txt2d.height);
            c2d.size = new Vector2(0.01f, 0.01f * txt2d.height);
            SpriteRenderer spr = obj.AddComponent<SpriteRenderer>();
            UnityEngine.Rect rec = new UnityEngine.Rect(0, 0, txt2d.width, txt2d.height);
            Sprite sp = Sprite.Create(txt2d, rec, new Vector2(0, 1));
            spr.sprite = sp;
            obj.transform.position = new Vector3(((pos - GetSideStart(index)) / widthPercent) * width / 100 - width * 0.5f / 100, + height * 0.5f / 100);
            obj.transform.localScale = new Vector3(height * len / heightPercent, 1);
            sides.Add(obj);
        }
        else if (index == 3)
        {
            Texture2D txt2d = ResourceManager.GetResource<Texture2D>("image/side/" + type);
            GameObject obj = new GameObject();
            (obj.AddComponent<SideLine>()).dispatcher.AddListener("Collision", OnCollision);
            BoxCollider2D c2d = obj.AddComponent<BoxCollider2D>();
            c2d.offset = new Vector2(-0.005f, 0.005f * txt2d.height);
            c2d.size = new Vector2(0.01f, 0.01f * txt2d.height);
            SpriteRenderer spr = obj.AddComponent<SpriteRenderer>();
            UnityEngine.Rect rec = new UnityEngine.Rect(0, 0, txt2d.width, txt2d.height);
            Sprite sp = Sprite.Create(txt2d, rec, new Vector2(1, 0));
            spr.sprite = sp;
            obj.transform.position = new Vector3(width * 0.5f / 100, -((pos - GetSideStart(index)) / heightPercent) * height / 100 + height * 0.5f / 100);
            obj.transform.localScale = new Vector3(height * len / heightPercent, 1);
            obj.transform.Rotate(0, 0, 90f);
            sides.Add(obj);
        }
        else if (index == 4)
        {
            Texture2D txt2d = ResourceManager.GetResource<Texture2D>("image/side/" + type);
            GameObject obj = new GameObject();
            (obj.AddComponent<SideLine>()).dispatcher.AddListener("Collision", OnCollision);
            BoxCollider2D c2d = obj.AddComponent<BoxCollider2D>();
            c2d.offset = new Vector2(-0.005f, 0.005f * txt2d.height);
            c2d.size = new Vector2(0.01f, 0.01f * txt2d.height);
            SpriteRenderer spr = obj.AddComponent<SpriteRenderer>();
            UnityEngine.Rect rec = new UnityEngine.Rect(0, 0, txt2d.width, txt2d.height);
            Sprite sp = Sprite.Create(txt2d, rec, new Vector2(1, 0));
            spr.sprite = sp;
            obj.transform.position = new Vector3(-((pos - GetSideStart(index)) / widthPercent) * width / 100 + width * 0.5f / 100, -height * 0.5f / 100);
            obj.transform.localScale = new Vector3(height * len / heightPercent, 1);
            sides.Add(obj);
        }
    }

    float GetSideStart(int index)
    {
        if (index == 1)
        {
            return 0;
        }
        if (index == 2)
        {
            return heightPercent;
        }
        if (index == 3)
        {
            return widthPercent + heightPercent;
        }
        if (index == 4)
        {
            return widthPercent + 2 * heightPercent;
        }
        return 0;
    }

    float GetSideLength(float pos,int index)
    {
        if(index == 1)
        {
            return heightPercent - pos;
        }
        if(index == 2)
        {
            return widthPercent - (pos - heightPercent);
        }
        if(index == 3)
        {
            return heightPercent - (pos - widthPercent - heightPercent);
        }
        if(index == 4)
        {
            return widthPercent - (pos - widthPercent - 2 * heightPercent);
        }
        return 0;
    }

    int GetPositionIndex(float pos)
    {
        //左边
        if (pos >= 0 && pos < heightPercent)
        {
            return 1;
        }
        //上边
        if (pos >= heightPercent && pos < heightPercent + widthPercent)
        {
            return 2;
        }
        //右边
        if (pos  >= heightPercent + widthPercent && pos < 2 * heightPercent + widthPercent)
        {
            return 3;
        }
        //下边
        if (pos >= 2 * heightPercent + widthPercent && pos < 1)
        {
            return 4;
        }
        return 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
