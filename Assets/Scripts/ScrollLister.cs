using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ScrollLister<T>{

	GameObject setScrollItem (T item, GameObject itemObject);

}
