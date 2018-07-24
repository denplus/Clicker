using UnityEngine;

/// <summary>
/// Class response for switching UI canvases
/// </summary>
public class CanvasSwitcher : SingeltonMonoBehaviour<CanvasSwitcher> {

	[Header("Canvases"),SerializeField] private UICanvas _menuCanvas;
	[SerializeField] private UICanvas _gamePlayCanvas;
	[SerializeField] private UICanvas _endGameCanvas;

	private void Awake () {
		EnableMenuCanvas ();
	}

	public void EnableMenuCanvas () {
		DisableAllCanvases ();
		_menuCanvas.gameObject.SetActive (true);
	}

	public void EnableGamePlayCanvas () {
		DisableAllCanvases ();
		_gamePlayCanvas.gameObject.SetActive (true);
	}

	public void EnableEndGameCanvas () {
		DisableAllCanvases ();
		_endGameCanvas.gameObject.SetActive (true);
	}

	private void DisableAllCanvases () {
		_menuCanvas.gameObject.SetActive (false);
		_gamePlayCanvas.gameObject.SetActive (false);
		_endGameCanvas.gameObject.SetActive (false);

	}
}
