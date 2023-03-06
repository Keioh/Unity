using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConditionInfomationUI : MonoBehaviour
{
    public GameObject mainCamera;

    TextMeshProUGUI m_TextMeshProUGUI;
    string terrainInfo = "Condition:";

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
            TerrainInfomation terrainInfomation = mainCamera.GetComponent<mousePointRayHit>().rayHit.collider.gameObject.GetComponent<TerrainInfomation>();

            m_TextMeshProUGUI.text = terrainInfo + terrainInfomation.GetConditionType().ToString();
        }
        else
        {
            m_TextMeshProUGUI.text = terrainInfo;
        }
    }
}
