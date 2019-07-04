using System.Collections.Generic;
using UnityEngine;
namespace _MyProject.Scripts.Tricol.Controller
{
	public abstract class IOneController
	{

		public abstract void Haptics(AudioClip clip, MonoBehaviour behaviour);
	
		// common input  
		// 基本的にこちらを使用するようにしてください
		public virtual bool  Button { get; }
		public virtual bool  ButtonPress { get; }
		public virtual float Trigger { get; }
		public virtual bool  TriggerPress { get; }
		
		// diarect remove future Release   
		
		public virtual bool  ButtonOne { get; }
		public virtual bool  ButtonOnePress { get; }
		public virtual bool  ButtonTwo { get; }
		public virtual bool  ButtonThree { get; }
		public virtual bool  ButtonThreePress { get; }
		public virtual bool  ButtonFour { get; }
		public virtual bool  Start { get; }
		public virtual float Grab { get; }
		public virtual float Grip { get; }
		public virtual float Action { get; }
		public virtual float Pointer { get; }
		public virtual Vector3 Velocity { get; }
		public virtual Vector3 AngularVelocity { get; }
		public virtual Vector2 Stick { get; } 
		public virtual bool   StickGetDown { get; }
		public virtual Vector3 Position { get; }
		public virtual GameObject GameObject { get; }

		/*
#if !RELEASE
		public virtual string Dbg() { return ""; }
#endif
		*/
	}

	public abstract class IControllerUtils
	{
		public abstract VelocityTracker LeftVelocityTracker { get; }
		public abstract VelocityTracker RightVelocityTracker { get; }
		
		public abstract IOneController LeftHand { get; }
		public abstract IOneController RightHand { get; }
		public abstract GameObject LeftHandAnchor { get; }
		public abstract GameObject RightHandAnchor { get; }

		/// <summary>
		/// call on awake need mandatory
		/// </summary>
		public abstract void Init();
		
	}
}
