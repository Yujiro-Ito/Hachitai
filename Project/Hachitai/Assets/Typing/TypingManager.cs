using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingManager : MonoBehaviour {
    //----const----
    public const int RM = 0;
    public const int JP = 1;
    public const string TEXT_COLOR_START = "<color=#999999>";
    public const string TEXT_COLOR_END = "</color>";

    [System.Serializable]
    public class TextData
    {
        [Header("日本語")]
        public string jp;
        [Header("ローマ字")]
        public string rm;
    }

    [SerializeField]
    private TextData[] _textResources;

    //----field----
    [SerializeField]
    private Text _questionStringJP_UI;
    [SerializeField]
    private Text _questionStringRM_UI;
    private string _questionStringRM;
    private int _currentIndex;
    private int _continueCorrect;

	// Use this for initialization
	void Start () {
        CreateNewQuestion();
	}
	
	// Update is called once per frame
	void Update () {
        //キーを打った時に正解判定
		if(Input.anyKeyDown && !Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
        {
            if (Input.GetKeyDown(_questionStringRM[_currentIndex].ToString()))
            {
                Correct();
            }
            else
            {
                Miss();
            }
        }
	}


    /// <summary>
    /// テキストリソースの配列
    /// </summary>
    /// <returns>[0]問題のローマ字、[1]問題の日本語</returns>
    public  TextData GetRandomString()
    {
        return _textResources[Random.Range(0, _textResources.Length)];
    }

    /// <summary>
    /// 新しい問題に変更するときに呼びだす
    /// </summary>
    public void CreateNewQuestion()
    {
        TextData newQuestion = GetRandomString();
        _questionStringRM = newQuestion.rm;
        _questionStringRM_UI.text = newQuestion.rm;
        _questionStringJP_UI.text = newQuestion.jp;
        _currentIndex = 0;
        SetStringColor();
    }

    /// <summary>
    /// UIテキスト上の色を変更する
    /// </summary>
    public void SetStringColor()
    {
        string result = _questionStringRM + TEXT_COLOR_END;
        result = result.Insert(_currentIndex, TEXT_COLOR_START);
        _questionStringRM_UI.text = result;
    }

    /// <summary>
    /// 正解時の処理
    /// </summary>
    public void Correct()
    {
        _currentIndex++;
        if(_questionStringRM.Length == _currentIndex)
        {
            AllCorrect();
            CreateNewQuestion();
        }
        SetStringColor();
    }

    /// <summary>
    /// 全問正解した後の処理
    /// </summary>
    public void AllCorrect()
    {
        _continueCorrect++;
        Debug.Log("「" + _questionStringJP_UI.text.ToString() + "」を打ち終えました");
    }

    /// <summary>
    /// 不正解時の処理
    /// </summary>
    public void Miss()
    {
        Debug.Log("間違えましたね");
        _continueCorrect = 0;
    }
}
