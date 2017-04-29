using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ChoreButton : MonoBehaviour,IPointerClickHandler {

	public void OnPointerClick(PointerEventData d){
		MonitorPanelController.activateChorePanel ();
	}

}
