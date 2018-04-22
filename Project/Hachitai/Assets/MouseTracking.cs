using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracking : MonoBehaviour {
    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;
    private GameObject cam;
    public float euclidean_distance;
    // Use this for initialization
    void Start()
    {
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3でマウス位置座標を取得する
        position = Input.mousePosition;
        // Z軸修正
        position.z = cam.transform.position.z+20;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標と車のユークリッド距離を計算する
        euclidean_distance = Mathf.Sqrt(Mathf.Pow(screenToWorldPointPosition.x - transform.position.x, 2) + Mathf.Pow(screenToWorldPointPosition.y - transform.position.y, 2));
        // 車をマウスに追従させる
        //gameObject.transform.position = screenToWorldPointPosition;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(screenToWorldPointPosition.x, screenToWorldPointPosition.y), (4*euclidean_distance) * Time.deltaTime);
    }
}
