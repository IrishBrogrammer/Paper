using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class LogGUI : IPaperGUI
{
	private Vector2 scrollViewPos = Vector2.zero;
	private Vector2 stackViewPos  = Vector2.zero;

	private LogInfo selectedLog = null;

	public void DrawGUI( List<LogInfo>  store , FilterConfig config )
	{
		var filteredLogs = LogFilter.FilterLogs( store, config );
		var logs = filteredLogs;

		scrollViewPos = GUILayout.BeginScrollView( scrollViewPos );

		foreach (var log in logs)
		{
			DrawLog(log);	
		}
		GUILayout.EndScrollView();
	
		if (selectedLog != null && logs.Count != 0)
		{
			DrawDetailedLog( selectedLog );
		}
	}

	private void DrawLog( LogInfo log  )
	{
		GUILayout.BeginHorizontal();

		string displayText = log.LogChannel.ToString() + " : " + log.Message;
		GUILayout.EndHorizontal();
	
		if (GUILayout.Button(displayText, EditorStyles.whiteLabel))
			selectedLog = log;
	}

	private void DrawDetailedLog(LogInfo log)
	{
		var stackFrame = log.StackFrame;

		stackViewPos = GUILayout.BeginScrollView( stackViewPos );

		foreach (var frame in stackFrame)
		{
			GUILayout.BeginHorizontal();

			GUILayout.Label( frame.ToString() );

			GUILayout.EndHorizontal();
		}

		GUILayout.EndScrollView();
	}

	public void OnClear()
	{
		selectedLog = null; 
	}


}
