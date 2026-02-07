using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldableButton : Button
{
	private readonly Stopwatch _holdSw;

	private bool _eventCalled;

	[SerializeField]
	private Image _loadingCircle;

	[SerializeField]
	private bool _deselectOnComplete;

	public bool IsHeld => false;

	public bool IsHovering => false;

	public float HeldPercent => 0f;

	[field: SerializeField]
	public float HoldTime { get; private set; }

	[field: SerializeField]
	public ButtonClickedEvent OnHeld { get; private set; }

	public override void OnPointerDown(PointerEventData eventData)
	{
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}
}
