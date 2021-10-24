using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AssetBundleLoader : MonoBehaviour
{
    [SerializeField, HeaderAttribute("非同期読み込み設定"), Tooltip("チェックするとAssetBundleの読み込みを非同期で行います。")]
    private bool async = true;//trueで非同期読み込み

    [SerializeField, HeaderAttribute("AssetBundleパス"), Tooltip("AssetBundleへのパスを追加します。")]
    private List<string> assetBundlePath;//アセットバンドルのパス(実際のオブジェクト)

    private AssetBundleCreateRequest assetBundleCreateRequest;//AssetBundleの非同期読み込み用
    private AssetBundle assetBundle;//asset_bundleの一時保存用。

    private bool loadFinishFlag = false;//読み込みが終ったかのフラグ

    [HeaderAttribute("読み込み済みAssetBundle"), Tooltip("読み込まれたAssetBundleの一覧です。")]//インスペクター上で見えるprivate群
    public List<AssetBundle> assetBundleList;//アセットバンドルのリスト



    //読み込みが完了したらtrueを返す関数。
    public bool LoadFinish()
    {
        return loadFinishFlag;//読み込み終了フラグを返す。
    }

    //読み込み設定を変更する関数。(trueで非同期読み込み)
    public bool SetAsync(bool newFlag)
    {
        async = newFlag;

        return async;//新しいフラグを返す
    }


    // Start is called before the first frame update
    void Start()
    {         
        loadFinishFlag = false;//読み込みフラグをfalseにする。

        for (int count = 0; count != assetBundlePath.Count; ++count)//asset_bundle_pathの数だけ繰り返す。
        {
            //AssetBundleの非同期読み込み設定がtrueなら非同期読み込みをする。
            if (async == true)
            {
                Debug.Log("AssetBundleLoader:非同期読み込み [" + (count + 1) + "個目(Element" + count + ")]");

                assetBundleCreateRequest = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(assetBundlePath[count]));//非同期読み込み処理(同期読み込みの場合はこの行を削除し、下の行のコメント部分をassetBundleCreateRequest部分と入れ替える。)

                assetBundle = assetBundleCreateRequest.assetBundle;//AssetBundle.LoadFromFile(assetBundlePath[count]);//アセットバンドルを読み込む
            }
            else
            {
                Debug.Log("AssetBundleLoader:同期読み込み [" + (count + 1) + "個目(Element" + count + ")]");

                assetBundle = AssetBundle.LoadFromFile(assetBundlePath[count]);//アセットバンドルを読み込む
            }

            assetBundleList.Add(assetBundle);//読み込んだアセットバンドルをasset_bundle_listに追加。
        }

        loadFinishFlag = true;//読み込みフラグをtrueにする。
    }
}
