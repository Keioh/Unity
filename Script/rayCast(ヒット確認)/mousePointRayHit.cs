using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

//�}�E�X���烌�C���΂��ăI�u�W�F�N�g���q�b�g���邩������X�N���v�g
//���̃X�N���v�g��MainCmaera�ɂ���Ƃ悢�B
public class mousePointRayHit : MonoBehaviour
{
    public string isHitName = "none";

    RaycastHit rayHit;
    Ray ray;


    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());//�X�N���[�����W�ϊ�

        if(Physics.Raycast(ray, out rayHit, Mathf.Infinity))//���C���΂�
        {
            isHitName = rayHit.collider.name;
        }
        else
        {
            isHitName = "none";
        }
    }

    //���C���I�u�W�F�N�g�Ƀq�b�g���̊m�F�֐�
    RaycastHit GetRaycastHit()
    {
        return rayHit;
    }
}
