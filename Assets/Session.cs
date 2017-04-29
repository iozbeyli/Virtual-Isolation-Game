using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Session{

	public string currentRoom;
	public string currentHub;

	private string token;
	public string Token{
		get{ 
			return token;
		}
		set{ 
			Debug.Log (value);
			token = value;
		}
	}

	private static Session instance=null;
	public static Session getInstance(){
		if (instance == null) {
			instance = new Session ();
		}
		return instance;
	}
	private Session(){
	}

}
