using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duplicationYZ : MonoBehaviour
{
    public GameObject originObject;//�R�s�[���i�I���W�i���̃I�u�W�F�N�g���A�^�b�`����Ă���I�u�W�F�N�g�j

    public int y;//�������鐔�iY�����j
    public int z;//�������鐔�iZ�����j

    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//������


    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = Vector3.zero;
        for (int count_y = 0; count_y < y; count_y++)
        {
            pos.y = count_y * originObject.transform.localScale.y;

            for (int count_z = 0; count_z < z; count_z++)
            {
                pos.z = count_z * originObject.transform.localScale.z;

                instansObject.Add(Instantiate(originObject, pos, originObject.transform.rotation));
            }
        }
    }
}