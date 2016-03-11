using UnityEngine;
using System.IO;
using System.Collections;

public class FileStore 
{
	private StreamWriter logStream;

	public FileStore(string filename)
	{
		var fileLogPath = System.IO.Path.Combine(Application.persistentDataPath, filename);
		logStream = new StreamWriter(fileLogPath, false);		
	}
	
}
