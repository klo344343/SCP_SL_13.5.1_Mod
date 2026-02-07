using UnityEngine;

namespace CustomCulling
{
    public class DynamicCullableBase : CullableBase
    {
        private CullableRoom _linkedRoom;
        private Transform _transform;
        private Vector3 _savedPosition;

        public CullableRoom LinkedRoom
        {
            get => _linkedRoom;
            private set => _linkedRoom = value;
        }

        public override bool CullEnabled
        {
            get
            {
                if (_linkedRoom == null)
                {
                    return true;
                }
                return _linkedRoom.CullEnabled;
            }
        }

        public void UpdateRoom(bool updateChildDynamicCullableBases = false)
        {
            Vector3 currentPosition = transform.position;

            var roomIdentifier = MapGeneration.RoomIdUtils.RoomAtPositionRaycasts(currentPosition);

            CullableRoom room = null;
            if (roomIdentifier != null)
            {
                room = roomIdentifier.GetComponent<CullableRoom>();
            }

            if (room == null)
            {
                room = CullingCamera.OutsideRoom;
            }

            if (_linkedRoom != null && _linkedRoom != room)
            {
                _linkedRoom.RemoveCullableBase(this);
            }

            _linkedRoom = room;

            if (_linkedRoom != null)
            {
                _linkedRoom.AddCullableBase(this);
            }

            if (updateChildDynamicCullableBases)
            {
                foreach (Transform child in transform)
                {
                    var childDynamic = child.GetComponent<DynamicCullableBase>();
                    if (childDynamic != null)
                    {
                        childDynamic.UpdateRoom(true);
                    }
                }
            }
        }

        private void Update()
        {
            Vector3 currentPos = _transform.position;
            float distanceMoved = Vector3.Distance(currentPos, _savedPosition);

            if (distanceMoved > 0.01f)
            {
                _savedPosition = currentPos;
                UpdateRoom(false);
            }
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            _transform = transform;
            _savedPosition = _transform.position;

            UpdateRoom(false);
        }

        public DynamicCullableBase()
        {
        }
    }
}