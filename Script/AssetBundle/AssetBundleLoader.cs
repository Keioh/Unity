using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{
    [SerializeField, HeaderAttribute("AssetBundleパス"), Tooltip("AssetBundleへのパスを追加します。")]
    private List<string> assetBundlePath;//アセットバンドルのパス(実際のオブジェクト)

    private AssetBundle assetBundle;//asset_bundleの一時保存用。

    private bool loadFinishFlag = false;//読み込みが終ったかのフラグ

    [HeaderAttribute("読み込み済みAssetBundle"), Tooltip("読み込まれたAssetBundleの一覧です。")]//インスペクター上で見えるprivate群
    public List<AssetBundle> assetBundleList;//アセットバンドルのリスト



    //読み込みが完了したらtrueを返す関数。
    public bool LoadFinish()
    {
        return loadFinishFlag;//読み込み終了フラグを返す。
    }

    // Start is called before the first frame update
    void Start()
    {         
        loadFinishFlag = false;//読み込みフラグをfalseにする。

        for (int count = 0; count != assetBundlePath.Count; ++count)//asset_bundle_pathの数だけ繰り返す。
        {

            assetBundle = AssetBundle.LoadFromFile(assetBundlePath[count]);//アセットバンドルを読み込む

            assetBundleList.Add(assetBundle);//読み込んだアセットバンドルをasset_bundle_listに追加。
        }

        loadFinishFlag = true;//読み込みフラグをtrueにする。
    }
}
