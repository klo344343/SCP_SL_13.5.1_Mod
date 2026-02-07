using System.Collections.Generic;
using Decals;
using UnityEngine;

namespace CustomCulling
{
    internal enum RoomState : byte
    {
        Disabled,
        Enabled,
        LightCrossover,
        AllCrossover,
        DynamicBases
    }

    internal readonly struct UpdateType
    {
        public bool UpdateRenderers { get; }
        public bool UpdateBehaviours { get; }
        public bool UpdateLights { get; }

        public UpdateType(bool updateRenderers, bool updateBehaviours, bool updateLights)
        {
            UpdateRenderers = updateRenderers;
            UpdateBehaviours = updateBehaviours;
            UpdateLights = updateLights;
        }
    }

    public class CullableRoom : CullableBase
    {
        private List<CullableBase> cullableBases = new List<CullableBase>();
        private RoomState currentRoomState = RoomState.Disabled;
        private RoomState previousRoomState = RoomState.Disabled;
        private UpdateType currentUpdateType;

        internal List<DoorLinkingRooms> Doors = new List<DoorLinkingRooms>(1);
        internal DoorLinkingRooms CrossoverDoor;

        public List<CullableBase> CullableBases => cullableBases;

        internal RoomState CurrentRoomState
        {
            get => currentRoomState;
            set
            {
                previousRoomState = currentRoomState;
                currentRoomState = value;
            }
        }

        internal UpdateType CurrentUpdateType
        {
            get => currentUpdateType;
            set => currentUpdateType = value;
        }

        public override bool CullEnabled => currentRoomState != RoomState.Disabled;

        private static readonly UpdateType _disableAllUpdateType = new UpdateType(false, false, false);
        private static readonly UpdateType _enableAllUpdateType = new UpdateType(true, true, true);
        private static readonly UpdateType _skipLightUpdateType = new UpdateType(true, true, false);

        public void AddDecal(Decal d)
        {
            if (d != null)
            {
                Decals.Add(d);
                d.enabled = CullEnabled;
            }
        }

        internal void AddCullableBase(CullableBase cullableBase)
        {
            if (cullableBase == null || cullableBases.Contains(cullableBase)) return;

            cullableBases.Add(cullableBase);
            ForceUpdateBehaviours(cullableBase, CullEnabled);
        }

        internal void RemoveCullableBase(CullableBase cullableBase)
        {
            if (cullableBase == null || !cullableBases.Remove(cullableBase)) return;

            ForceUpdateBehaviours(cullableBase, false);

            cullableBase.renderers.RemoveAll(r => r == null);
            cullableBase.otherBehaviours.RemoveAll(b => b == null);
            cullableBase.lights.RemoveAll(l => l == null);
            cullableBase.Decals.RemoveAll(d => d == null);
        }

        private void ForceUpdateBehaviours(CullableBase cullBase, bool enabled)
        {
            foreach (var r in cullBase.renderers) if (r) r.enabled = enabled;
            foreach (var b in cullBase.otherBehaviours) if (b) b.enabled = enabled;

            bool lightEnabled = enabled && (cullBase.StaticObject ||
                currentRoomState == RoomState.Enabled ||
                currentRoomState == RoomState.AllCrossover ||
                currentRoomState == RoomState.LightCrossover);

            foreach (var l in cullBase.lights)
            {
                if (l) l.enabled = lightEnabled && !CullingManager.AllLightsDisabled;
            }

            foreach (var d in cullBase.Decals) if (d) d.enabled = enabled;
        }

        internal void UpdateAllLighting()
        {
            bool lightsOn = !CullingManager.AllLightsDisabled;
            foreach (var baseObj in cullableBases)
            {
                foreach (var light in baseObj.lights)
                {
                    if (light != null)
                    {
                        bool shouldBeOn = lightsOn && (baseObj.StaticObject ||
                            currentRoomState == RoomState.Enabled ||
                            currentRoomState == RoomState.AllCrossover ||
                            currentRoomState == RoomState.LightCrossover);

                        light.enabled = shouldBeOn;
                    }
                }
            }
        }

        internal void UpdateCulling()
        {
            UpdateRoom();
            UpdateDoors();
            UpdateCullableBases();
        }

        private void UpdateRoom() { }
        private void UpdateDoors() { }

        private void UpdateCullableBases()
        {
            foreach (var baseObj in cullableBases)
            {
                baseObj.UpdateBehaviours();
            }
        }

        internal static bool CheckRoom(CullableRoom room) => room != null;

        public CullableRoom()
        {
            cullableBases = new List<CullableBase>();
            currentUpdateType = _disableAllUpdateType;
        }
    }
}