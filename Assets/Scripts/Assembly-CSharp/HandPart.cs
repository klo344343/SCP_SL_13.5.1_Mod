using InventorySystem.Items;
using InventorySystem.Items.Thirdperson;
using UnityEngine;

public class HandPart : ThirdpersonItemBase
{
	public GameObject TargetPart;

	public ItemType TargetItemId;

	public bool UseUniversalAnimations;

	[SerializeField]
	private GameObject optionalPrefab;

	protected bool CurrentlyEnabled { get; set; }

	protected GameObject SpawnedObject { get; set; }

	public void UpdateItem()
	{
	}

	public override void ResetObject()
	{
	}

	protected virtual void OnActiveStateChange(bool isEnabled)
	{
	}

	public override float GetTransitionTime(ItemIdentifier iid)
	{
		return 0f;
	}
}
