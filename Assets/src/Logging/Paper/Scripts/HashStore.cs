using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HashStore<T>  
{
	private Dictionary<T, string> store;

	public HashStore()
	{
		store = new Dictionary<T, string>();	
	}

	public void Add( T channelToAdd )
	{ 
		if ( Contains( channelToAdd ) == false ) 
			store.Add( channelToAdd , null );
	}

	public void Remove(T channelToRemove)
	{ 
		if ( Contains( channelToRemove ) )
			store.Remove( channelToRemove );
	}

	// Check if a given channel is stored. 
	public bool Contains(T channel)
	{
		return store.ContainsKey(channel);
	}

	// Clear all keys stored
	public void Clear()
	{
		store.Clear();
	}

}
