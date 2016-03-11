using UnityEngine;
using System.Collections;

public class UnityLogOutput : ILogOutput 
{
	public void LogMessage( LogChannel channel, string message )
	{
		Debug.Log(" Getting into unuty lot ");
		Debug.Log( message );
	}

	public void LogWarning( LogChannel channel, string message )
	{
		Debug.LogWarning( message );
	}

	public void LogError( LogChannel channel, string message)
	{
		Debug.LogError( message );
	}

}
