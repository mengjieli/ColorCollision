using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lib;

public class SideLine : MonoBehaviour {

    public EventDispatcher dispatcher = new EventDispatcher();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        Debug.Log("碰撞!");
        dispatcher.DispatchWith("Collision",bullet);
    }

}
