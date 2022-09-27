using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneDB _sceneDB;

    private int _currentLevelSceneIndex = 2;
    private int _uiSceneIndex = -1;

    public void UnloadCurrenLevelScene()
    {
        SceneManager.UnloadScene(_currentLevelSceneIndex);
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
        int sceneBuildIndex = _sceneDB.GetSceneIndex(sceneType, levelNumber);
        sceneIndex = sceneBuildIndex;
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Additive);
    }
    
}
