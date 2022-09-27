using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SceneDB", menuName ="SceneDB")]
public class SceneDB : ScriptableObject
{
    [SerializeField][Tooltip("Do not use it for Level Scene Types!\nUse Level Scenes instead")] 
    private SceneData[] _scenes;
    [SerializeField] private LevelSceneData[] _levelScenes;

    public int GetSceneIndex(SceneType sceneType, int level = 0)
    {
        if (_scenes == null) return -1;

        if (sceneType == SceneType.Level) return GetLevelSceneIndex(level);

        int N = _scenes.Length;
        for (int i = 0; i < N; i++)
        {
            if (_scenes[i].SceneType == sceneType)
            {
                return _scenes[i].BuildIndex;
            }
        }

        return -1;
    }

    private int GetLevelSceneIndex(int level)
    {
        if (_levelScenes == null) return -1;

        int N = _levelScenes.Length;
        for (int i = 0; i < N; i++)
        {
            if (_levelScenes[i].LevelNumber == level)
            {
                return _levelScenes[i].BuildIndex;
            }
        }

        return -1;
    }


}

[System.Serializable]
public class SceneData
{
    public int BuildIndex => _buildIndex;
    public SceneType SceneType => _sceneType;

    [SerializeField] private int _buildIndex;
    [SerializeField] private SceneType _sceneType;
}

[System.Serializable]
public class LevelSceneData : SceneData
{
    public int LevelNumber => _levelNumber;

    [SerializeField] private int _levelNumber;
}

public enum SceneType
{
    Main, 
    UI,
    Level
}
