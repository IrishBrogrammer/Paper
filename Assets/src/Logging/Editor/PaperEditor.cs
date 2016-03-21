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

	IPaperGUI currentGUI = new FilterGUI();
	
	private Dictionary<EditorTab, IPaperGUI> tabGGUI = new Dictionary<EditorTab, IPaperGUI>()
	{
		{ EditorTab.Filter , new FilterGUI( UpdateFilterConfig ) },
		{ EditorTab.Console , new LogGUI() } 
	};

	EditorTab currentTab = EditorTab.Console;

	private static PaperActionBar actionBar = new PaperActionBar();
	private  static FilterConfig filteringConfig = new FilterConfig();

	private static bool clearOnPlay = false;

	[UnityEngine.SerializeField]
	private static EditorLogStore editorstore;


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
			editorstore = EditorLogStore.Create();
	
		if (LogStore.GetLogStore() == null)
			LogStore.SetStore(editorstore);
	}

	void OnInspectorUpdate()
	{
		Repaint();
	}

	static void UpdateFilterConfig(LogChannel channel, bool active)
	{
		if (active)
			filteringConfig.ActiveChannels.Add(channel);
		else
			filteringConfig.ActiveChannels.Remove(channel);
	}


	void OnGUI()
	{
		actionBar.DrawActionBar( editorstore , ref filteringConfig );
		DrawTabs();
		DrawMain();
	}

	void DrawTabs()
	{	
		GUILayout.BeginHorizontal();
		
		foreach( EditorTab tab in System.Enum.GetValues( typeof( EditorTab ) ) )
			DrawTab( tab );	
		
		GUILayout.EndHorizontal();
	}

	void DrawTab(EditorTab tab)
	{
		if ( GUILayout.Button( tab.ToString() )  )
			currentTab = tab;
	}

	void DrawMain()
	{
		return;
		IPaperGUI currentGUI = tabGGUI[currentTab];
		currentGUI.DrawGUI( editorstore.Logs , filteringConfig );
	}

}
