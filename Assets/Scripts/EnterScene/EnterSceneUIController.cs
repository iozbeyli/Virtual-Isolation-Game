using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSceneUIController{

	private static GameObject UIControllers;

	public static AuthenticationUIController AuthenticationUIController{
		get{ 
			checkUIControllers ();
			return UIControllers.GetComponent<AuthenticationUIController> ();
		}
	}

	public static HubUIController HubUIController{
		get{ 
			checkUIControllers ();
			return UIControllers.GetComponent<HubUIController> ();
		}
	}

	public static HubControlUIController HubControlUIController{
		get{ 
			checkUIControllers ();
			return UIControllers.GetComponent<HubControlUIController> ();
		}
	}

	public static HubRoomUIController HubRoomUIController{
		get{ 
			checkUIControllers ();
			return UIControllers.GetComponent<HubRoomUIController> ();
		}
	}

	public static HubEquipmentUIController HubEquipmentUIController{
		get{ 
			checkUIControllers ();
			return UIControllers.GetComponent<HubEquipmentUIController> ();
		}
	}


	private static void checkUIControllers(){
		if (UIControllers == null) {
			UIControllers = GameObject.Find ("UIControllers");
		}

	}
}
