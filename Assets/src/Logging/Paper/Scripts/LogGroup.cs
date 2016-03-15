using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class LogGroup
{
	public string Name;
	public List<LogChannel> Channels = new List<LogChannel>();
}
