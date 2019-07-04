﻿using UnityEngine;
using System;

public abstract class SingletonMonoBehaviourFastDontDestroyOnLoad<T> : MonoBehaviour where T : SingletonMonoBehaviourFastDontDestroyOnLoad<T>
{
	protected static readonly string[] findTags  =
	{
		"GameController",
		"MainCamera",
	};

	protected static T instance;
	public static T Instance {
		get {
			if (instance == null) {

				Type type = typeof(T);

				Debug.Log("type:" + type); 
				foreach( var tag in findTags )
				{
					GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

					Debug.LogFormat("find tag:{0} {1}", tag, objs.Length); 
					
					for(int j=0; j<objs.Length; j++)
					{
						instance = (T)objs[j].GetComponent(type);
						if (instance != null)
						{
							DontDestroyOnLoad(instance.gameObject);
							Debug.Log("#### DontDestroyOnLoad #1:" + instance.name);
							return instance;
						}
					}
				}

				Debug.LogWarning( string.Format("{0} is not found", type.Name) );
			}
			
			return instance;
		}
	}
	
	virtual protected void Awake()
	{
		CheckInstance();
	}
	
	protected bool CheckInstance()
	{
		if( instance == null)
		{
			instance = (T)this;
			DontDestroyOnLoad(instance.gameObject);
			Debug.Log("#### DontDestroyOnLoad #2 :" + instance.name);
			return true;
		} else 
		if( Instance == this )
		{
			return true;
		}
		
		Destroy(this);
		return false;
	}
}	