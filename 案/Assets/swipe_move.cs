using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe_move : MonoBehaviour {

    Transform player;
    public float power;

    Touch tch;
    Vector2 dic;
    float speed;

	// Use this for initialization
	void Start () {
        player = GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {

        //タッチ情報を取得。
        tch = Input.GetTouch(0);

        speed = Time.deltaTime / tch.deltaPosition.magnitude;//元の速さを出す。
        speed *= power;//速さの強さを決める。

        dic = tch.deltaPosition - tch.position;//方向を決める。

        player.position = new Vector3((speed * dic.x) + player.position.x, (speed * dic.y) + player.position.y, 0.0f);

    }
}
