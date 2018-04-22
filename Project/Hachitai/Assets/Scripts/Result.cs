using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    public Text _scoreText;

	// Use this for initialization
	void Start () {
        string result = "Awesome!\n You advanced ";
        if (ScoreData.Instance.Score > 1000)
        {
            result += (Mathf.Round(ScoreData.Instance.Score / 100) / 10) + "km !!";
        }
        else
        {
            result += (int)ScoreData.Instance.Score + "m !!";
        }
        _scoreText.text = result;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
