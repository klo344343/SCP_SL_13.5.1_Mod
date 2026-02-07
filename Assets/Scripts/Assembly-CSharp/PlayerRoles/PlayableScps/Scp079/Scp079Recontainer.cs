using System.Collections.Generic;
using System.Diagnostics;
using Interactables.Interobjects.DoorUtils;
using MapGeneration.Distributors;
using UnityEngine;

namespace PlayerRoles.PlayableScps.Scp079
{
	public class Scp079Recontainer : MonoBehaviour
	{
		public static readonly HashSet<Scp079Generator> AllGenerators;

		[SerializeField]
		private DoorVariant[] _containmentGates;

		[SerializeField]
		private float _activationDelay;

		[SerializeField]
		private float _lockdownDuration;

		[SerializeField]
		private Transform _activatorButton;

		[SerializeField]
		private BreakableWindow _activatorGlass;

		[SerializeField]
		private Vector3 _activatorPos;

		[SerializeField]
		private float _activatorLerpSpeed;

		[SerializeField]
		private string _announcementProgress;

		[SerializeField]
		private string _announcementAllActivated;

		[SerializeField]
		private string _announcementCountdown;

		[SerializeField]
		private string _announcementSuccess;

		[SerializeField]
		private string _announcementFailure;

		private const float AnnouncementGlitchChance = 0.035f;

		private const float AnnouncementJamChance = 0.03f;

		private bool _alreadyRecontained;

		private bool _success;

		private int _prevEngaged;

		private float _recontainLater;

		private readonly Stopwatch _delayStopwatch;

		private readonly Stopwatch _unlockStopwatch;

		private readonly HashSet<DoorVariant> _lockedDoors;

		private bool CassieBusy => false;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void OnServerRoleChanged(ReferenceHub hub, RoleTypeId newRole, RoleChangeReason reason)
		{
		}

		private bool IsScpButNot079(PlayerRoleBase prb)
		{
			return false;
		}

		private void RefreshActivator()
		{
		}

		private void Recontain()
		{
		}

		private void RefreshAmount()
		{
		}

		private void SetContainmentDoors(bool opened, bool locked)
		{
		}

		private void UpdateStatus(int engagedGenerators)
		{
		}

		private void BeginOvercharge()
		{
		}

		private void EndOvercharge()
		{
		}

		private bool TryKill079()
		{
			return false;
		}

		private void PlayAnnouncement(string annc, float glitchyMultiplier)
		{
		}
	}
}
