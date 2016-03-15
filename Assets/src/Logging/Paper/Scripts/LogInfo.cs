using UnityEngine;
using System.Collections;


public enum LogLevel
{
	Log,
	Warning,
	Error
}



public class LogInfo 
{
	public LogInfo()
	{ 
	}

	public LogInfo( LogChannel channel , string msg , LogLevel level  ) 
	{
		LogChannel = channel;
		Message = msg;
		LogLevel = level;
	}

	public LogChannel LogChannel;
	public string Message;
	public Time TimeStamp;
	public LogLevel LogLevel;

}
