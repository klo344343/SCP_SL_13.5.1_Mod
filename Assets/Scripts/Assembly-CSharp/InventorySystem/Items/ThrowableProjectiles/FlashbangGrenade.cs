using UnityEngine;

namespace InventorySystem.Items.ThrowableProjectiles
{
	public class FlashbangGrenade : EffectGrenade
	{
		[SerializeField]
		private AnimationCurve _blindingOverDistance;

		[SerializeField]
		private AnimationCurve _turnedAwayBlindingDistance;

		[SerializeField]
		private AnimationCurve _blindingOverDot;

		[SerializeField]
		private AnimationCurve _deafenDurationOverDistance;

		[SerializeField]
		private AnimationCurve _turnedAwayDeafenDurationOverDistance;

		[SerializeField]
		private AnimationCurve _shakeOverDistance;

		[SerializeField]
		private float _surfaceZoneDistanceIntensifier;

		[SerializeField]
		private float _additionalBlurDuration;

		[SerializeField]
		private float _minimalEffectDuration;

		[SerializeField]
		private LayerMask _blindingMask;

		[SerializeField]
		private float _blindTime;

		private int _hitPlayerCount;

		public override void PlayExplosionEffects(Vector3 pos)
		{
		}

		protected override void ServerFuseEnd()
		{
		}

		private void ProcessPlayer(ReferenceHub hub)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
