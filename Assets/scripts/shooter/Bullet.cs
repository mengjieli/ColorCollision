using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lib;

public class Bullet : MonoBehaviour {

    public int Type;
    Rigidbody2D r2d;

    // Use this for initialization
    void Start () {
        Texture2D txt2d = ResourceManager.GetResource<Texture2D>("image/bullet/" + Type);
        GameObject obj = gameObject;
        obj.layer = 8;
        SpriteRenderer spr = obj.AddComponent<SpriteRenderer>();
        UnityEngine.Rect rec = new UnityEngine.Rect(0, 0, txt2d.width, txt2d.height);
        Sprite sp = Sprite.Create(txt2d, rec, new Vector2(0.5f, 0.5f));
        spr.sprite = sp;
        obj.transform.position = new Vector3(0, 0, 50);
        r2d = obj.AddComponent<Rigidbody2D>();
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = 0;
        CircleCollider2D c2d = obj.AddComponent<CircleCollider2D>();
        c2d.radius = txt2d.width * 0.5f / 100;
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    /// <param name="x"> 点击的屏幕位置 x </param>
    /// <param name="y"> 点击的屏幕位置 y </param>
    public void Shoot(float x, float y,float speed)
    {
        float rot = Mathf.Atan2(y, x);
        float speedX = speed * Mathf.Cos(rot);
        float speedY = speed * Mathf.Sin(rot);
        r2d.velocity = new Vector2(speedX, speedY);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
