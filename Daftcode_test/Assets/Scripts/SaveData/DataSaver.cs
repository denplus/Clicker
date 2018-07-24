using UnityEngine;
/// <summary>
/// Class save game data and load with PlayerPrefs
/// </summary>
public class DataSaver : SingeltonMonoBehaviour<DataSaver> {

	public int LoadHighScore () {
		if (PlayerPrefs.HasKey (Const.HighScoreData))
			return PlayerPrefs.GetInt (Const.HighScoreData);
		return 0;
	}

	public void SaveHighScore () {
		PlayerPrefs.SetInt (Const.HighScoreData, ScoreManager.Instance.HighRecordScore);
	}

}
