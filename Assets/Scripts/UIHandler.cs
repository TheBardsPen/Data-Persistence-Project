using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI nameCheckText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            highScoreText.text = $"High Score : {DataManager.instance.highName} : {DataManager.instance.highScore}";
        }
    }

    public void StartGame()
    {
        if (DataManager.instance.nameInput.text != "")
        {
            SceneManager.LoadScene("main");
        }
        else
        {
            StartCoroutine(CheckForName());
        }
    }

    public void ExitGame()
    {
        DataManager.instance.SaveGame();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public IEnumerator CheckForName()
    {
        nameCheckText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        nameCheckText.gameObject.SetActive(false);
    }
}
