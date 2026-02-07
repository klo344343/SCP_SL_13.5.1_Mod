using UnityEngine;

namespace OperationalGuide
{
	[SerializeField]
	public class PannableObject : MonoBehaviour
	{
		private const float RotationSpeed = 400f;

		private const float IdleRotationSpeed = 25f;

		private const float InertiaDecay = 0.994f;

		private const float SlowAmount = 0.1f;

		private const float AgressiveInertiaDecay = 0.96f;

		public bool UserInput;

		public float XAxisModifer;

		public float YAxisModifer;

		private float _verticalInertia;

		private float _horizontalInertia;

		private void Update()
		{
		}

		public virtual void OnUpdate()
		{
		}

		private void OnEnable()
		{
		}

		public virtual void OnPannableEnable()
		{
		}

		private void OnDisable()
		{
		}

		public virtual void OnPannableDisable()
		{
		}

		public virtual void OnPannableStart()
		{
		}

		private void Start()
		{
		}
	}
}
