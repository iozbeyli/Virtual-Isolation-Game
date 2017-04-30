using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HubEquipmentUIController : MonoBehaviour, ScrollLister<Equipment> {
	public GameObject dummyEquipmentObject;
	public Transform equipmentPrefab;
	public GameObject equipmentScrollPanel;
	public ScrollListCreator<Equipment> equipmentScrollListCreator;
	public GameObject hubEquipmentPanel;

	public void listEquipment(List<Equipment> equipments){
		checkEquipmentScrollListCreator ();
		equipmentScrollListCreator.resetList ();
		equipmentScrollListCreator.listObjects (equipments, this);
	}

	public GameObject setScrollItem(Equipment item, GameObject itemObject){
		Text[] texts = itemObject.GetComponentsInChildren<Text> ();
		texts [0].text = item.label;
		//Debug.Log ("item username id" + item.Username);
		equipmentScrollListCreator.continueListing (itemObject);
		Button button = itemObject.GetComponent<Button> ();
		//Button[] button = itemObject.GetComponentsInChildren<Button> ();
		UnityAction action = () => {
			HubEquipmentController.getInstance().addEquipment(item);
		};
		button.onClick.AddListener (action);
		return itemObject;
	}

	public void checkEquipmentScrollListCreator(){
		if (equipmentScrollListCreator == null) {
			equipmentScrollListCreator = new ScrollListCreator<Equipment> (equipmentScrollPanel,dummyEquipmentObject,equipmentPrefab,"Equipment");
		}
	}

	public void openCloseEquipmentPanel(){
		hubEquipmentPanel.SetActive (!hubEquipmentPanel.activeInHierarchy);
	}
}
