using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using lib;
using UnityEngine.UI;

public class UIMain : MonoBehaviour {

    public Text ScoreText;

	// Use this for initialization
	void Start () {
        GameVO.Instance.score.AddListener(lib.Event.CHANGE, OnScoreChange);
        GameVO.Instance.combo.AddListener(lib.Event.CHANGE, OnScoreChange);
        OnScoreChange();
    }

    void OnScoreChange(lib.Event e = null)
    {
        ScoreText.text = "分数: " + GameVO.Instance.score.Value + "  连击: " + GameVO.Instance.combo.Value;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
