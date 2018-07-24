using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class response for main play mode UI logic
/// </summary>
public class UIGamePanel : MonoBehaviour, IText {

	[SerializeField] private Slider _timeSlider;
	[SerializeField] private Text _timeSliderText;
	[SerializeField] private Text _currentScoreText;

	private void OnEnable () {
		InputCounter.Instance.PlayerTouch += UpdateScore;
		SliderTimeController.Instance.ElapsedGameTime += UpdateTime;

		ResetValues ();
	}

	private void OnDisable () {
		InputCounter.Instance.PlayerTouch -= UpdateScore;
		SliderTimeController.Instance.ElapsedGameTime -= UpdateTime;
	}

	#region CallBackForEvents
	public void UpdateScore (int newScore) {
		_currentScoreText.text = newScore.ToString (); // can be done with StringBuilder, but I wanted to keep it simple
	}

	public void UpdateTime (float time) {
		_timeSlider.value = time / SliderTimeController.Instance.GameTime;
		_timeSliderText.text = ((int)(time + 1)).ToString () + " s"; // can be done with StringBuilder, but I wanted to keep it simple
	}
	#endregion

	private void ResetValues () {
		_currentScoreText.text = "0";
		_timeSlider.value = 1;
		_timeSliderText.text = SliderTimeController.Instance.GameTime.ToString () + " s";
	}
}
