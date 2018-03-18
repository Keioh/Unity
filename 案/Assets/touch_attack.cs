using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_attack : MonoBehaviour
{

    public Transform player;//引き寄せられる対象

    float speed;
    Touch screen_touch;
    Transform trns;
    Vector3 pos;

    // Use this for initialization
    void Start()
    {
        trns = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        screen_touch = Input.GetTouch(0);//タッチ情報を取得

        //タッチしてるけど指を動かさないときの処理
        if (screen_touch.phase == TouchPhase.Stationary)
        {

            //引き寄せる処理
            if (speed < 1)
            {
                speed += 0.01f * Time.deltaTime;
            }
            else if (speed > 1)
            {
                speed = 1.0f;
            }

            pos = trns.position - player.position;

            trns.Translate(pos * -speed);
        }
    }
}