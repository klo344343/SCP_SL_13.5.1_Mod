using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Items.Usables.Scp1576
{
	public class Scp1576Source : MonoBehaviour
	{
		public static Action<Scp1576Source> OnRemoved;

		public static HashSet<Scp1576Source> Instances;

		private Transform _cachedTransform;

		private bool _transformCacheSet;

		private bool _positionUpToDate;

		private Vector3 _lastPos;

		public Vector3 Position => default(Vector3);

		[field: SerializeField]
		public bool HideGlobalIndicator { get; private set; }

		private Transform CachedTransform => null;

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
