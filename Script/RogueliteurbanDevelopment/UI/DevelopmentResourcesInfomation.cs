using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DevelopmentResourcesInfomation : MonoBehaviour
{
    public GameObject mainCamera;

    TextMeshProUGUI m_TextMeshProUGUI;
    string terrainInfo = "DevelopmentResource:";

    // Start is called before the first frame update
    void Start()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.GetComponent<mousePointRayHit>().isHit == true)
        {
            string all = "";

            TerrainInfomation terrainInfomation = mainCamera.GetComponent<mousePointRayHit>().rayHit.collider.gameObject.GetComponent<TerrainInfomation>();

            //m_TextMeshProUGUI.text = terrainInfo + terrainInfomation.GetDevelopmentResourcesTypeList().ToString();

            for(int count = 0; count < terrainInfomation.GetDevelopmentResourcesTypeList().Count; count++)
            {
                all += "\n" + terrainInfomation.GetDevelopmentResourcesTypeList()[count];
            }

            m_TextMeshProUGUI.text = terrainInfo + all;
        }
        else
        {
            m_TextMeshProUGUI.text = terrainInfo;
        }
    }
}