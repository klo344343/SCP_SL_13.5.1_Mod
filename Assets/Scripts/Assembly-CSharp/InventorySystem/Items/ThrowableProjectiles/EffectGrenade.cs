using UnityEngine;

namespace InventorySystem.Items.ThrowableProjectiles
{
	public class EffectGrenade : TimeGrenade
	{
		public GameObject Effect;

		[SerializeField]
		private float _destroyTime;

		[SerializeField]
		private AudioSource _src;

		private bool _resyncAudio;

		public override void ToggleRenderers(bool state)
		{
		}

		protected override void Update()
		{
		}

		public virtual void PlayExplosionEffects(Vector3 position)
		{
		}

		protected override void ServerFuseEnd()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
