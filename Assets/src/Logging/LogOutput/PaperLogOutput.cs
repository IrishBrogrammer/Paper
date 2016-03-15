using UnityEngine;
using System.Collections;

public class PaperLogOutput : ILogOutput
{
	public void LogMessage( LogChannel channel, string message )
	{
		LogStore.AddLog( channel , message , LogLevel.Log );
	}

	public void LogWarning( LogChannel channel, string logWarning )
	{
		LogStore.AddLog( channel , logWarning , LogLevel.Warning  );
	}

	public void LogError( LogChannel channel, string logError )
	{
		LogStore.AddLog( channel , logError , LogLevel.Error );
	}
}
