using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject MainPlayer;
	[SerializeField] private List<GameObject> PartyCharacterList = new List<GameObject> ();
	[SerializeField] private CameraMultiTarget cameraMultiTarget;

	private void Start () {
		var targets = new List<GameObject> ();
		targets.Add (MainPlayer);
		/*foreach (var item in PartyCharacterList) {
			targets.Add (item);
		} */

		cameraMultiTarget.SetTargets (targets.ToArray ());
	}

	private void SetPlayerParty () {

	}
}