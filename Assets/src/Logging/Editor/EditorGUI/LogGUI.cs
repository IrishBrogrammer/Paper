using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class LogGUI : IPaperGUI
{
	public void DrawGUI( EditorLogStore  store )
	{
		var logs = store.Logs;

		foreach (var log in logs)
		{
			DrawLog(log);	
		}
	}

	private void DrawLog( LogInfo log  )
	{
		GUILayout.BeginHorizontal();

		GUIStyle testStyle = EditorStyles.label;
	
		GUILayout.Label(log.LogChannel.ToString() , testStyle ) ;
		GUILayout.Label(log.Message);

		GUILayout.EndHorizontal();
	}

}
