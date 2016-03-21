using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class FilterGUI : IPaperGUI
{

	public void DrawGUI( List<LogInfo> store  )
	{
		var activeChannels = LoggingManager.GetActiveChannels();
		
		List<LogChannel> disabledChannesl = new List<LogChannel>();

		foreach( LogChannel channel in System.Enum.GetValues( typeof( LogChannel)  ) )
		{
			if ( activeChannels.Contains( channel ) == false ) 
				disabledChannesl.Add( channel );
		}

		GUILayout.BeginHorizontal();
		GUILayout.Label(" Active Channels ");
		GUILayout.EndHorizontal();
		DrawListOfChannels( activeChannels.GetAll() , null);


		GUILayout.BeginHorizontal();
		GUILayout.Label(" Deactive Channels ");
		GUILayout.EndHorizontal();
		DrawListOfChannels(disabledChannesl, null);
	}

	private void DrawListOfChannels( List<LogChannel> channels , System.Action onPress )
	{
		foreach (var channel in channels)
		{
			GUILayout.BeginHorizontal();

			if ( GUILayout.Button( channel.ToString() ) )
				onPress();

			GUILayout.EndHorizontal();
		}
	}

	public void OnClear()
	{ 
	}

}
