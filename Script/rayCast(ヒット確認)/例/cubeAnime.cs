using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cubeAnime : MonoBehaviour
{
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePointRayHit mousePointRayHit = mainCamera.GetComponent<mousePointRayHit>();

        if (mousePointRayHit.isHit == true)//�I�u�W�F�N�g�ɐG��Ă��鎞
        {
            if (mousePointRayHit.rayHit.collider.name == gameObject.name)//���O�������Ȃ�
            {
                mousePointRayHit.rayHit.transform.localScale = new Vector3(0.5f, 1.0f, 0.5f);//�X�P�[����ύX
            }
            else
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//�X�P�[����߂�
            }
        }
        else//�����G��Ă��Ȃ���
        {
               transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
