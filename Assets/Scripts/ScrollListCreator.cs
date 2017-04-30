using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollListCreator <T>{

	private GameObject scrollPanel;
	private GameObject scrollDummyObject;
	private List<T> scrollList;
	private ScrollLister<T> lister;
	private Instantiator instantiator;
	private Transform prefab;
	private string objectName;
	private int count=0;
	private List<GameObject> items = new List<GameObject>();
	private Vector2 initialDummyPosition;

	public ScrollListCreator(GameObject scrollPanel,GameObject scrollDummyObject,Transform prefab,string objectName){
		this.scrollPanel = scrollPanel;
		this.scrollDummyObject = scrollDummyObject;
		this.prefab = prefab;
		this.objectName = objectName;
		initialDummyPosition = scrollDummyObject.transform.position;
	}

	public void listObjects(List<T> scrollList,ScrollLister<T> lister){
		foreach (T t in scrollList) {
			GameObject itemObject = addItemPart1 ();
			GameObject updatedObject = lister.setScrollItem (t,itemObject);
		}
	}

	public GameObject addItemPart1(){
		count++;
		checkInstantiator ();
		Vector2 dummyPosition = scrollDummyObject.transform.localPosition;
		Rect rect = scrollDummyObject.GetComponent<RectTransform> ().rect;
		GameObject newObject=instantiator.instantiate (prefab, dummyPosition, Quaternion.identity, scrollDummyObject.transform.parent);
		//GameObject newObject = GameObject.Find (objectName + "(Clone)");
		if (newObject == null) {
			Debug.Log ("whaat");
		}
		newObject.name = objectName + "-" + count;
		newObject.transform.localPosition = dummyPosition;
		return newObject;
	}

	public GameObject continueListing(GameObject updatedObject){
		Rect rect = updatedObject.GetComponent<RectTransform>().rect;
		Debug.Log ("new height" + rect.height);
		updatedObject.transform.localPosition = scrollDummyObject.transform.localPosition;
		scrollDummyObject.transform.localPosition -= new Vector3 (0, rect.height + 5, 0);
		RectTransform scrollRect = scrollPanel.GetComponent<RectTransform> ();
		//scrollRect.sizeDelta = new Vector2 (scrollRect.sizeDelta.x, scrollRect.sizeDelta.y+dummyHeight);
		items.Add (updatedObject);
		return updatedObject;
	}

	public void checkInstantiator(){
		if (instantiator == null) {
			instantiator = GameObject.Find ("Instantiator").GetComponent<Instantiator> ();
		}
	}

	public void resetList(){
		foreach (GameObject g in items) {
			GameObject.Destroy (g);
		}
		scrollDummyObject.transform.position = initialDummyPosition;
	}	

}
