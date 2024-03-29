﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{   
    [SerializeField, HeaderAttribute("生成済みObject"), Tooltip("生成したObjectです。")]
    private GameObject gameObject;//生成するオブジェクト用。

    [SerializeField, HeaderAttribute("AssetBundle一覧"), Tooltip("読み込まれたAssetBundleの一覧です。")]
    private List<AssetBundle> assetBundles;//アセットバンドル一覧表示用
    private AssetBundleLoader assetBundleLoader;//アセットバンドルローダースクリプト参照用。

    private bool objectInstansFlag = false;//オブジェクト生成フラグ(生成したらtrue)
    private bool objectDestoryFlag = false;//オブジェクト生成フラグ(生成したらtrue)


    // Start is called before the first frame update
    void Start()
    {
        assetBundleLoader = GameObject.Find("AssetBundleLoader").GetComponent<AssetBundleLoader>();//AssetBundleLoaderオブジェクトからデータを取得
        assetBundles = assetBundleLoader.assetBundleList;//読み込んだアセットバンドルの一覧を取得
    }

    // Update is called once per frame
    void Update()
    {
        if ((objectInstansFlag == false) && (assetBundleLoader.Finish() == true))//読み込み処理が終っていてかつオブジェクト生成していないのであれば
        {
            gameObject = assetBundleLoader.assetBundleList[0].LoadAsset<GameObject>("town");//オブジェクトを読み込む

            Instantiate(gameObject);//オブジェクト生成

            objectInstansFlag = true;//オブジェクト生成フラグを立てる(trueにする)
        }

        //objectDestoryFlagがtrueなら
        if (objectDestoryFlag == true)
        {
            Destroy(gameObject);//オブジェクトを破棄

            objectInstansFlag = false;//オブジェクト生成フラグを伏せる(falseにする)
        }
    }

    //オブジェクトを破棄する。
    public void ObjectDestory()
    {
        if (gameObject != null)
        {
            objectDestoryFlag = true;
        }
        else
        {
            objectDestoryFlag = false;
        }
    }
}
