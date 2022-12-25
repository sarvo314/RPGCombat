using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{

	[MenuItem("Assets/Build AssetBundles")]
	static void BuildAllAssetBundles()
	{
        if (Caching.ClearCache())
        {
			Debug.Log("clear");

        }
        //BuildPipeline.BuildAssetBundles("Assets/AssetBundles/AssetBundlesAndroid", BuildAssetBundleOptions.None, BuildTarget.Android);
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles/AssetBundlesWebGL", BuildAssetBundleOptions.None, BuildTarget.WebGL);
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles/AssetBundlesWindows64", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}