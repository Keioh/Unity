using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float move_speed = 5.0f;//�ړ����x
    public float jump_power = 1000.0f;//�W�����v�̗�(velocity)
    public float camera_y = 2.0f;//�L�����N�^�[�̈ʒu����ǂ̂��炢Y�������ɃJ���������炷��

    bool jump_flag;//�W�����v���Ă����true

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
        //�J�������v���C���[�L�����N�^�[�Ɉړ�
        Camera.main.transform.position = new Vector3(transform_obj.position.x, transform_obj.position.y + camera_y, -10);

        //�A�j���[�V�������Đ�
        if (jump_flag == false)
        {
            if (Input.GetAxis("Horizontal") == 0)
            {
                animator.Play("Idle");
            }

            
            if (Input.GetAxis("Horizontal") != 0)
            {       
                animator.SetFloat("walk_run", Mathf.Abs(Input.GetAxis("Horizontal")));
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

        //�ړ��ƃI�u�W�F�N�g�̉�]
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


        //�W�����v(Jump�{�^���������ꂽ�u�Ԃ��n�ʂɑ������Ă�����)
        if ((Input.GetButtonDown("Jump") == true) && (jump_flag == false))
        {
            //���W�b�h�{�f�B�[�̃x���V�e�B��ύX
            rigidbody2d_obj.velocity = new Vector2(0.0f, jump_power);

            //�W�����v�t���O��true��(�W�����v���Ă���)
            jump_flag = true;
        }
    }

    //�R���C�_�[���������Ă�����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�^�OGround��������
        if (collision.gameObject.CompareTag("Ground") == true)
        {
            //�W�����v�t���O��false�ɂ���B(�W�����v���Ă��Ȃ�)
            jump_flag = false;
        }
    }
}
