using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomEqUIController : MonoBehaviour {

	public GameObject[] eq;

	public void updatePane(List<Equipment> eqs){

		foreach (Equipment e in eqs) {
			setEq (eq[0], eqs[0]);
		}
	}

	private void setEq(GameObject eqGroup, Equipment eq){
		GameObject[] children = eqGroup.GetComponentsInChildren<Text> ();
		foreach (GameObject c in children) {
			if (c.name.Equals ("Title")) {
				((Text)c).text = eq.Label;
			} else if (c.name.Equals ("Description")) {
				((Text)c).text = eq.Description;
			}
		}
	}
}
