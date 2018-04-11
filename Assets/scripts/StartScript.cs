using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lib;

public class StartScript : MonoBehaviour {

    public Camera mainCamera;

    // Use this for initialization
    void Awake()
    {
        //创建背景
        CreateBackGround();

        //创建格子外边
        GameObject boxObject = new GameObject();
        Box box = boxObject.AddComponent<Box>();
        Vector3 size = new Vector3();
        size = mainCamera.ViewportToWorldPoint(size);
        box.width = Mathf.Abs(size.x / 0.01f) * 2 * 0.8f;
        box.height = Mathf.Abs(size.y / 0.01f) * 2 * 0.8f;

        //存储屏幕信息
        GameVO.Instance.Width = Mathf.Abs(size.x * 2);
        GameVO.Instance.Height = Mathf.Abs(size.x * 2);
        GameVO.Instance.PixelWidth = mainCamera.pixelWidth;
        GameVO.Instance.PixelHeight = mainCamera.pixelHeight;

        //创建发射器
        GameObject shooter = new GameObject();
        shooter.AddComponent<Shooter>();

        /*Texture2D txt2d = Resources.Load<Texture2D>("side/red");
        GameObject obj = new GameObject();
        BoxCollider2D c2d = obj.AddComponent<BoxCollider2D>();
        c2d.offset = new Vector2(-0.005f, 0.005f * txt2d.height);
        c2d.size = new Vector2(0.01f, 0.01f * txt2d.height);
        SpriteRenderer spr = obj.AddComponent<SpriteRenderer>();
        Rect rec = new Rect(0, 0, txt2d.width, txt2d.height);
        Sprite sp = Sprite.Create(txt2d, rec, new Vector2(1, 0));
        spr.sprite = sp;
        obj.transform.position = new Vector3(0,0);
        obj.transform.localScale = new Vector3(100, 1);
        obj.transform.Rotate(0, 0, 90f);
        obj.AddComponent<Rigidbody2D>();*/
    }

    void CreateBackGround()
    {
        Vector3 size = new Vector3();
        size = mainCamera.ViewportToWorldPoint(size);
        size.x = Mathf.Abs(size.x / 0.01f) * 2;
        size.y = Mathf.Abs(size.y / 0.01f) * 2;
        Texture2D txt2d = ResourceManager.GetResource<Texture2D>("image/bg/bg");
        GameObject obj = new GameObject();
        SpriteRenderer spr = obj.AddComponent<SpriteRenderer>();
        UnityEngine.Rect rec = new UnityEngine.Rect(0, 0, txt2d.width, txt2d.height);
        Sprite sp = Sprite.Create(txt2d, rec, new Vector2(0.5f, 0.5f));
        spr.sprite = sp;
        obj.transform.position = new Vector3(0, 0,100);
        obj.transform.localScale = new Vector3(size.x, size.y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
