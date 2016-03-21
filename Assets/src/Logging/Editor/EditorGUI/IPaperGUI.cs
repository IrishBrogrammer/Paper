﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IPaperGUI 
{
	void DrawGUI( List<LogInfo> logStore );
	
	void OnClear();

}
