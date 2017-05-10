using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneUIController{

	private static GameObject UIControllers;

	public static TaskUIController TaskUIController{
		get{ 
			checkUIControllers ();
			return UIControllers.GetComponent<TaskUIController> ();
		}
	}

	public static ChoreUIController ChoreUIController{
		get{ 
			checkUIControllers ();
			return UIControllers.GetComponent<ChoreUIController> ();
		}
	}

	private static void checkUIControllers(){
		if (UIControllers == null) {
			UIControllers = GameObject.Find ("UIControllers");
		}

	}

}
