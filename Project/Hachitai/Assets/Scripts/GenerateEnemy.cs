using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour {

    [SerializeField]
    GameObject[] enemy;
    public int score;
    public int scoretarget =600;
    public int level=1;
    float generator;
    float generatetarget;
    int enemytype;
    Vector3 enemyplace;
    private Player _player;

	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Car").GetComponent<Player>();
        level = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if(_player.Metor > 10000)
        {
            level = 2;
        } else if(_player.Metor > 30000)
        {
            level = 3;
        } else if(_player.Metor > 50000)
        {
            level = 4;
        }
        //スコア加算
        score += (int)(Time.deltaTime * (60+level*10));
        //スコアがターゲットを超えるとレベルアップ
        if (score > scoretarget&&level<9)
        {
            //ターゲットの更新
            scoretarget += (600 + level * 300);
            level++;
        }

        //敵の生成
        enemytype = Random.Range(0, 3);
        switch (enemytype)
        {
            case 0:
                enemyplace = new Vector3(Random.Range(-6f, 6f), Random.Range(-2f, 2f), 40);
                break;
            case 1:
                enemyplace = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 40);
                break;
            case 2:
                enemyplace = new Vector3(Random.Range(-7f, 7f), Random.Range(-1f, 1f), 40);
                break;
        }

        generator += Time.deltaTime;
        generatetarget = 2f - 0.3f * level;
        if (generatetarget < 0.25f)
            generatetarget = 0.25f;
        if (generator > generatetarget)
        {
            Instantiate(enemy[enemytype], enemyplace, Quaternion.identity);
            generator = 0;
        }

	}
}
