using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    AsyncOperation asyncOperation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouch()
    {
        asyncOperation.allowSceneActivation = true;
    }
}
