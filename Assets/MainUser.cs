using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUser{

	private string id="";
	public string ID{
		get{
			return id;
		}
		set{ 
			id = value;
		}
	}

	private string username="";
	public string Username{
		get{ 
			return username;
		}
		set{ 
			username = value;
		}
	}

	private static MainUser instance=null;
	public static MainUser getInstance (){
		if (instance == null) {
			instance = new MainUser ();
		}
		return instance;
	}
	public MainUser(){
	}



}
