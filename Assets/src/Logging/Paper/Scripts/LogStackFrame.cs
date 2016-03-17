using UnityEngine;
using System.Diagnostics;
using System.Collections;

public class LogStackFrame 
{
	public string MethodName;
	public string DeclaringType;
	public string ParameterSig;

	public int LineNumber;
	public string Filename;

	public LogStackFrame(StackFrame frame)
	{
		var Method = frame.GetMethod();
		MethodName = Method.Name;
		DeclaringType = Method.DeclaringType.Name;

		var param = Method.GetParameters();

		for (int i = 0; i < param.Length; i++)
		{
			ParameterSig += string.Format("{0} {1}", param[i].ParameterType, param[i].Name);

			if (i + 1 < param.Length)
				ParameterSig += " , ";
		}

		Filename = frame.GetFileName();
		LineNumber = frame.GetFileLineNumber();
	}

	public override string ToString()
	{
		return Filename + " : " + LineNumber + " : " + MethodName;
	}


}
