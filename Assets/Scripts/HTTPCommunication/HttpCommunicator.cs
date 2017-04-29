using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HTTPCommunicator{

	void successfulExecution (JSONObject data);
	void failedExecution(string error);

}
