using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class FilterGUI : IPaperGUI
{

	public void DrawGUI( EditorLogStore store )
	{ 
		foreach( var channel in System.Enum.GetValues(typeof( LogChannel) ) )
		{
			GUILayout.BeginHorizontal();

			if ( GUILayout.Button( channel.ToString() ) )
				Debug.Log( " got button press" );

			GUILayout.EndHorizontal();
		}
	}
}
