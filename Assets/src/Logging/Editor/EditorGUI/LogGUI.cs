using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class LogGUI : IPaperGUI
{
	private Vector2 scrollViewPos = Vector2.zero;
	private Vector2 stackViewPos  = Vector2.zero;

	private LogInfo selectedLog = null;

	public void DrawGUI( List<LogInfo>  store )
	{
		var logs = store;

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

		GUIStyle testStyle = EditorStyles.label;

		string displayText = log.LogChannel.ToString() + " : " + log.Message;

		var displayStyle = EditorStyles.label;
		GUILayout.EndHorizontal();
	
		if (GUILayout.Button(displayText, EditorStyles.label))
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
