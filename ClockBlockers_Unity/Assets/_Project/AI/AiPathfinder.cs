﻿using System.Collections.Generic;

using ClockBlockers.Characters;
using ClockBlockers.MapData;
using ClockBlockers.MapData.Pathfinding;
using ClockBlockers.ReplaySystem;
using ClockBlockers.Utility;

using UnityEngine;


namespace ClockBlockers.AI
{
	public abstract class AiPathfinder : MonoBehaviour, IPathRequester
	{
		protected CharacterMovement characterMovement;
		
		// "Final" destination
		protected Translation destination;

		protected bool pathFind = false;

		protected virtual void Awake()
		{
			characterMovement = GetComponent<CharacterMovement>();
		}

		private void Update()
		{
			if (!pathFind) return;
			
			MoveTowardsNextWaypoint();
		}

		public virtual void ChangeDestination(Translation newDestination)
		{
			destination = newDestination;
		}

		protected abstract void MoveTowardsNextWaypoint();

		public void EnablePathfinding()
		{
			pathFind = true;
		}

		public void DisablePathFinding()
		{
			pathFind = false;
		}

		public void PathCallback(List<PathfindingMarker> pathFinderPath)
		{
			Logging.Log($"{name} successfully received their path");
		}
		public IPathfinder CurrentPathfinder { get; set; }
	}
}