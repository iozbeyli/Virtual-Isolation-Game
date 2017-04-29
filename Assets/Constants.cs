using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants{
	public static Color TAB_ACTIVATED_COLOR 		= new Color(216f/255f,101f/255f,0f			);
	public static Color TAB_DEACTIVATED_COLOR 		= new Color(248f/255f,248f/255f,248f/255f	);
	public static Color TAB_ACTIVATED_TEXT_COLOR 	= new Color(255f/255f,255f/255f,255f/255f	);
	public static Color TAB_DEACTIVATED_TEXT_COLOR 	= new Color(216f/255f,101f/255f,0f			);

	public static string API_IP = "172.20.104.172";
	public static string API_PORT = "5567";
	public static string API_URL ="http://"+API_IP+":"+API_PORT+"/api";
	public static string SOCKET_URL = API_IP+":"+API_PORT;
	public static string LOGIN_API_URL = API_URL + "/login";
	public static string HUB_API_URL = API_URL + "/hub";
	public static string CREATE_HUB_API_URL = HUB_API_URL+"/create";
	public static string GET_HUB_LIST_API_URL = HUB_API_URL;

	public static string HUB_JOIN_CHANNEL = "hub:join";

}
