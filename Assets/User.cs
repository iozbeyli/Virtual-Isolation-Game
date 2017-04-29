using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {

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
		
	public User(){
	
	}

}
