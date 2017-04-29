using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MaintenanceButton : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData d){
		MonitorPanelController.activateMaintenancePanel ();
	}

}
