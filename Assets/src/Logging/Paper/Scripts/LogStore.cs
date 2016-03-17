using UnityEngine;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

// Class to store logs
public static class LogStore 
{
	public static EditorLogStore store;

	public static void SetStore(EditorLogStore editorStore)
	{
		store = editorStore;
	}

	public static EditorLogStore GetLogStore()
	{
		return store;
	}

	public static void AddLog( LogChannel channel ,  string message , LogLevel level )
	{
		var log = new LogInfo(
			channel,
			message,
			GetCallStack(),
			level
			);

		if (store != null)
			store.AddLog( log );
	}

	public static void ClearStore()
	{
		store.ClearLogs();
	}


	static List<LogStackFrame> GetCallStack()
	{
		List<LogStackFrame> callStack = new List<LogStackFrame>();

		StackTrace stackTrace = new StackTrace(true);
		StackFrame[] stackFrames = stackTrace.GetFrames();

		foreach (StackFrame frame in stackFrames)
		{
			LogStackFrame logFrame = new LogStackFrame(frame);
			callStack.Add(logFrame);
		}


		return callStack;
	}
}


[System.Serializable]
public class EditorLogStore : ScriptableObject
{
	public List<LogInfo> Logs = new List<LogInfo>();
	public int LogCount = 0;
	public int WarningCount = 0;
	public int ErrorCount = 0;

	static public EditorLogStore Create()
	{
		var editorDebug = ScriptableObject.FindObjectOfType<EditorLogStore>();

		if (editorDebug == null)
		{
			editorDebug = ScriptableObject.CreateInstance<EditorLogStore>();
		}
		return editorDebug;	
	}

	public void OnEnable()
	{
		hideFlags = HideFlags.HideAndDontSave;
	}

	public void AddLog( LogInfo message )
	{
		UpdateCount( message.LogLevel );
		Logs.Add( message );
	}

	public void ClearLogs()
	{
		ResetCounts();
		Logs.Clear();
	}
	
	private void UpdateCount( LogLevel level )
	{
		switch (level)
		{
			case ( LogLevel.Log ):
				LogCount++;
				break;

			case ( LogLevel.Warning ):
				WarningCount++;
				break;

			case ( LogLevel.Error ):
				ErrorCount++;
				break;
		}
	}

	private void ResetCounts()
	{
		LogCount = 0;
		WarningCount = 0;
		ErrorCount = 0;
	}
}
