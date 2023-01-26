using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplicationXZ : MonoBehaviour
{
    public GameObject originObject;//�R�s�[���i�I���W�i���̃I�u�W�F�N�g���A�^�b�`����Ă���I�u�W�F�N�g�j

    public int x;//�������鐔�iX�����j
    public int z;//�������鐔�iZ�����j

    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//������


    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Vector3.zero;

        for (int count_x = 0; count_x < x; count_x++)
        {
            pos.x = count_x * originObject.transform.localScale.x;

            for (int count_z = 0; count_z < z; count_z++)
            {
                pos.z = count_z * originObject.transform.localScale.z;

                //�I�u�W�F�N�g�쐬
                GameObject obj = Instantiate(originObject, pos, originObject.transform.rotation);
                    
                //�I�u�W�F�N�g�̖��O��ύX
                obj.name = originObject.name + count_x as string + count_z as string;

                //���X�g�ɒǉ�
                instansObject.Add(obj);
            }
        }
    }
}