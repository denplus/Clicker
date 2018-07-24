using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Canvas show start menu state (panel)
/// </summary>
public class UICanvasMenu : UICanvas, IText {

	[SerializeField] private Button _startGameBtn;
	[SerializeField] private Text _highScoreText;

	private void OnEnable () {
		_startGameBtn.onClick.AddListener (delegate { CanvasSwitcher.Instance.EnableGamePlayCanvas (); });

		_highScoreText.text = ScoreManager.Instance.HighRecordScore.ToString (); // update hight score
	}

	private void OnDisable () {
		_startGameBtn.onClick.RemoveAllListeners ();
	}
}
