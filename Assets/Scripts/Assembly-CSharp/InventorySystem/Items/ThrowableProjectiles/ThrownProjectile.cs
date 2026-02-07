using System;
using System.Runtime.CompilerServices;
using InventorySystem.Items.Pickups;
using UnityEngine;

namespace InventorySystem.Items.ThrowableProjectiles
{
	public class ThrownProjectile : CollisionDetectionPickup
	{
		[SerializeField]
		private GameObject _renderersRoot;

		public static event Action<ThrownProjectile> OnProjectileSpawned
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Start()
		{
		}

		public virtual void ToggleRenderers(bool state)
		{
		}

		public virtual void ServerActivate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
