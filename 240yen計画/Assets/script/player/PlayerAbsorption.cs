using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbsorption : MonoBehaviour {

    //pubilc
    public float move_speed;
    public  List<GameObject> enemy = new List<GameObject>();//引き寄せたい敵

    //private
    List<Vector3> position = new List<Vector3>();//敵とPlayerの差分位置を保存する変数
    Transform transform;//スクリプトをアタッチしているtransformを取得
    Touch touch;//現在のタッチ情報を保存するための変数
    float position_scale = 1.0f;

    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();

        for (int n = 0; enemy.Count < n; n++)//GameObject分のVector3を追加
        {
            position.Add(new Vector3(0.0f, 0.0f, 0.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)//タッチ数が1以上なら
        {
            touch = Input.GetTouch(0);//最初にタッチされたタッチ情報を取得

            switch (touch.phase)
            {
                case TouchPhase.Stationary://タッチしながら指を移動していないときの処理

                    position_scale -= move_speed * Time.deltaTime;//中心へ寄るための数値変更

                    for (int n = 0; enemy.Count < n; n++)//配列に対しての処理
                    {
                        enemy[n].transform.position *= position_scale;//敵の位置を移動
                    }

                    break;
            }
        }
    }
}
