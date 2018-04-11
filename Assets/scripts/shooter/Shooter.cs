using UnityEngine;

public class Shooter : MonoBehaviour {

    private Bullet bullet;

    //子弹发射速度，没帧移动距离
    public float Speed = 20f;

    private float lastClick = 0;

	// Use this for initialization
	void Start () {
        CreateBullet();
    }

    void CreateBullet()
    {
        GameObject obj = new GameObject();
        bullet = obj.AddComponent<Bullet>();
        //给子弹随机一个种类
        bullet.Type = Random.Range(1, 5);
    }

    /// <summary>
    /// 发射子弹
    /// </summary>
    /// <param name="x"> 点击的屏幕位置 x </param>
    /// <param name="y"> 点击的屏幕位置 y </param>
    void Shoot(float x, float y)
    {
        bullet.Shoot(x, y, Speed);
        bullet = null;
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetAxis("Fire1") > 0 && lastClick == 0)
        {
            //射击
            Vector3 pos = Input.mousePosition;
            pos.x = (pos.x / GameVO.Instance.PixelWidth - 0.5f) * GameVO.Instance.Width;
            pos.y = (pos.y / GameVO.Instance.PixelHeight - 0.5f) * GameVO.Instance.Height;
            Shoot(pos.x, pos.y);
            CreateBullet();
        }
        lastClick = Input.GetAxis("Fire1");
	}
}
