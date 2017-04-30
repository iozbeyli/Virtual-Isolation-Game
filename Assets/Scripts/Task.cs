using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task{
	private string id;
	public string ID{
		get{ 
			return id;
		}
		set{ 
			id = value;
		}
	}
	private string title;
	public string Title{
		get{ 
			return title;
		}
		set{ 
			title = value;
		}
	}

	private string description;
	public string Description{
		get{ 
			return description;
		}
		set{ 
			description = value;
		}
	}

	private int deadline;
	public int Deadline{
		get{ 
			return deadline;
		}
		set{ 
			deadline = value;
		}
	}

	private int duration;
	public int Duration{
		get{ 
			return duration;
		}
		set{ 
			duration = value;
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

	private string equipment;


	public Task(){}

}
