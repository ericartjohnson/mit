using UnityEngine;
using System;
using System.Collections.Generic;

public struct BroadcastListener {
	public Action<object> action;
	public string messageName;
	public bool shouldRemove;
}

public static class BroadcastCenter{

	private static List<BroadcastListener> broadcastListeners = new List<BroadcastListener>();

	public static void addListener(Action<object> action, string messageName){
		
		if(action == null || messageName == null) return;

		BroadcastListener bl = new BroadcastListener();
		bl.action = action;
		bl.messageName = messageName;
		bl.shouldRemove = false;
		broadcastListeners.Add(bl);
		Debug.Log("Listener added for message: " + messageName + " " + action.ToString());
	}

	public static void removeListener(Action<object>action, string messageName){
		for(int i = 0; i < broadcastListeners.Count; i+= 1) //  for each file
		{
			BroadcastListener bl = broadcastListeners[i];
    		if(bl.action == action && bl.messageName == messageName) bl.shouldRemove = true;
			broadcastListeners[i] = bl;
		}
	}

	public static void broadcastMessage(string messageName, object messageData){
		foreach(BroadcastListener bl in broadcastListeners){
			if(!bl.shouldRemove && bl.messageName == messageName){
				bl.action.Invoke(messageData);
			}
		}
		BroadcastCenter.cleanListenerList();
	}
	
	public static void clearAllListeners(){
		broadcastListeners.Clear();
	}
	
	private static void cleanListenerList(){
		broadcastListeners.RemoveAll(bl => bl.shouldRemove);
	}
}