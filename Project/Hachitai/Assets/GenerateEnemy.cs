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
    int enemytype;
    Vector3 enemyplace;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //スコア加算
        score += (int)(Time.deltaTime * (60+level*10));
        //スコアがターゲットを超えるとレベルアップ
        if (score > scoretarget)
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
                enemyplace = new Vector3(Random.Range(-6f, 6f), Random.Range(-2f, 2f), 20);
                break;
            case 1:
                enemyplace = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 20);
                break;
            case 2:
                enemyplace = new Vector3(Random.Range(-7f, 7f), Random.Range(-1f, 1f), 20);
                break;
        }

        generator += Time.deltaTime;
        if (generator > (3f - 0.3f * level))
        {
            Instantiate(enemy[enemytype], enemyplace, Quaternion.identity);
            generator = 0;
        }

	}
}
