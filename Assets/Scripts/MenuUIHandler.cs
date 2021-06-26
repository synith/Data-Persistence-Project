using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI inputName;
    [SerializeField]private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        highScoreText.text = $"Best Score: {ScoreManager.Instance.HighScore} - {ScoreManager.Instance.HighScorePlayer}";
    }

    public void StartNew()
    {
        ScoreManager.Instance.PlayerName = inputName.text;
        SceneManager.LoadScene(1);
    }
    
    public void Exit()
    {
        ScoreManager.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
