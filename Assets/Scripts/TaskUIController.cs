using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskUIController : MonoBehaviour,ScrollLister<Task> {

	public GameObject dummyTaskObject;
	public Transform taskPrefab;
	public GameObject taskScrollPanel;
	public ScrollListCreator<Task> taskScrollListCreator;

	public void listTask(List<Task> tasks){
		checkTaskScrollListCreator ();
		taskScrollListCreator.resetList ();
		taskScrollListCreator.listObjects (tasks, this);
	}

	public GameObject setScrollItem(Task item, GameObject itemObject){
		Text[] texts = itemObject.GetComponentsInChildren<Text> ();
		texts [0].text = item.Title;
		Debug.Log ("item username id" + item.Title);
		taskScrollListCreator.continueListing (itemObject);
		return itemObject;
	}

	public void checkTaskScrollListCreator(){
		if (taskScrollListCreator == null) {
			taskScrollListCreator = new ScrollListCreator<Task> (taskScrollPanel,dummyTaskObject,taskPrefab,"Task");
		}
	}

}
