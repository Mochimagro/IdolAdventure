using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject MainPlayer;
	[SerializeField] private List<GameObject> PartyCharacterList = new List<GameObject> ();
	private PlayerController playerController;
	private TalkManager talkManager;
	[SerializeField] private CameraMultiTarget cameraMultiTarget;

	public virtual GameObject MainPlayer_Object {
		get {
			return MainPlayer;
		}
		set {
			MainPlayer = value;
		}
	}

	public virtual PlayerController MainPlayer_Contriller {
		get {
			return MainPlayer_Contriller;
		}
		set {
			playerController = value;
		}
	}

	private void Start () {
		MainPlayer_Contriller = GetComponent<PlayerController> ();
		talkManager = MainPlayer.GetComponent<TalkManager> ();

		var targets = new List<GameObject> ();
		targets.Add (MainPlayer);
		/*foreach (var item in PartyCharacterList) {
			targets.Add (item);
		} */

		cameraMultiTarget.SetTargets (targets.ToArray ());
	}

	public void TalkEnd () {
		talkManager.TalkEnd ();
	}
}