using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Load load_object;
    public float move_speed = 5.0f;//移動速度
    public float jump_power = 1000.0f;//ジャンプの力(velocity)
    public float camera_y = 2.0f;//キャラクターの位置からどのくらいY軸方向にカメラをずらすか

    bool jump_flag;//ジャンプしていればtrue

    Transform transform_obj;
    Rigidbody2D rigidbody2d_obj;
    Animator animator;
    Quaternion quaternion;

    // Start is called before the first frame update
    void Start()
    {
        transform_obj = GetComponent<Transform>();
        rigidbody2d_obj = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //カメラをプレイヤーキャラクターに移動
        Camera.main.transform.position = new Vector3(transform_obj.position.x, transform_obj.position.y + camera_y, -10);

        //アニメーションを再生
        if (jump_flag == false)
        {
            if (Input.GetAxis("Horizontal") == 0)
            {
                animator.Play("Idle");
            }

            
            if (Input.GetAxis("Horizontal") != 0)
            {       
                animator.SetFloat("walk_run", Mathf.Abs(Input.GetAxis("Horizontal") * 1.5f));
                animator.Play("walk_and_run");
            }
        }
        else
        {
            if (rigidbody2d_obj.velocity.y > 0)
            {
                animator.Play("jump_up");
            }
            else if (rigidbody2d_obj.velocity.y < 0)
            {
                animator.Play("jump_down");
            }
        }

        //移動とオブジェクトの回転
        if (Input.GetAxis("Horizontal") > 0)
        {
            quaternion.eulerAngles = new Vector3(0, 0, 0);
            transform_obj.rotation = quaternion;        
            
            transform_obj.Translate((Input.GetAxis("Horizontal") * move_speed) * Time.deltaTime, 0.0f, 0.0f);

        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            quaternion.eulerAngles = new Vector3(0, 180, 0);
            transform_obj.rotation = quaternion;
            transform_obj.Translate((-Input.GetAxis("Horizontal") * move_speed) * Time.deltaTime, 0.0f, 0.0f);

        }

        //攻撃
        if (Input.GetButtonDown("Fire1") == true)
        {
            Vector3 vector = new Vector3();

            //右向いている時に発射位置を右にずらす
            if (quaternion.eulerAngles.y == 0)
            {
                vector = new Vector3(transform_obj.position.x + 1.0f, transform_obj.position.y + 1.5f, transform_obj.position.z);
            }

            //左向いている時に発射位置を左にずらす
            if (quaternion.eulerAngles.y == 180)
            {
                vector = new Vector3(transform_obj.position.x - 1.0f, transform_obj.position.y + 1.5f, transform_obj.position.z);
            }

            //クローンを作成し、オブジェクトを飛ばす
            Instantiate(load_object.attack_object, vector, quaternion);
        }


        //ジャンプ(Jumpボタンが押された瞬間かつ地面に足がついていたら)
        if ((Input.GetButtonDown("Jump") == true) && (jump_flag == false))
        {
            //リジッドボディーのベロシティを変更
            rigidbody2d_obj.velocity = new Vector2(0.0f, jump_power);

            //ジャンプフラグをtrueに(ジャンプしている)
            jump_flag = true;
        }
    }

    //コライダーが当たっていたら
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //タグGroundだったら
        if (collision.gameObject.CompareTag("Ground") == true)
        {
            //ジャンプフラグをfalseにする。(ジャンプしていない)
            jump_flag = false;
        }
    }
}
