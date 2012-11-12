using UnityEngine;
using System.Collections;

public class Split : MonoBehaviour {

	// trigger the cell splitting
	void OnMouseUp() {
		// Trigger the change on the parent cell
		transform.parent.gameObject.SendMessage("ChangeStateDown");
	}

}
