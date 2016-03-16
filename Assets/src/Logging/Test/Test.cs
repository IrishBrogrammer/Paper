using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	public TextAsset testConfiguration;


	void Awake()
	{
		var test = fastJSON.JSON.ToObject<LogConfiguration>( testConfiguration.text );

		if ( test != null )
			Debug.Log( " not null" );

		LoggingManager.SetConfig( test );
	}


	void Update()
	{
		if( Input.GetKeyDown( KeyCode.T ) )
			LoggingManager.Log( LogChannel.UI, " Button PRess" );

		if( Input.GetKeyDown( KeyCode.U ) )
			LoggingManager.Log( LogChannel.AssetDatabase, "PRessed U " );

		if( Input.GetKeyDown( KeyCode.E ) )
			LoggingManager.LogWarning( LogChannel.BuildChecks, " Warning : dll not loaded ");

		if ( Input.GetKeyDown( KeyCode.R ) )
			LoggingManager.LogError( LogChannel.Core, " Loader is null " );
	}


}
