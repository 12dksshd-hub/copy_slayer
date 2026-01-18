using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private AsyncOperation asyncOperation;

    [SerializeField]
    private TextMeshProUGUI loadingText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;

        StartCoroutine(ShowLoadCompleteText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouch()
    {
        if(asyncOperation.progress >= 0.9f)
            asyncOperation.allowSceneActivation = true;
    }

    private IEnumerator ShowLoadCompleteText()
    {
        while(asyncOperation.progress < 0.9f)
            yield return null;

        loadingText.gameObject.SetActive(true);
    }
}
