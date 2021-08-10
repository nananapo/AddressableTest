using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Sample : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        var cube = await Addressables.InstantiateAsync("Assets/Prefab/Cube.prefab"); 
    }

    private async UniTask Wait()
    {
        Debug.Log("a");
        await Task.Delay(5000);
        Debug.Log("b");
    }
}
