﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Store the configuration for filtering the logs
public class FilterConfig
{
	public bool LogsActive = true;
	public bool WarningsActive = true;
	public bool ErrorsActive = true;

	public HashStore<LogChannel> ActiveChannels = new HashStore<LogChannel>();
}
