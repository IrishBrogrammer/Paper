using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	public TextAsset testConfiguration;


	void Awake()
	{
	//	LoggingManager.Log(LogChannel.UI, " Start test  ");

		var test = fastJSON.JSON.ToObject<LogConfiguration>(testConfiguration.text);

		if (test != null)
			Debug.Log(" not null");

		LoggingManager.SetConfig(test);
	
	}

	void Start () 
	{
		//LoggingManager.Log(LogChannel.UI, " Log message ");
	//	LoggingManager.Log(LogChannel.UI, " Working ");

	}



	void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			LoggingManager.Log(LogChannel.UI, " Button PRess");
		}

		if (Input.GetKeyDown(KeyCode.U))
		{
			LoggingManager.Log(LogChannel.AssetDatabase, "PRessed U ");
		}


	}


}
