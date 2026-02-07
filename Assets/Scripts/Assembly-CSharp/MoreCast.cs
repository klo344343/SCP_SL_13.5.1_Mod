using System.Collections.Generic;
using UnityEngine;

public class MoreCast : MonoBehaviour
{
	public static bool BeamCast(Vector3 start, Vector3 end, Vector3 beamRadius, float beamStep, out List<RaycastHit> hitInfo, int layerMask, bool any)
	{
		hitInfo = null;
		return false;
	}

	public static bool BeamCast(Vector3 start, Vector3 end, Vector3 beamRadius, float beamStep, int layerMask, bool any)
	{
		return false;
	}
}
