using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncLevelLoader : GameMonoBehaviour
{

    private static AsyncLevelLoader instance;

    public static AsyncLevelLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AsyncLevelLoader>();
            }
            return instance;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
        {
            instance = this;
        }
    }

    protected override void Start()
    {
        base.Start();
        Application.targetFrameRate = 120;
    }

    private LoadingMenuManager loadingMenuManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.loadingMenuManager = MenuManager.Instance.GetMenu(Menu.LOADING).GetComponent<LoadingMenuManager>();
    }

    public void LoadLevel(string levelName)
    {
        MenuManager.Instance.SwitchCanvas(Menu.LOADING);
        StartCoroutine(this.LoadLevelAsync(levelName));
    }

    IEnumerator LoadLevelAsync(string levelName)
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(levelName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            this.loadingMenuManager.SetSliderValue(progress);
            yield return null;
        }
    }
}
