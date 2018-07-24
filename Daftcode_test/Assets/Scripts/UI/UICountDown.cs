using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class response for count down UI logic
/// </summary>
public class UICountDown : MonoBehaviour, IText {

	public event Action CountDownIsFinished = delegate { };

	[Header("Count Down"),SerializeField] private Text _waitText;
	[SerializeField] private Text _countDownTimeText;

	private string[] _countDownValues = { "3", "2", "1", "GO!" };

	public void StartCountDown () {
		StopAllCoroutines ();
		StartCoroutine (CountDown());
	}

	private IEnumerator CountDown () {
		WaitForSeconds wait = new WaitForSeconds (1f);

		for (int i = 0; i < _countDownValues.Length; i++) {
			_countDownTimeText.text = _countDownValues[i];
			yield return wait;
		}

		CountDownIsFinished (); // fire event
	}
}
