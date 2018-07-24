using UnityEngine;

/// <summary>
/// Canvas show play game state (panel)
/// </summary>
public class UICanvasGamePlay : UICanvas {

	[SerializeField] private UICountDown _uICountDown;
	[SerializeField] private UIGamePanel _uiGamePanel;

	private void OnEnable () {
		_uICountDown.CountDownIsFinished += _uICountDown_CountDownIsFinished;
		SliderTimeController.Instance.GameIsFinished += OnGameIsFinished;

		_uiGamePanel.gameObject.SetActive (false);
		_uICountDown.gameObject.SetActive (true);
		_uICountDown.StartCountDown ();

		ScoreManager.Instance.ResetPlayerScore ();
	}

	private void OnDisable () {
		_uICountDown.CountDownIsFinished -= _uICountDown_CountDownIsFinished;
		SliderTimeController.Instance.GameIsFinished -= OnGameIsFinished;
	}

	#region CallBackForEvents
	private void _uICountDown_CountDownIsFinished () {
		_uICountDown.gameObject.SetActive (false);
		_uiGamePanel.gameObject.SetActive (true);
		SliderTimeController.Instance.StartGameSessionTimer ();
		InputCounter.Instance.StartInputCounter ();
	}

	private void OnGameIsFinished () {
		InputCounter.Instance.StopInputCounter ();
		CanvasSwitcher.Instance.EnableEndGameCanvas ();
		DataSaver.Instance.SaveHighScore ();
	}
	#endregion
}
