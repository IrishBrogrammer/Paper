using UnityEngine;
using UnityEditor;
using System.Collections;

public class PaperActionBar 
{

	bool clearOnPlay = false;

	public void DrawActionBar( EditorLogStore store , ref FilterConfig filterConfig  )
	{
		GUILayout.BeginHorizontal();

		filterConfig.LogsActive = DrawToggle(filterConfig.LogsActive, " Logs " + " : " + store.LogCount, EditorStyles.toolbarButton);
		filterConfig.WarningsActive = DrawToggle(filterConfig.WarningsActive , " Warnings " + " : " + store.WarningCount, EditorStyles.toolbarButton);
		filterConfig.ErrorsActive = DrawToggle(filterConfig.ErrorsActive, " Errors " + " : " + store.ErrorCount, EditorStyles.toolbarButton);
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
			clearOnPlay = !clearOnPlay;
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
