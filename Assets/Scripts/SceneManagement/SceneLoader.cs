using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool IsBusy { get; private set; }

    [SerializeField] private SceneDB _sceneDB;

    private int _currentLevelSceneIndex = 2;
    private int _uiSceneIndex = -1; //in case we need to unload the ui scene in the futire

    private bool _isInit;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_isInit) return;        

        _isInit = true;
    }

    public void UnloadCurrenLevelScene()
    {
        if (!_isInit) Init();
        if (_currentLevelSceneIndex < 0) return;
        StartCoroutine(UnloadScenAsyncCoroutine(_currentLevelSceneIndex));
    }

    public void LoadLevel(int levelNumber)
    {
        LoadScene(SceneType.Level, levelNumber, out _currentLevelSceneIndex);
    }

    public void LoadUIScene()
    {
        LoadScene(SceneType.UI, 0, out _uiSceneIndex);
    }

    private void LoadScene(SceneType sceneType, int levelNumber, out int sceneIndex)
    {
        if (!_isInit) Init();
        int sceneBuildIndex = _sceneDB.GetSceneIndex(sceneType, levelNumber);
        sceneIndex = sceneBuildIndex;
        if (sceneBuildIndex < 0) return;
        StartCoroutine(LoadSceneAsyncCoroutine(sceneIndex));
    }

    private IEnumerator UnloadScenAsyncCoroutine(int sceneIndex)
    {
        IsBusy = true;
        var operation = SceneManager.UnloadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            yield return null;
        }
        IsBusy = false;
    }

    private IEnumerator LoadSceneAsyncCoroutine(int sceneIndex)
    {
        IsBusy = true;
        var operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        while (!operation.isDone)
        {
            yield return null;
        }
        IsBusy = false;
    }

    
}
