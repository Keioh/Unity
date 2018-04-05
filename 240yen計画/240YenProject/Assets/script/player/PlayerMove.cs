using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //pubilc
    public float move_speed;

    //private
    Rigidbody rigidbody;//剛体
    Transform transform;//オブジェクトのtransform
    Touch touch;//タッチ情報
    Vector2 touch_began_position, touch_ended_position, touch_vector;//タッチの座標保存
    Vector3 began_position, ended_position, position_vector;//オブジェクトの座標保存
    bool touch_ended_flag;//タッチがおわったときのフラグ

    // Use this for initialization
    void Start()
    {
        touch_ended_flag = false;
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (touch_ended_flag == false))//タッチ数が1以上なら(touch_ende_flagは一回のフリックで不確定距離すすまないためのフラグ)
        {
            touch = Input.GetTouch(0);//最初にタッチされたタッチ情報を取得

            switch (touch.phase)
            {
                case TouchPhase.Began://タッチししたときの処理
                    touch_began_position = touch.position;//はじめにタッチした座標を保存
                    began_position = transform.position;//オブジェクトの移動前の位置を保存
                    break;

                case TouchPhase.Stationary://タッチしているが動かさないときの処理
                    break;

                case TouchPhase.Ended://タッチ終わり
                    touch_ended_position = touch.position;//離したときの座標を保存    

                    touch_vector = touch_began_position - touch_ended_position;//座標の差を保存

                    touch_ended_flag = true;

                    break;
            }
        }

        if (touch_ended_flag == true)
        {
            //rigidbodyに力を加える
            rigidbody.AddForce(new Vector3(-touch_vector.x * move_speed, 0.0f, -touch_vector.y * move_speed), ForceMode.Force);
            touch_vector = Vector3.zero;
            touch_ended_flag = false;
        }
    }
}
