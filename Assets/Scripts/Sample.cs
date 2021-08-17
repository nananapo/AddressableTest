using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Sample : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        var www = UnityWebRequestAssetBundle.GetAssetBundle("http://192.168.1.47:5500/scene");

        await www.SendWebRequest();
        
        if(www.result == UnityWebRequest.Result.Success) {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            
            if (!bundle.isStreamedSceneAssetBundle)
            {
                await bundle.LoadAllAssetsAsync();
            }
            
            Debug.Log(bundle.GetAllScenePaths().Length);
            
            var sceneName = Path.GetFileNameWithoutExtension(bundle.GetAllScenePaths()[0]);
            SceneManager.LoadScene(sceneName);
        }
        else {
            Debug.Log(www.error);
        }
    }
}
