using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonitorPanelUIController : MonoBehaviour {

	public List<GameObject> panels;
	public List<GameObject> buttons;


	public void activateTaskPanel(){
		deactivateAllPanels ();
		setActivePanel (MonitorPanelController.TASK, true);
	}

	public void activateChorePanel(){
		deactivateAllPanels ();
		setActivePanel (MonitorPanelController.CHORE, true);
	}

	public void activateMaintenancePanel(){
		deactivateAllPanels ();
		setActivePanel (MonitorPanelController.MAINTENANCE, true);
	}

	public void deactivateAllPanels(){
		for (int i = 0; i < panels.Count; i++) {
			setActivePanel (i, false);
		}
	}

	public void setActivePanel(int index, bool activeState){
		if (activeState) {
			panels [index].SetActive (true);
			panels [index].GetComponent<Image> ().color = Constants.TAB_ACTIVATED_COLOR;
			buttons [index].GetComponent<Image> ().color = Constants.TAB_ACTIVATED_COLOR;
			buttons [index].GetComponentInChildren<Text> ().color = Constants.TAB_ACTIVATED_TEXT_COLOR;
		} else {
			panels [index].SetActive (false);
			panels [index].GetComponent<Image> ().color = Constants.TAB_DEACTIVATED_COLOR;
			buttons [index].GetComponent<Image> ().color = Constants.TAB_DEACTIVATED_COLOR;
			buttons [index].GetComponentInChildren<Text> ().color = Constants.TAB_DEACTIVATED_TEXT_COLOR;
		}

	}


}
