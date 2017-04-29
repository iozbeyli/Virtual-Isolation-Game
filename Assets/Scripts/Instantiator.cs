using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {


	public void instantiate(Transform prefab,Vector2 position,Quaternion rotation,Transform parent){
		Instantiate (prefab, position, Quaternion.identity, parent);
	}
}
