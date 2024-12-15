using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public int highScore;
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
    }

    // Set high score and name after game over
    public void HighScore(int score, string name)
    {
        if (highScore < score)
        {
            highScore = score;
            playerName = name;
        }
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
    }

    // Save the high score and player name on exit
    public void SaveGame()
    {

    }

    // Load the high score and player name on start
    public void LoadGame()
    {

    }
}
