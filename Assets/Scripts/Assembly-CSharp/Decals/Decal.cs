using CustomCulling;
using GameObjectPools;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace Decals
{
    [RequireComponent(typeof(CullableAttachToSurface))]
    [RequireComponent(typeof(DecalProjector))]
    public class Decal : PoolObject, IPoolResettable
    {
        private DecalProjector _projector;
        private Color _instancedColor;
        private Material _materialInstance;
        private bool _initialized;
        private Transform _cachedTransform;

        public DecalPoolType DecalPoolType;
        public CullableAttachToSurface CullableAttachToSurface { get; private set; }

        public Color InstancedColor
        {
            get => _instancedColor;
            set
            {
                _instancedColor = value;
                if (_materialInstance != null)
                {
                    _materialInstance.SetColor("_BaseColor", value);
                }
            }
        }

        public Vector2 UVOffset
        {
            get => _materialInstance != null ? _materialInstance.GetVector("_BaseColorMap_ST_Offset") : Vector2.zero;
            set
            {
                if (_materialInstance != null)
                {
                    _materialInstance.SetVector("_BaseColorMap_ST", new Vector4(UVTiling.x, UVTiling.y, value.x, value.y));
                }
            }
        }

        public Vector2 UVTiling
        {
            get => _materialInstance != null ? (Vector2)_materialInstance.GetVector("_BaseColorMap_ST") : Vector2.one;
            set
            {
                if (_materialInstance != null)
                {
                    var offset = UVOffset;
                    _materialInstance.SetVector("_BaseColorMap_ST", new Vector4(value.x, value.y, offset.x, offset.y));
                }
            }
        }

        public void AttachToSurface(Collider collider, Vector3 point, Vector3 normal)
        {
            if (!_initialized)
            {
                InitializeComponents();
            }
            _cachedTransform.position = point;
            _cachedTransform.rotation = Quaternion.LookRotation(-normal, Vector3.up);
            RaycastHit hit = new()
            {
                point = point,
                normal = normal
            };
            CullableAttachToSurface.Attach(hit);
        }

        public void Init(RaycastHit hitSurface)
        {
            if (!_initialized)
            {
                InitializeComponents();
            }

            _cachedTransform.position = hitSurface.point;
            _cachedTransform.rotation = Quaternion.LookRotation(-hitSurface.normal, Vector3.up);
            CullableAttachToSurface.Attach(hitSurface);
        }

        public void SetRandomRotation()
        {
            if (!_initialized)
            {
                InitializeComponents();
            }

            _cachedTransform.Rotate(Vector3.forward, Random.Range(0f, 360f), Space.Self);
        }

        public void ResetObject()
        {
            if (_materialInstance != null)
            {
                Destroy(_materialInstance);
                _materialInstance = null;
            }

            _instancedColor = Color.white;
            if (_projector != null)
            {
                _projector.material = null;
            }
            _initialized = false;
        }

        protected override void OnInstantiated()
        {
            InitializeComponents();
        }

        protected virtual void Awake()
        {
            _cachedTransform = transform;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            if (_initialized || _projector != null) return;

            CullableAttachToSurface = GetComponent<CullableAttachToSurface>();
            _projector = GetComponent<DecalProjector>();

            if (_projector != null && _projector.material != null)
            {
                _materialInstance = new Material(_projector.material);
                _projector.material = _materialInstance;
            }

            _initialized = true;
        }
    }
}