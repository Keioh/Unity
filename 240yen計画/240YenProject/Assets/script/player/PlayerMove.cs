using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //pubilc
    public float move_speed;

    //private  
    int touch_count;
    int charge;//攻撃チャージ
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
        Camera.main.transform.position = new Vector3(transform.position.x, 5.0f, transform.position.z);//カメラの位置をプレーヤーオブジェクトに追従

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
                    touch_count++;//タッチ継続を判定する値を増やす
                    if (touch_count > 5)//タッチが5フレーム以上タッチされていたら。
                    {
                        transform.localScale = new Vector3(55.0f, 55.0f, 55.0f);//テスト(タッチが5フレーム以上になったらちょっとだけ拡大)
                        charge += 5;//チャージをする。
                        if (charge > 250) charge = 250;//250以上にならないようにする。                   
                    }
                    break;

                case TouchPhase.Ended://タッチ終わり

                    touch_ended_position = touch.position;//離したときの座標を保存  
                    touch_vector = touch_began_position - touch_ended_position;//座標の差を保存

                    //50*50以上のスワイプがあったとき
                    if ((Mathf.Abs(touch_vector.x) >= 50.0f) || (Mathf.Abs(touch_vector.y) >= 50.0f))
                    {
                        //移動処理
                        //水平移動するためにrigidbodyに力を加える
                        rigidbody.AddForce(new Vector3(-touch_vector.x * move_speed, 0.0f, -touch_vector.y * move_speed), ForceMode.Force);
                    }
                    else if ((touch_vector.x == 0.0f) || (touch_vector.y == 0.0f))//指を動かしていないとき
                    {
                        //タップ攻撃(タッチ継続カウントが0なら)
                        if (touch_count < 5)
                        {
                            transform.localScale = new Vector3(45.0f, 45.0f, 45.0f);//テスト(タッチが0フレームだったらちょっとだけ縮小)
                        }
                        else if ((touch_count > 5))//ジャンプ処理
                        {
                            rigidbody.AddForce(new Vector3(0.0f, charge, 0.0f), ForceMode.Force);//y方向に力をかける
                        }
                    }

                    charge = 0;//ジャンプのチャージをリセット
                    touch_count = 0;//ジャンプとタップ攻撃のタッチ継続値をリセット
                    break;
            }
        }
        else
        {
            transform.localScale = new Vector3(50.0f, 50.0f, 50.0f);//スケールをもとに戻す。
        }
    }
}
