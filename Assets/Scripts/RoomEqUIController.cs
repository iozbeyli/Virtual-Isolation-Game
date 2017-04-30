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
		Text[] children = eqGroup.GetComponentsInChildren<Text> ();
		foreach (Text c in children) {
			if (c.gameObject.name.Equals ("Title")) {
				c.text = eq.label;
			} else if (c.gameObject.name.Equals ("Description")) {
				c.text = eq.description;
			}
		}
	}
}
