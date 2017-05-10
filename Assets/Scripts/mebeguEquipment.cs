using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mebeguEquipment {
	
	private string id;
	public string ID{
		get{ 
			return id;
		}
		set{ 
			id = value;
		}
	}
	private string label;
	public string Label{
		get{ 
			return label;
		}
		set{ 
			label = value;
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


	public mebeguEquipment(){}
}
