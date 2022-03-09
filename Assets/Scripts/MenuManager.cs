using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
	public static MenuManager instance;

	public string playerName;
	public string bestPlayer;
	public int bestScore;

	private void Awake()
	{
		if (instance)
		{
			Destroy(instance);
			return;
		}
		instance = this;
		DontDestroyOnLoad(instance);
	}

	public class Highscore
	{
		public string player;
		public int score;

		public Highscore(string newPlayer, int newScore)
		{
			player = newPlayer;
			score = newScore;
		}
	}

	[System.Serializable] class SaveData
	{
		public string names;
		public int scores;
	}

	public void SaveScores()
	{
		SaveData data = new SaveData();
		data.names = bestPlayer;
		data.scores = bestScore;
		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
	}

	public void LoadScores()
	{
		string path = Application.persistentDataPath + "/savefile.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);

			bestPlayer = data.names;
			bestScore = data.scores;
		}
	}

}
