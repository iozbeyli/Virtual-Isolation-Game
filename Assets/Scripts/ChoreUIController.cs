using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoreUIController : MonoBehaviour,ScrollLister<Task> {

	public GameObject dummyChoreObject;
	public Transform chorePrefab;
	public GameObject choreScrollPanel;
	public ScrollListCreator<Task> choreScrollListCreator;

	public GameObject setScrollItem(Task item, GameObject itemObject){
		Text[] texts = itemObject.GetComponentsInChildren<Text> ();
		texts [0].text = item.Title;

		choreScrollListCreator.continueListing (itemObject);
		return itemObject;
	}

	public void listChore(List<Task> chores){
		checkChoreScrollListCreator ();
		choreScrollListCreator.resetList ();
		choreScrollListCreator.listObjects (chores, this);
	}

	public void checkChoreScrollListCreator(){
		if (choreScrollListCreator == null) {
			choreScrollListCreator = new ScrollListCreator<Task> (choreScrollPanel,dummyChoreObject,chorePrefab,"Chore");
		}
	}
}
