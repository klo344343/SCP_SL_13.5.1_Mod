using GameObjectPools;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace PlayerRoles.FirstPersonControl.Thirdperson
{
	public class CharacterModel : PoolObject, IPoolResettable, IPoolSpawnable
	{
		private record RendererMaterialPair(Renderer Rend, Material Mat)
		{
			protected virtual Type EqualityContract
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
			}

			public Renderer Rend { get; set; }

			public Material Mat { get; set; }

			public override string ToString()
			{
				return null;
			}

			protected virtual bool PrintMembers(StringBuilder builder)
			{
				return false;
			}

			public virtual bool Equals(RendererMaterialPair? other)
			{
				return false;
			}

			protected RendererMaterialPair(RendererMaterialPair original)
			{
			}

			public void Deconstruct(out Renderer Rend, out Material Mat)
			{
				Rend = null;
				Mat = null;
			}
		}

		private float _lastFade = 1f;

		private Material[] _fadeableMaterials;

		private RendererMaterialPair[] _originalMaterials;

        private static readonly int FadeHash = Shader.PropertyToID("_Fade");

        private static Material[] _copyMaterialsNonAlloc = new Material[16];

        [SerializeField]
		private Renderer[] _renderers;

		public HitboxIdentity[] Hitboxes;

		public bool IsVisible { get; private set; }

		public ReferenceHub OwnerHub { get; private set; }

        public ReadOnlySpan<Renderer> Renderers => _renderers;

        protected Transform CachedTransform { get; private set; }

        public virtual float Fade
        {
            get
            {
                return Mathf.Clamp01(_lastFade);
            }
            set
            {
                value = Mathf.Clamp01(value);
                if (Fade != value)
                {
                    int num = FadeableMaterials.Length;
                    for (int i = 0; i < num; i++)
                    {
                        _fadeableMaterials[i].SetFloat(FadeHash, value);
                    }
                    _lastFade = value;
                    this.OnFadeChanged?.Invoke();
                }
            }
        }


        public Material[] FadeableMaterials
        {
            get
            {
                if (_fadeableMaterials == null)
                {
                    InstantiateFadeableMaterials();
                }
                return _fadeableMaterials;
            }
        }

        public event Action OnVisibilityChanged;

		public event Action OnFadeChanged;

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            PlayerRoleLoader.OnLoaded = (Action)Delegate.Combine(PlayerRoleLoader.OnLoaded, (Action)delegate
            {
                foreach (KeyValuePair<RoleTypeId, PlayerRoleBase> allRole in PlayerRoleLoader.AllRoles)
                {
                    if (allRole.Value is IFpcRole fpcRole && fpcRole.FpcModule.CharacterModelTemplate.TryGetComponent<CharacterModel>(out var component))
                    {
                        PoolManager.Singleton.TryAddPool(component);
                    }
                }
            });
        }

        private void InstantiateFadeableMaterials()
        {
            int num = _renderers.Length;
            if (_copyMaterialsNonAlloc.Length < num)
            {
                _copyMaterialsNonAlloc = new Material[num];
            }
            if (_originalMaterials == null)
            {
                SetOriginalMaterials();
            }
            int num2 = 0;
            for (int i = 0; i < num; i++)
            {
                Renderer renderer = _renderers[i];
                Material sharedMaterial = renderer.sharedMaterial;
                if (sharedMaterial.HasFloat(FadeHash))
                {
                    Material material = (renderer.sharedMaterial = new Material(sharedMaterial));
                    _copyMaterialsNonAlloc[num2] = material;
                    num2++;
                }
            }
            _fadeableMaterials = new Material[num2];
            Array.Copy(_copyMaterialsNonAlloc, _fadeableMaterials, num2);
        }

        protected virtual void Awake()
        {
            CachedTransform = base.transform;
        }

        protected virtual void OnValidate()
        {
            Hitboxes = GetComponentsInChildren<HitboxIdentity>();
            MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>();
            SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>();
            int num = componentsInChildren.Length;
            int num2 = componentsInChildren2.Length;
            _renderers = new Renderer[num + num2];
            Array.Copy(componentsInChildren, _renderers, num);
            Array.Copy(componentsInChildren2, 0, _renderers, num, num2);
        }

        public virtual void SetVisibility(bool newState)
		{
		}

        public virtual void ResetObject()
        {
            Fade = 1f;
            HitboxIdentity[] hitboxes = Hitboxes;
            foreach (HitboxIdentity item in hitboxes)
            {
                HitboxIdentity.Instances.Remove(item);
            }
        }

        public virtual void SpawnObject()
        {
            OwnerHub = ReferenceHub.GetHub(base.transform.root.gameObject);
            HitboxIdentity[] hitboxes = Hitboxes;
            foreach (HitboxIdentity hitboxIdentity in hitboxes)
            {
                HitboxIdentity.Instances.Add(hitboxIdentity);
                hitboxIdentity.SetColliders(!OwnerHub.isLocalPlayer);
            }
        }

        public void SetOriginalMaterials()
        {
            int num = _renderers.Length;
            if (_copyMaterialsNonAlloc.Length < num)
            {
                _copyMaterialsNonAlloc = new Material[num];
            }
            if (_originalMaterials == null)
            {
                _originalMaterials ??= new RendererMaterialPair[num];
            }
            for (int i = 0; i < num; i++)
            {
                Renderer renderer = _renderers[i];
                Material sharedMaterial = renderer.sharedMaterial;
                _originalMaterials[i] = new RendererMaterialPair(renderer, sharedMaterial);
            }
        }

        public void RestoreOriginalMaterials()
        {
            if (_originalMaterials != null)
            {
                for (int i = 0; i < _originalMaterials.Length; i++)
                {
                    RendererMaterialPair rendererMaterialPair = _originalMaterials[i];
                    rendererMaterialPair.Rend.sharedMaterial = rendererMaterialPair.Mat;
                }
                _fadeableMaterials = null;
            }
        }

        public virtual void OnTreadmillInitialized()
		{
		}
	}
}
