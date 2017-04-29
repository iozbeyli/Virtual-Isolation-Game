using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUser{

	public string ID{
		get{
			return user.ID;
		}
		set{ 
			user.ID = value;
		}
	}

	public string Username{
		get{ 
			return user.Username;
		}
		set{ 
			user.Username = value;
		}
	}

	public User user;


	private static MainUser instance=null;
	public static MainUser getInstance (){
		if (instance == null) {
			instance = new MainUser ();
		}
		return instance;
	}
	public MainUser(){
		user = new User ();
	}



}
