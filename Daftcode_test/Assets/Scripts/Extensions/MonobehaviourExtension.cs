using UnityEngine;
using System.Collections;

public static class MonobehaviourExtension {
	/// <summary>
	/// Create chain of coroutines that will run in chain order
	/// </summary>
	/// <param name="obj">Put as parametr keyword "this"</param>
	/// <param name="coroutines">Chain of coroutines</param>
	/// <returns></returns>
	public static void Chain (this MonoBehaviour monoBehaviour, MonoBehaviour obj, params IEnumerator[] coroutines) {
		monoBehaviour.StartCoroutine (EnumeratorChain (obj, coroutines));
	}
	private static IEnumerator EnumeratorChain (MonoBehaviour obj, params IEnumerator[] coroutines) {
		for (int i = 0; i < coroutines.Length; i++)
			yield return obj.StartCoroutine (coroutines[i]);
	}

	/// <summary>
	/// Do some action without delay
	/// </summary>
	/// <param name="action">Some action or delegate to execute</param>
	/// <returns></returns>
	public static void ExecuteAction (this MonoBehaviour monoBehaviour, System.Action action) {
		monoBehaviour.StartCoroutine (EnumeratorExecuteAction (action));
	}
	private static IEnumerator EnumeratorExecuteAction (System.Action action) {
		if (action != null)
			action ();
		yield return 0;
	}

	/// <summary>
	/// Wait for some time, then execute some action
	/// </summary>
	/// <param name="delay">Waiting time</param>
	/// <param name="action">Some action or delegate to execute</param>
	/// <returns></returns>
	public static void ExecuteAfterDelay (this MonoBehaviour monoBehaviour, float delay, System.Action action) {
		monoBehaviour.StartCoroutine (EnumeratorExecuteAfterDelay(delay, action));
	}
	private static IEnumerator EnumeratorExecuteAfterDelay (float delay, System.Action action) {
		while (delay > 0) {
			delay -= Time.deltaTime;
			yield return 0;
		}

		if (action != null)
			action ();
		yield return 0;
	}

	/// <summary>
	/// Wait N frames and then execute action or delegate
	/// </summary>
	/// <param name="frames">Frames to wait</param>
	/// <param name="action">Some action or delegate to execute</param>
	/// <returns></returns>
	public static void ExecuteAfterNFrames (this MonoBehaviour monoBehaviour, int frames, System.Action action) {
		monoBehaviour.StartCoroutine (EnumeratorExecuteAfterNFrames (frames, action));
	}
	private static IEnumerator EnumeratorExecuteAfterNFrames (int frames, System.Action action) {
		WaitForEndOfFrame wait = new WaitForEndOfFrame ();
		for (int i = 0; i < frames; i++)
			yield return wait;

		if (action != null)
			action ();
	}

	/// <summary>
	/// Wait in game seconds delay(take in count timeScale) 
	/// </summary>
	/// <param name="delay">Time to wait</param>
	/// <returns></returns>
	public static void WaitFor (this MonoBehaviour monoBehaviour, float delay) {
		monoBehaviour.StartCoroutine (EnumeratorWaitFor (delay));
	}
	private static IEnumerator EnumeratorWaitFor (float delay) {
		yield return new WaitForSeconds (delay);
	}

	/// <summary>
	/// Wait in real seconds delay(ignore timeScale)  
	/// </summary>
	/// <param name="delay">Time to wait</param>
	/// <returns></returns>
	public static void WaitForReal (this MonoBehaviour monoBehaviour, float delay) {
		monoBehaviour.StartCoroutine (EnumeratorWaitForReal (delay));
	}
	private static IEnumerator EnumeratorWaitForReal (float delay) {
		yield return new WaitForSeconds (delay);
	}

	/// <summary>
	///  Wait for true value
	/// </summary>
	/// <param name="trigger">Some bool value</param>
	/// <returns></returns>
	public static void WaitForTrue (this MonoBehaviour monoBehaviour, bool trigger) {
		monoBehaviour.StartCoroutine (EnumeratorWaitForTrue (trigger));
	}
	private static IEnumerator EnumeratorWaitForTrue (bool trigger) {
		while (trigger == false)
			yield return 0;
	}
}
