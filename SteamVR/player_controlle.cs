using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

//CameraRigにアタッチ
//重力処理は要変更
public class player_controlle : MonoBehaviour
{

    //default以外のActionSetを取得する
    public SteamVR_ActionSet myAction;

    //移動速度倍率
    public float scale = 0.1f;

    //キャラクターコントローラーを取得
    public CharacterController character_controller;


    // Start is called before the first frame update
    void Start()
    {
        character_controller = GetComponent<CharacterController>();//キャラクターコントローラー取得
        myAction.ActivatePrimary(true);
    }

    // Update is called once per frame
    void Update()
    {
        //移動速度を取得
        Vector3 move_speed = new Vector3(SteamVR_Input.__actions_MySet_in_move.GetAxis(SteamVR_Input_Sources.LeftHand).x, 0, SteamVR_Input.__actions_MySet_in_move.GetAxis(SteamVR_Input_Sources.LeftHand).y);


        //それぞれトラックパッドの有効範囲を指定(自身の移動)
        character_controller.Move(move_speed.z * Camera.main.transform.forward * scale);
        character_controller.Move(move_speed.x * Camera.main.transform.right * scale);


        //角度調整ボタン
        if (SteamVR_Input.__actions_MySet_in_west.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            transform.Rotate(0, -360 / 6, 0);
        }

        if (SteamVR_Input.__actions_MySet_in_east.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            transform.Rotate(0, 360 / 6, 0);

        }


        //地面についていなければ
        if(!character_controller.isGrounded)
        {
            character_controller.Move(new Vector3(0, -0.1f, 0));
        }
    }
}
