using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class duplicationPosition : MonoBehaviour
{
    public GameObject originObject;//�R�s�[���i�I���W�i���̃I�u�W�F�N�g���A�^�b�`����Ă���I�u�W�F�N�g�j

    public Vector3 position;

    [SerializeField]
    List<GameObject> instansObject = new List<GameObject>();//������


    // Start is called before the first frame update
    void Start()
    {
        instansObject.Add(Instantiate(originObject, position, originObject.transform.rotation));
    }
}
