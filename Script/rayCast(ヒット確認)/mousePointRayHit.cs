using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

//�}�E�X���烌�C���΂��ăI�u�W�F�N�g���q�b�g���邩������X�N���v�g
//���̃X�N���v�g��MainCmaera�ɂ���Ƃ悢�B
public class mousePointRayHit : MonoBehaviour
{
    public bool isHit;

    public RaycastHit rayHit;

    // Update is called once per frame
    void Update()
    {
      Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());//�X�N���[�����W�ϊ�

        isHit = Physics.Raycast(ray, out rayHit);//���C���΂�
    }
}
