using UnityEngine;
using System.Collections;

public class PaperLogOutput : ILogOutput
{

	[StackTraceIgnore]
	public void LogMessage( LogChannel channel, string message )
	{
		LogStore.AddLog( channel , message , LogLevel.Log );
	}

	[StackTraceIgnore]
	public void LogWarning( LogChannel channel, string logWarning )
	{
		LogStore.AddLog( channel , logWarning , LogLevel.Warning  );
	}

	[StackTraceIgnore]
	public void LogError( LogChannel channel, string logError )
	{
		LogStore.AddLog( channel , logError , LogLevel.Error );
	}
}
