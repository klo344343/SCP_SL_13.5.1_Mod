using System.Collections.Generic;
using UnityEngine;
using PlayerRoles.FirstPersonControl;

namespace CustomCulling
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Camera))]
    public class CullingCamera : MonoBehaviour
    {
        public int RoomDepth = 2;

        private const float CloseToDoorDistance_Far = 9f;
        private const float VisionAngleMultiplier = 1.5f;
        private const float FarVisionAngleMultiplier = 1.2f;
        private const float DoorDistanceAdjustment = 1f;
        public const float NoClipInitialCullDistance = 75f;
        private const float DoorDistance = 13.7f;

        internal static List<CullableRoom> EnabledCullableRooms = new List<CullableRoom>(8);
        internal static CullableRoom[] AllRooms;
        internal static CullableRoom OutsideRoom;
        internal static NoClipCamExtraPoint[] NoClipCamPoints;
        internal static AspectRatioSync AspectSyncer;

        private static float _fullVisionAngle;
        private static float _farVisionAngle;
        private static Vector3 _cachedPosition;
        private static Vector2 _cached2DPos;
        private static Vector2 _cached2DLookDir;
        private static float _closeToDoorDistance;

        private void OnEnable()
        {
            MainCameraController.OnUpdated += UpdateCulling;
        }

        private void OnDisable()
        {
            MainCameraController.OnUpdated -= UpdateCulling;
        }

        private void UpdateCulling()
        {
            var camTransform = Camera.main?.transform ?? MainCameraController.CurrentCamera;
            if (camTransform == null) return;

            _cachedPosition = camTransform.position;
            _cached2DPos = new Vector2(_cachedPosition.x, _cachedPosition.z);
            _cached2DLookDir = new Vector2(camTransform.forward.x, camTransform.forward.z).normalized;

            if (AspectSyncer != null)
            {
                _fullVisionAngle = AspectSyncer.XScreenEdge * VisionAngleMultiplier;
                _farVisionAngle = AspectSyncer.XScreenEdge * FarVisionAngleMultiplier;
                _closeToDoorDistance = AspectSyncer.AspectRatio * 1.1f;
            }

            ResetCullableBases();

            if (ReferenceHub.LocalHub != null &&
                ReferenceHub.LocalHub.roleManager.CurrentRole is IFpcRole fpcRole &&
                fpcRole.FpcModule is FirstPersonMovementModule fpm &&
                fpm.Noclip.IsActive == true)
            {
                DistanceBasedCulling(NoClipInitialCullDistance);
            }
            else
            {
                PerformPortalCulling();
            }

            UpdateCullableBases();
        }

        private void PerformPortalCulling() { }
        private void DistanceBasedCulling(float distance) { }

        private void ResetCullableBases()
        {
            foreach (var room in EnabledCullableRooms)
            {
                room.CurrentRoomState = RoomState.Disabled;
            }
            EnabledCullableRooms.Clear();
        }

        private void UpdateCullableBases()
        {
            for (int i = EnabledCullableRooms.Count - 1; i >= 0; i--)
            {
                var room = EnabledCullableRooms[i];
                if (!room.CullEnabled)
                {
                    EnabledCullableRooms.RemoveAt(i);
                }
                else
                {
                    room.UpdateCulling();
                }
            }
        }

        internal void EnableCullableRoom(CullableRoom cullableRoom, RoomState roomState, DoorLinkingRooms crossoverDoor = null)
        {
            if (cullableRoom == null) return;

            cullableRoom.CrossoverDoor = crossoverDoor;
            cullableRoom.CurrentRoomState = roomState;

            if (!EnabledCullableRooms.Contains(cullableRoom))
            {
                EnabledCullableRooms.Add(cullableRoom);
            }
        }
    }
}