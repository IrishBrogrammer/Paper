using UnityEngine;
using System;
using System.Diagnostics;
using System.Collections;


[AttributeUsage(AttributeTargets.Method)]
public class StackTraceIgnore : Attribute {}

public class LogStackFrame 
{
	public string MethodName;
	public string DeclaringType;
	public string ParameterSig;

	public int LineNumber;
	public int ColumnNumber;
	public string Filename;
	
	public LogStackFrame(StackFrame frame)
	{
		var Method = frame.GetMethod();
		MethodName = Method.Name;
		DeclaringType = Method.DeclaringType.Name;

		var param = Method.GetParameters();

		for (int i = 0; i < param.Length; i++)
		{
			ParameterSig += string.Format("{0} {1}", param[i].ParameterType.Name, param[i].Name);

			if (i + 1 < param.Length)
				ParameterSig += " , ";
		}

		
		Filename = frame.GetFileName();
		LineNumber = frame.GetFileLineNumber();
		ColumnNumber = frame.GetFileColumnNumber();
	}

	public override string ToString()
	{
		return DeclaringType + ":" + MethodName + "( " + ParameterSig  + ")"  + " at  " + " ( " + Filename + " : " + LineNumber + " ) ";
	}


}
