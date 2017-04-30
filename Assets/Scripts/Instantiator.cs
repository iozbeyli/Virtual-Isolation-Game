using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {


	public GameObject instantiate(Transform prefab,Vector2 position,Quaternion rotation,Transform parent){
		Transform t=Instantiate<Transform> (prefab, position, Quaternion.identity, parent);
		return t.gameObject;
	}
}
