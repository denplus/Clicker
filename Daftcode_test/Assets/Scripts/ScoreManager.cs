using UnityEngine;

/// <summary>
/// Class response for game score logic
/// </summary>
public class ScoreManager : SingeltonMonoBehaviour<ScoreManager> {
	public int PlayerScore { get; set; }
	public int HighRecordScore { get; set; }

	private void OnEnable () {
		SliderTimeController.Instance.GameIsFinished += UpdateHighScore;

		HighRecordScore = DataSaver.Instance.LoadHighScore ();
	}

	private void OnDisable () {
		SliderTimeController.Instance.GameIsFinished -= UpdateHighScore;
	}

	private void UpdateHighScore () {
		if (PlayerScore > HighRecordScore)
			HighRecordScore = PlayerScore;
	}

	public void ResetPlayerScore () {
		PlayerScore = 0;
	}
}
