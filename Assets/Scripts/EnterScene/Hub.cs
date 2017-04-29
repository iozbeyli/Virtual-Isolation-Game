using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub{

	private string label;
	public string Label{
		get{
			return label;
		}
		set{ 
			label = value;
		}
	}
	private bool started;
	public bool Started{
		get{ 
			return started;
		}
		set{ 
			started = value;
		}
	}
	private string date;
	public string Date{
		get{ 
			return date;
		}
		set{ 
			date = value;
		}
	}
	private string id;
	public string ID{
		get{ 
			return id;
		}
		set{ 
			id = value;
		}
	}
	private List<string> rooms;
	public List<string> Rooms{
		get{ 
			return rooms;
		}
		set{ 
			rooms = value;
		}
	}
	private List<string> members;
	public List<string> Members{
		get{ 
			return members;
		}
		set{ 
			members = value;
		}
	}

	public Hub(string label){
		this.label = label;
	}
}
