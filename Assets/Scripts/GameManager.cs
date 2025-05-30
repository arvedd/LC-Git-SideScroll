using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Game Manager
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Game Management
    public bool isPaused;

    public void ChangeScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
    #endregion

    #region 
    LevelData levelData;
    public int levelCurrent;

    public void CheckSaveFile()
    {
        if (File.Exists(Application.dataPath + "/Level.json"))
        {
            LoadLevel();
        }
        else
        {
            SaveLevel();
        }
    }

    private void SaveLevel()
    {
        levelData = new LevelData();
        levelData.level = levelCurrent;

        string json = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(Application.dataPath + "/Level.json", json);
    }

    private void LoadLevel()
    {
        string json;
        json = File.ReadAllText(Application.dataPath + "/Level.json");
        // LevelData levelData = 
    }

    #endregion
}
