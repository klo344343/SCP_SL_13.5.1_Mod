using Interactables.Interobjects.DoorUtils;
using System.Collections.Generic;
using UnityEngine;

namespace CustomCulling
{
    public class DoorLinkingRooms : CullableBase
    {
        internal bool CanNotSeeThrough
        {
            get
            {
                return default(bool);
            }
        }

        internal CullableRoom GetOtherRoom(CullableRoom currentRoom)
        {
            return null;
        }

        internal void Initialize()
        {
        }

        internal void AddLight(bool isForwardRoom, Light light1, float distanceToDoor)
        {
        }

        internal void RefreshDistances(bool forwardRoom)
        {
        }

        private void GetNearbyLights(bool isForward)
        {
        }

        private void Start()
        {
        }

        public DoorLinkingRooms()
        {
        }

        internal float ForwardRoomLightRange;

        internal CullableRoom ForwardRoom;

        internal List<Light> ForwardRoomNearbyLights;

        internal float BackwardRoomLightRange;

        internal CullableRoom BackwardRoom;

        internal List<Light> BackwardRoomNearbyLights;

        private DoorVariant _doorVariant;

        private bool _initialized;
    }
}