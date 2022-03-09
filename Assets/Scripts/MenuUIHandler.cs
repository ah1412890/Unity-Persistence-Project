using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI bestScoreText;

	private void Start()
	{
		MenuManager.instance.LoadScores();
		GetBestScore();
	}

	private void GetBestScore()
	{
		bestScoreText.SetText($"Best Score:\n{MenuManager.instance.bestPlayer} {MenuManager.instance.bestScore}");
	}

	[SerializeField] public void ReadPlayerName(string str)
	{
		MenuManager.instance.playerName = str;
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void GoToHighScores()
	{
		SceneManager.LoadScene(2);
	}

	public void ExitGame()
	{
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}
}
