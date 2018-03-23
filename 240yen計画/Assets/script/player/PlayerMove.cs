using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //pubilc
    public float move_speed;

    //private
    Transform transform;
    Touch touch;

	// Use this for initialization
	void Start ()
    {
        transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {		
        if(Input.touchCount > 0)//タッチ数が1以上なら
        {
            touch = Input.GetTouch(0);//最初にタッチされたタッチ情報を取得

            switch(touch.phase)
            {
                case TouchPhase.Began://タッチし始めの処理

                    break;

                case TouchPhase.Stationary://タッチしながら指を移動しているときの処理

                    break;

                case TouchPhase.Ended://タッチ終わり

                    break;
            }
        }
	}
}
