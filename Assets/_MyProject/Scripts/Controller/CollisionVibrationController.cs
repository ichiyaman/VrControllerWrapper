using UnityEngine;
using System.Collections;

namespace _MyProject.Scripts.Tricol.Controller
{
	public class CollisionVibrationController : MonoBehaviour {

//	[SerializeField, Range(100, 2000)]
//	private ushort pulseDuration = 500;

		[SerializeField]
		AudioClip hapticsClip;

		[SerializeField]
		bool isRight = false;

//	[SerializeField]
//	private SteamVR_TrackedObject trackedObj;

		[SerializeField]
		private string targetTagName = "PickupableObject";

		void OnTriggerEnter (Collider other) {
			if (other.transform.tag.Equals (targetTagName)) {
				if (isRight) {
					ControllerUtils.RightHand.Haptics (hapticsClip, this);
				} else {
					ControllerUtils.LeftHand.Haptics (hapticsClip, this);
				}
//			SteamVR_Controller.Device device = GameCommonUtils.GetDevice (trackedObj);
//			device.TriggerHapticPulse (pulseDuration);
			}
		}
	}
}

