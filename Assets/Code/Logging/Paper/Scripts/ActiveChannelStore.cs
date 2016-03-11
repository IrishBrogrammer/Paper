using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActiveChannelStore 
{
	private HashStore<LogChannel> store = new HashStore<LogChannel>();

	public void AddChannel(LogChannel channel)
	{
		store.Add( channel );
	}

	public void AddChannels(List<LogChannel> channels)
	{
		foreach (var channel in channels)
		{
			AddChannel(channel);
		}
	}

	public void RemoveChannel(LogChannel channel)
	{
		store.Remove(channel);
	}

	public void RemoveChannes(List<LogChannel> channels)
	{
		foreach (var channel in channels)
		{
			RemoveChannel(channel);
		}
	}

	public void AddLogGroup(LogGroup group)
	{
		foreach (var channel in group.Channels)
		{
			AddChannel(channel);
		}
	}

	public void AddLogGroups(List<LogGroup> groups)
	{
		foreach (var group in groups)
			AddLogGroup(group);
	}

	public bool Contains(LogChannel channel)
	{
		return store.Contains(channel);
	}

	public void Clear()
	{
		store.Clear();
	}

}
