﻿using UnityEngine;


namespace ClockBlockers.Targetting
{
	public class CameraForwardRayProvider : MonoBehaviour, IRayProvider
	{
		[SerializeField]
		private Camera cam = null;

		public Ray CreateRay()
		{
			Transform camTransform = cam.transform;
			return new Ray(camTransform.position, camTransform.forward);
		}
	}
}