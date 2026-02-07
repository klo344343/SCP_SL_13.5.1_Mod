using Footprinting;
using InventorySystem.Items.Pickups;
using UnityEngine;

namespace InventorySystem.Items.ThrowableProjectiles
{
	public class TimedGrenadePickup : CollisionDetectionPickup, IExplosionTrigger
	{
		private bool _replaceNextFrame;

		private Footprint _attacker;

		private const float ActivationRange = 0.4f;

		private void Update()
		{
		}

		public void OnExplosionDetected(Footprint attacker, Vector3 source, float range)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
