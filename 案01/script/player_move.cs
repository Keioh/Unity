using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour {

    public float speed;

    Transform pos;
    float horizontal, vertical;

	// Use this for initialization
	void Start () {

        //マイナスを取っていたら0で初期化
        if (speed < 0) speed = 0;

        pos = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        horizontal = (Input.GetAxis("Horizontal") * speed) + pos.transform.position.x;
        vertical = (Input.GetAxis("Vertical") * speed) + pos.transform.position.y;

        pos.transform.position = new Vector3(horizontal, vertical, 0.0f);
	}
}
