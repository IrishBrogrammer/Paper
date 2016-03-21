using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class FilterGUI : IPaperGUI
{
	private System.Action<LogChannel, bool> onFilterChannel;

	public FilterGUI()
	{ 
	}

	public FilterGUI(System.Action<LogChannel, bool> filter)
	{
		onFilterChannel = filter;
	}

	public void DrawGUI( List<LogInfo> store , FilterConfig config  )
	{
		var activeChannels = config.ActiveChannels;
		
		List<LogChannel> disabledChannesl = new List<LogChannel>();

		foreach( LogChannel channel in System.Enum.GetValues( typeof( LogChannel)  ) )
		{
			if ( activeChannels.Contains( channel ) == false ) 
				disabledChannesl.Add( channel );
		}

		GUILayout.BeginHorizontal();
		GUILayout.Label(" Active Channels ");
		GUILayout.EndHorizontal();
		DrawListOfChannels( activeChannels.GetAll() , true);


		GUILayout.BeginHorizontal();
		GUILayout.Label(" Deactive Channels ");
		GUILayout.EndHorizontal();
		DrawListOfChannels(disabledChannesl, false );
	}

	private void DrawListOfChannels( List<LogChannel> channels , bool active  )
	{
		foreach (var channel in channels)
		{
			GUILayout.BeginHorizontal();

			if (GUILayout.Button(channel.ToString()))
				onFilterChannel(channel, !active);

			GUILayout.EndHorizontal();
		}
	}

	public void OnClear()
	{ 
	}

}
