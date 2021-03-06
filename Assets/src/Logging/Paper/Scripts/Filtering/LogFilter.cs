﻿using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public static class LogFilter 
{
	public static List<LogInfo> FilterLogs(List<LogInfo> logs, FilterConfig config)
	{
		IEnumerable<LogInfo> filteredLogs = logs;

		// Filter logs based off serverity 
		if (config.LogsActive == false)
			filteredLogs =filteredLogs.Where( log => log.LogLevel != LogLevel.Log);

		if (config.WarningsActive == false)
			filteredLogs = filteredLogs.Where(log => log.LogLevel != LogLevel.Warning);

		if (config.ErrorsActive == false)
			filteredLogs = filteredLogs.Where(log => log.LogLevel != LogLevel.Error);


		// Filter remaining messages based off the currently active channesl 
		filteredLogs = filteredLogs.Where(log => config.ActiveChannels.Contains(log.LogChannel));

		return filteredLogs.ToList();
	}
	




	
}
