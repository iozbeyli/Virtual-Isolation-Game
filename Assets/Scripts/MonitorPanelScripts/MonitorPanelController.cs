using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorPanelController{

	private static MonitorPanelUIController monitorPanelUIController=null;
	public static int TASK=0;
	public static int CHORE = 1;
	public static int MAINTENANCE = 2;
	public static int currentTab = TASK;

	public static void checkMonitorPanelUIController(){
		if (monitorPanelUIController == null) {
			monitorPanelUIController=GameObject.Find ("UIControllers").GetComponent<MonitorPanelUIController> ();
		}
	}

	public static void activateTaskPanel(){
		checkMonitorPanelUIController ();
		monitorPanelUIController.activateTaskPanel ();
		currentTab = TASK;
	}

	public static void activateChorePanel(){
		checkMonitorPanelUIController ();
		monitorPanelUIController.activateChorePanel ();
		currentTab = CHORE;
	}

	public static void activateMaintenancePanel(){
		checkMonitorPanelUIController ();
		monitorPanelUIController.activateMaintenancePanel ();
		currentTab = MAINTENANCE;
	}

}
