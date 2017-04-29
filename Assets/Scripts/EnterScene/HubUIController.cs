using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class HubUIController : MonoBehaviour,ScrollLister<Hub> {

	public GameObject hubPanel;

	public GameObject hubListPanel;
	public GameObject hubListScrollPanel;
	public GameObject dummyHubObject;
	public Transform hubPrefab;
	public ScrollListCreator<Hub> scrollListCreator;

	public GameObject hubCreatePanel;
	public InputField hubCreationNameInputField;

	public GameObject hubControlPanel;


	public void createHub(){
		string hubName = hubCreationNameInputField.text;
		HubCreationController.getInstance().createHub (hubName);
	}

	public void getHubList(){
		HubListController.getInstance ().getHubList ();
	}

	public void openCloseHubPanel(){
		hubPanel.SetActive (!hubPanel.activeInHierarchy);
	}

	public void openCloseHubCreatePanel(){
		hubCreatePanel.SetActive (!hubCreatePanel.activeInHierarchy);
	}

	public void openCloseHubListPanel(){
		hubListPanel.SetActive (!hubListPanel.activeInHierarchy);
	}

	public void listHubs(List<Hub> hubs){
		checkScrollListCreator ();
		scrollListCreator.resetList ();
		scrollListCreator.listObjects (hubs, this);
	}

	public GameObject setScrollItem(Hub item, GameObject itemObject){
		Text[] texts = itemObject.GetComponentsInChildren<Text> ();
		texts [0].text = item.Label;
		Button button = itemObject.GetComponentInChildren<Button> ();
		UnityAction action = () => {
			HubListController.getInstance().joinHub (item);
		};
		button.onClick.AddListener(action);
		return itemObject;
	}

	public void checkScrollListCreator(){
		if (scrollListCreator == null) {
			scrollListCreator = new ScrollListCreator<Hub> (hubListScrollPanel,dummyHubObject,hubPrefab,"Hub");
		}
	}

	public void openCloseHubControlPanel(){
		openCloseHubListPanel ();
		hubControlPanel.SetActive (!hubControlPanel.activeInHierarchy);
	}


}
