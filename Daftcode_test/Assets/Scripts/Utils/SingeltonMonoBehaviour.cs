using UnityEngine;

/// <summary>
/// Generic class for realization singelton pattern
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingeltonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
	private static T _instance;
	public static T Instance {
		get {
			if (_instance != null)
				return _instance;

			return CheckIfMoreThenOneInstanceOnScene ();
		}
		set { _instance = value; }
	}

	public static bool IsExist { get { return _instance != null; } }

	public void CreateInstance (T obj) {
		Instance = obj;
	}

	private static T CheckIfMoreThenOneInstanceOnScene () {
		T[] instances = FindObjectsOfType<T> ();
		if (instances.Length == 1)
			return instances[0];

		if (instances.Length == 0) {
			Debug.Log (string.Format ("<color=red>[Problem in SingeltonMonoBehaviour] </color>"));
			return null;
		}

		for (int i = 1; i < instances.Length; i++)
			Destroy (instances[i]);

		return instances[0];
	}

	
}
