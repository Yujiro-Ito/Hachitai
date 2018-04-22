using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    int level;
    float speed;

	// Use this for initialization
	void Start () {
		level=GameObject.Find("ScriptFolder").GetComponent<GenerateEnemy>().level;
        speed = 2f + level * 2f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z-speed*0.1f);
        if (transform.position.z < -5)
            Destroy(gameObject);
	}
}
