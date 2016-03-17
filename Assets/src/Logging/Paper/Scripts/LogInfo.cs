using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum LogLevel
{
	Log,
	Warning,
	Error
}


// Class that contains all the information relevant for a log 
public class LogInfo 
{
	public List<LogStackFrame> StackFrame;
	public LogChannel LogChannel;
	public LogLevel LogLevel;
	public string Message;
	public Time TimeStamp;
	
	public LogInfo()
	{ 
	}

	public LogInfo( LogChannel channel , string msg , List<LogStackFrame> frame ,  LogLevel level  ) 
	{
		LogChannel = channel;
		Message = msg;
		LogLevel = level;
		StackFrame = frame;
	}
}
