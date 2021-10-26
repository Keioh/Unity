using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//アセットバンドルのパスとAsync設定の型
[System.Serializable]
public class AssetBundleLoaderSettingData
{
    public string filePath;//ファイルパス
    public bool async;//非同期の設定
}


public class AssetBundleLoader : MonoBehaviour
{
    [SerializeField, HeaderAttribute("ファイルパスと読み込み設定"), Tooltip("FilePathにはAssetBundleのパスを指定します。\nAsyncにチェックするとAssetBundleの読み込みを非同期で行います。")]
    private List<AssetBundleLoaderSettingData> assetBundleLoaderSettingDataList = new List<AssetBundleLoaderSettingData>();
    private AssetBundleLoaderSettingData assetBundleLoaderSettingData;

    [HeaderAttribute("読み込み済みAssetBundle"), Tooltip("読み込まれたAssetBundleの一覧です。")]//インスペクター上で見えるprivate群
    public List<AssetBundle> assetBundleList;//アセットバンドルのリスト

    private AssetBundleCreateRequest assetBundleCreateRequest;//AssetBundleの非同期読み込み用
    private AssetBundle assetBundle;//asset_bundleの一時保存用。

    private bool finishFlag = false;//読み込みが終ったかのフラグ


    //読み込み処理が完了したらtrueを返す関数。(読み込みが終ったかの確認ではない。)
    public bool Finish()
    {
        return finishFlag;//読み込み終了フラグを返す。
    }


    // Start is called before the first frame update
    void Start()
    {

        finishFlag = false;//読み込みフラグをfalseにする。

        for (int count = 0; count != assetBundleLoaderSettingDataList.Count; ++count)//asset_bundle_pathの数だけ繰り返す。
        {
            //AssetBundleの非同期読み込み設定がtrueなら非同期読み込みをする。
            if (assetBundleLoaderSettingDataList[count].async == true)
            {
                Debug.Log("AssetBundleLoader:非同期読み込み [" + (count + 1) + "個目(Element" + count + ")]");

                assetBundleCreateRequest = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(assetBundleLoaderSettingDataList[count].filePath));//非同期読み込み処理(同期読み込みの場合はこの行を削除し、下の行のコメント部分をassetBundleCreateRequest部分と入れ替える。)

                assetBundle = assetBundleCreateRequest.assetBundle;//アセットバンドルを読み込む
            }
            else
            {
                Debug.Log("AssetBundleLoader:同期読み込み [" + (count + 1) + "個目(Element" + count + ")]");

                assetBundle = AssetBundle.LoadFromFile(assetBundleLoaderSettingDataList[count].filePath);//アセットバンドルを読み込む
            }

            assetBundleList.Add(assetBundle);//読み込んだアセットバンドルをasset_bundle_listに追加。
        }

        finishFlag = true;//読み込みフラグをtrueにする。
    }
}
