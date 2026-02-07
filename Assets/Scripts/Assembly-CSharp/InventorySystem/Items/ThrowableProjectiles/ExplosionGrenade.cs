using System;
using System.Runtime.CompilerServices;
using CustomPlayerEffects;
using Footprinting;
using Interactables.Interobjects.DoorUtils;
using UnityEngine;

namespace InventorySystem.Items.ThrowableProjectiles
{
	public class ExplosionGrenade : EffectGrenade
	{
		[Header("Hitreg")]
		[SerializeField]
		private LayerMask _detectionMask;

		[SerializeField]
		private float _maxRadius;

		[SerializeField]
		private float _scpDamageMultiplier;

		[Header("Curves")]
		[SerializeField]
		private AnimationCurve _playerDamageOverDistance;

		[SerializeField]
		private AnimationCurve _effectDurationOverDistance;

		[SerializeField]
		private AnimationCurve _doorDamageOverDistance;

		[SerializeField]
		private AnimationCurve _shakeOverDistance;

		[Header("Player Effects")]
		[SerializeField]
		private float _burnedDuration;

		[SerializeField]
		private float _deafenedDuration;

		[SerializeField]
		private float _concussedDuration;

		[SerializeField]
		private float _minimalDuration;

		[Header("Physics")]
		[SerializeField]
		private float _rigidbodyBaseForce;

		[SerializeField]
		private float _rigidbodyLiftForce;

		[SerializeField]
		private float _humeShieldMultipler;

		private const float MinimalMass = 0.5f;

		private const float MaxMass = 10f;

		private const float MassFactor = 3f;

		public static event Action<Footprint, Vector3, ExplosionGrenade> OnExploded
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

		public override void PlayExplosionEffects(Vector3 pos)
		{
		}

		protected override void ServerFuseEnd()
		{
		}

		public static void Explode(Footprint attacker, Vector3 position, ExplosionGrenade settingsReference)
		{
		}

		private static void ExplodeRigidbody(Rigidbody rb, Vector3 pos, float radius, ExplosionGrenade setts)
		{
		}

		private static bool ExplodeDestructible(IDestructible dest, Footprint attacker, Vector3 pos, ExplosionGrenade setts)
		{
			return false;
		}

		private static void ExplodeDoor(DoorVariant dv, Vector3 pos, ExplosionGrenade setts)
		{
		}

		private static void TriggerEffect<T>(ReferenceHub hub, float duration, float minimal) where T : StatusEffectBase
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
