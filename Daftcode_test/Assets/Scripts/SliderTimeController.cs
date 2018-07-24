using UnityEngine;
using System.Collections;

/// <summary>
/// Class response for updating slider and time values in play mode
/// </summary>
public class SliderTimeController : SingeltonMonoBehaviour<SliderTimeController> {

	public event System.Action<float> ElapsedGameTime = delegate { };
	public event System.Action GameIsFinished = delegate { };

	[SerializeField] private UIGamePanel _uiGamePanel;
	[Header ("Game time"), SerializeField] private float _gameTime;
	public float GameTime { get { return _gameTime; } }

	public void StartGameSessionTimer () {
		StopAllCoroutines ();
		StartCoroutine (SessionTimer ());
	}

	private IEnumerator SessionTimer () {
		float sessionTime = GameTime;

		while (sessionTime > 0f) {
			sessionTime -= Time.deltaTime;
			ElapsedGameTime (sessionTime); // fire event
			yield return null;
		}

		GameIsFinished (); // fire event
	}
}
