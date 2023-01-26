using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEditor.PlayerSettings;

public class duplicationPosition : MonoBehaviour
{
    public GameObject originObject;//�R�s�[���i�I���W�i���̃I�u�W�F�N�g���A�^�b�`����Ă���I�u�W�F�N�g�j

    public Vector3 position;

    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//������


    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g�쐬
        GameObject obj = Instantiate(originObject, position, originObject.transform.rotation);

        //�I�u�W�F�N�g�̖��O��ύX
        obj.name = originObject.name + position.x as string + position.y as string + position.z as string;

        //���X�g�ɒǉ�
        instansObject.Add(obj);
    }
}
