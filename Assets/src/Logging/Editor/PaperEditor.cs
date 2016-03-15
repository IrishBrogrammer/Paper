﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class PaperEditor : EditorWindow
{
	private enum EditorTab
	{ 
		Console,
		Filter
	}

	private Dictionary<EditorTab, IPaperGUI> tabGGUI = new Dictionary<EditorTab, IPaperGUI>()
	{
		{ EditorTab.Filter , new FilterGUI() },
		{ EditorTab.Console , new LogGUI() } 
	};
	EditorTab currentTab = EditorTab.Console;

	private static PaperActionBar actionBar = new PaperActionBar();

	private static bool clearOnPlay = false;

	[UnityEngine.SerializeField]
	private static EditorLogStore editorstore;

	private Vector2 ScrollPos;

	IPaperGUI currentGUI = new FilterGUI();

	[MenuItem("Paper/Show Console")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(PaperEditor));
	}

	public void Init()
	{
		var window = ScriptableObject.CreateInstance<PaperEditor>();
		window.Show();
		window.position = new Rect(200, 200, 400, 300);
	}



	void OnEnable()
	{
		if (editorstore == null)
		{
			editorstore = EditorLogStore.Create();
		}

		if (LogStore.GetLogStore() == null)
		{
			Debug.Log(" Editor store has gone null; ");
			Debug.Log(" Setting store with " + editorstore.Logs.Count);
			LogStore.SetStore(editorstore);
		}
	}

	void OnInspectorUpdate()
	{
		Repaint();
	}

	void OnGUI()
	{
		actionBar.DrawActionBar();
		DrawTabs();
		DrawMain();
	}

	void DrawTabs()
	{	
		GUILayout.BeginHorizontal();
		foreach( EditorTab tab in System.Enum.GetValues( typeof( EditorTab ) ) )
		{
			DrawTab( tab );	
		}	
		GUILayout.EndHorizontal();
	}

	void DrawTab(EditorTab tab)
	{
		if ( GUILayout.Button( tab.ToString() )  )
			currentTab = tab;
	}

	void DrawMain()
	{
		IPaperGUI currentGUI = tabGGUI[currentTab];

		foreach (var log in editorstore.Logs)
			OutputMessage(log);

	//	currentGUI.DrawGUI( editorstore );
	}

	private void OutputMessage( LogInfo log)
	{
		GUILayout.BeginHorizontal();

		GUILayout.Label(log.LogChannel.ToString());

		GUILayout.Box(log.Message);

		GUILayout.EndHorizontal();
	}


}
