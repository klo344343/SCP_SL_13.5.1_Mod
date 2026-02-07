using UnityEngine;

public class LiquidWobble : MonoBehaviour
{
	[SerializeField]
	private float _maxWobble;

	[SerializeField]
	private float _wobbleSpeed;

	[SerializeField]
	private float _recovery;

	private Renderer _renderer;

	private Vector3 _lastPosition;

	private Vector3 _velocity;

	private Vector3 _lastRotation;

	private Vector3 _angularVelocity;

	private float _wobbleAmountX;

	private float _wobbleAmountZ;

	private float _wobbleAmountToAddX;

	private float _wobbleAmountToAddZ;

	private float _pulse;

	private float _time;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
