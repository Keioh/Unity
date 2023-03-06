using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEditor.PlayerSettings;

//�w�肵���ʒu��1�I�u�W�F�N�g�𕡐�����B
//���������I�u�W�F�N�g��List�Ɋi�[�����B

public class duplicationPosition : MonoBehaviour
{
    public GameObject originObject;//�R�s�[���i�I���W�i���̃I�u�W�F�N�g���A�^�b�`����Ă���I�u�W�F�N�g�j

    public Vector3 position;

    //public bool activeOriginal = true;//true�ŃR�s�[���̃I�u�W�F�N�g��\����ԁiUnity�I�ɂ�Active�̒l�j�ɂ���B

    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//������

    public void Add(GameObject obj, Vector3 pos, bool activeObje = true)
    {
        //�I�u�W�F�N�g�쐬
        GameObject ins_obj = Instantiate(obj, pos, obj.transform.rotation);

        //�I�u�W�F�N�g�̖��O��ύX
        ins_obj.name = obj.name + pos.x as string + pos.y as string + pos.z as string;

        //���X�g�ɒǉ�
        instansObject.Add(ins_obj);

        originObject.SetActive(activeObje);//�I���W�i���̃I�u�W�F�N�g���A�N�e�B�u��Ԃ̐ݒ�B

        Debug.Log(ins_obj.name + "Added List");
    }
}
