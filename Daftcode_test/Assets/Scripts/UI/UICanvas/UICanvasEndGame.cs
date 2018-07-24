using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Canvas show end game state (panel)
/// </summary>
public class UICanvasEndGame : UICanvas, IText {

	[Header ("Buttons"), SerializeField] private Button _goToMenuBtn;
	[SerializeField] private Button _restartGameBtn;

	[Header ("Texts"), SerializeField] private Text _sessionScore;
	[SerializeField] private Text _highGameScore;

	private void OnEnable () {
		_restartGameBtn.onClick.AddListener (() => CanvasSwitcher.Instance.EnableGamePlayCanvas ());
		_goToMenuBtn.onClick.AddListener (() => CanvasSwitcher.Instance.EnableMenuCanvas ());

		_sessionScore.text = ScoreManager.Instance.PlayerScore.ToString ();
		_highGameScore.text = ScoreManager.Instance.HighRecordScore.ToString ();
	}

	private void OnDisable () {
		_restartGameBtn.onClick.RemoveAllListeners ();
		_goToMenuBtn.onClick.RemoveAllListeners ();
	}
}
