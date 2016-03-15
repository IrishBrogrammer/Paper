using UnityEngine;
using System.Collections;

// Inteface for output logging method.Where to file/PaperLog/Unity 
public interface ILogOutput 
{
	void LogMessage( LogChannel channel , string message );
	
	void LogWarning( LogChannel channel, string logWarning);
	
	void LogError(  LogChannel channel  , string logError);
}



public enum LogOutputter
{ 
	UnityLog,
	PaperLog,
	FileLog
}

public static class LogOutputFactory
{ 
	public static ILogOutput CreateLogoutput( LogOutputter outputType ) 
	{
		switch (outputType)
		{ 
			case LogOutputter.UnityLog :
				return new UnityLogOutput();
			
			case LogOutputter.PaperLog :
				return new PaperLogOutput();		
		}

		return new UnityLogOutput();
	}
}
