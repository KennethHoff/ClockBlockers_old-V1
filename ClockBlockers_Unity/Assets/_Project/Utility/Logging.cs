﻿using UnityEngine;

using Object = UnityEngine.Object;
// ReSharper disable UnusedMember.Global


// ReSharper disable Unity.PerformanceCriticalCodeInvocation

namespace ClockBlockers.Utility
{
	public static class Logging
	{
		public static void Log(object message, Object context)
		{
			Debug.Log(message, context);
		}

		public static void Log(object message)
		{
			Debug.Log(message);
		}

		public static void LogWarning(object message, Object context)
		{
			Debug.LogWarning(message, context);
		}

		public static void LogWarning(object message)
		{
			Debug.LogWarning(message);
		}

		public static void LogError(object message, Object context)
		{
			Debug.LogError(message, context);
		}

		public static void LogError(object message)
		{
			Debug.LogError(message);
		}

		public static void LogIncorrectInstantiation(string typeStr, Object context)
		{
			LogWarning("Created incorrectly. Missing " + typeStr + ".", context);
		}
	}
}