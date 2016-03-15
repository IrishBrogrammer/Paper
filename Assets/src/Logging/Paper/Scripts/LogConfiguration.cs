using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LogConfiguration
{
	public LogOutputter OutputInterface;
	
	// Log settings
	public List<LogChannel> ActiveLogChannels;
	public List<LogGroup> ActiveLogGroups;

}
