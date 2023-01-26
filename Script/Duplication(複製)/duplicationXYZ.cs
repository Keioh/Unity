using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����X�N���v�g

public class duplicationXYZ : MonoBehaviour
{
    public GameObject originObject;//�R�s�[���i�I���W�i���̃I�u�W�F�N�g���A�^�b�`����Ă���I�u�W�F�N�g�j

    public int x;//�������鐔�iX�����j
    public int y;//�������鐔�iY�����j
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

            for (int count_y = 0; count_y < y; count_y++)
            {
                pos.y = count_y * originObject.transform.localScale.y;

                for (int count_z = 0; count_z < z; count_z++)
                {
                    pos.z = count_z * originObject.transform.localScale.z;

                    //�I�u�W�F�N�g�쐬
                    GameObject obj = Instantiate(originObject, pos, originObject.transform.rotation);

                    //�I�u�W�F�N�g�̖��O��ύX
                    obj.name = originObject.name + count_x as string + count_y as string + count_z as string;

                    //���X�g�ɒǉ�
                    instansObject.Add(obj);
                }
            }
        }
    }
}
