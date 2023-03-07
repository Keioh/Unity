using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainInfomation : MonoBehaviour
{
    public bool isCentralArea;//�����n�Ȃ�true�ɐݒ�

    public ChangeMaterial changeMaterial;//�}�e���A����ύX����X�N���v�g

    [SerializeField]
    SoilType.SOIL_TYPES soilType;

    [SerializeField]
    ConditionType.CONDITION_TYPES conditionType;

    [SerializeField]
    List<DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE> developmentResourcesType = new List<DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE>();

    // Start is called before the first frame update
    void Start()
    {
        //�Y�o����J�񎑌��̃��Z�b�g
        developmentResourcesType.Clear();

        if (isCentralArea == true)//�����n�Ȃ�
        {
            changeMaterial.Change((int)SoilType.SOIL_TYPES.CENTRAL);

            //���ꂼ��̃^�C�v����
            soilType = SoilType.SOIL_TYPES.CENTRAL;
            conditionType = ConditionType.CONDITION_TYPES.MEDIOCRE;

            //�y�n���Y�o���郉���_���Ȏ�����3���߂�B
            int developmentResourcesTypeRandomValu = 3;

            //�J�񎑌��̒ǉ���3��J��Ԃ�
            for (int count = 0; count < developmentResourcesTypeRandomValu; count++)
            {
                //�����_���Ȏ��������肷��
                int developmentResourcesTypeRandomType = Random.Range(0, 7);

                //������ǉ�
                developmentResourcesType.Add((DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE)developmentResourcesTypeRandomType);
            }
        }
        else//�����n�łȂ��Ȃ�
        {
            //�eenum�萔�̑�������p�����[�^�̎�ނ������_���Ɍ��߂�B
            int soil_rand = Random.Range(1, 8);
            int condition_rand = Random.Range(0, 8);

            changeMaterial.Change(soil_rand);

            //���ꂼ��̃^�C�v����
            soilType = (SoilType.SOIL_TYPES)soil_rand;
            conditionType = (ConditionType.CONDITION_TYPES)condition_rand;

            //�y�n���Y�o���郉���_���Ȏ������Œ�1�A�ő�3���߂�B
            int developmentResourcesTypeRandomValu = Random.Range(1, 4);

            for (int count = 0; count < developmentResourcesTypeRandomValu; count++)
            {
                int developmentResourcesTypeRandomType = Random.Range(0, 7);

                developmentResourcesType.Add((DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE)developmentResourcesTypeRandomType);
            }
        }
    }



    public SoilType.SOIL_TYPES GetSoilType()
    {
        return soilType;
    }

    public ConditionType.CONDITION_TYPES GetConditionType()
    {
        return conditionType;
    }

    public List<DevelopmentResourcesType.DEVELOPMENT_RESOURCES_TYPE> GetDevelopmentResourcesTypeList()
    {
        return developmentResourcesType;
    }
}
