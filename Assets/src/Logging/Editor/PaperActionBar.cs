using UnityEngine;
using UnityEditor;
using System.Collections;

public class PaperActionBar 
{
	bool showLogs = false;
	bool showWarnings = false;
	bool showErrors = false;
	bool clearOnPlay = false;

	public void DrawActionBar( EditorLogStore store )
	{
		GUILayout.BeginHorizontal();

		showLogs = DrawToggle(showLogs, " Logs " + " : " + store.LogCount, EditorStyles.toolbarButton);
		showWarnings = DrawToggle(showWarnings, " Warnings " + " : " + store.WarningCount, EditorStyles.toolbarButton);
		showErrors = DrawToggle(showErrors, " Errors " + " : " + store.ErrorCount, EditorStyles.toolbarButton);
		DrawButton(" Clear", OnClear);
		clearOnPlay = DrawToggle(clearOnPlay, " Clear on play ", EditorStyles.toolbarButton);

		
		//DrawToggle("ClearOnPlay", OnClearOnPlay);

		GUILayout.EndHorizontal();
	}

	public void DrawButton(string buttonName, System.Action onPress)
	{ 
		if ( GUILayout.Button( buttonName , EditorStyles.toolbarButton ) )
			onPress();
	}

	public void DrawToggle(string buttonName, System.Action onPress)
	{
		if (GUILayout.Toggle( clearOnPlay , buttonName))
		{
			Debug.Log(" Clear on play " + clearOnPlay);
			clearOnPlay = !clearOnPlay;
			Debug.Log(" Clear on play changes " + clearOnPlay);
			onPress();
		}
		
	}

	public bool DrawToggle( bool active , string label , GUIStyle style )
	{
		return GUILayout.Toggle(active, label  , style);
	}


	public void OnClear()
	{
		LogStore.ClearStore();
	}

	public void OnClearOnPlay()
	{
		Debug.Log(" GOrt on pres " + clearOnPlay);
	}


}
