﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public static class LoggingManager  
{
	private static ILogOutput logWritter = new PaperLogOutput();
	private static ActiveChannelStore activeChannels = new ActiveChannelStore();

	static LoggingManager()
	{
		Application.logMessageReceived += UnityLogHandler;
	}

	static void UnityLogHandler( string logString , string strackTrace ,  UnityEngine.LogType logType ) 
	{
		UnityEngine.Debug.Log( " Brian getting called " + logString  );
	}
	
	public static HashStore<LogChannel> GetActiveChannels()
	{
		return activeChannels.GetStore();
	}

	public static void SetConfig(LogConfiguration config)
	{
		logWritter = LogOutputFactory.CreateLogoutput(config.OutputInterface);
		activeChannels.Clear();
		activeChannels.AddChannels(config.ActiveLogChannels);
	}

	public static void ActivateLogChannel(LogChannel newChannel)
	{
		activeChannels.AddChannel(newChannel);
	}

	public static void DeActivateChannel(LogChannel channel)
	{
		activeChannels.RemoveChannel(channel);
	}


	[StackTraceIgnore]
	public static void Log( LogChannel logChannel, string message)
	{
		logWritter.LogMessage( logChannel , message );
	}

	[StackTraceIgnore]
	public static void LogIf(bool shouldLog, LogChannel logChannel, string message)
	{
		if ( shouldLog )
			Log( logChannel, message );
	}

	[StackTraceIgnore]
	public static void LogIf(Func<bool> testMethod, LogChannel logChannel, string message)
	{
		if ( testMethod() )
			Log( logChannel , message );
	}

	[StackTraceIgnore]
	public static void LogWarning(LogChannel logChannel, string message)
	{
		logWritter.LogWarning( logChannel , message);
	}


	[StackTraceIgnore]
	public static void LogError( LogChannel logChannel , string message )
 	{
		logWritter.LogError( logChannel , message );
	}

}
