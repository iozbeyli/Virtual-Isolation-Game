using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatMessage{

	private User sender;
	public User Sender{
		get{ 
			return sender;
		}
		set{ 
			sender = value;
		}
	}

	private string content;
	public string Content{
		get{ 
			return content;
		}
		set{ 
			content = value;
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

	public ChatMessage(){
		
	}
}
