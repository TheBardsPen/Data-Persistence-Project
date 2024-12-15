using System.IO;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public TMP_InputField nameInput;

    public int highScore;
    public string highName;
    public string playerName;

    private void Awake()
    {
        // Destroy duplicate datamanager
        if (instance != null)
        {
            Destroy(gameObject);
        }

        // Set persistant datamanager during gameplay
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    // Set high score and name after game over
    public void HighScore(int score, string name)
    {
        if (highScore < score)
        {
            highScore = score;
            highName = name;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highName;
    }

    // Save the high score and player name on exit
    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highName = highName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    // Load the high score and player name on start
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/save.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highName = data.highName;
        }
    }
}
