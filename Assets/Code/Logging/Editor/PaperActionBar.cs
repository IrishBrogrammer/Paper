using UnityEngine;
using System.Collections;

public class PaperActionBar 
{
	public void DrawActionBar()
	{
		GUILayout.BeginHorizontal();

		DrawButton("\u0066 Clear", OnClear);
		DrawToggle("ClearOnPlay", OnClearOnPlay);

		GUILayout.EndHorizontal();
	}

	public void DrawButton(string buttonName, System.Action onPress)
	{ 
		if ( GUILayout.Button( buttonName ) )
			onPress();
	}

	bool clearOnPlay = false;
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


	public void OnClear()
	{
		LogStore.ClearStore();
	}

	public void OnClearOnPlay()
	{
		Debug.Log(" GOrt on pres " + clearOnPlay);
	}


}
