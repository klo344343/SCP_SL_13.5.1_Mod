using System;
using System.Collections.Generic;
using GameObjectPools;
using UnityEngine;
using UserSettings;
using UserSettings.VideoSettings;

namespace Decals
{
    public class DecalPoolManager : MonoBehaviour
    {
        public static DecalPoolManager Singleton;

        [SerializeField]
        private List<Decal> _decalPrefabs;

        private List<Decal> _spawnedDecals = new List<Decal>();

        private static readonly CachedUserSetting<bool> BloodDecalsEnabled = new CachedUserSetting<bool>(PerformanceVideoSetting.BloodDecalsEnabled);

        private static readonly CachedUserSetting<bool> BulletDecalsEnabled = new CachedUserSetting<bool>(PerformanceVideoSetting.BulletDecalsEnabled);

        public bool TrySpawnDecal(DecalPoolType decalType, out Decal decal)
        {
            switch (decalType)
            {
                case DecalPoolType.Blood:
                    if (BloodDecalsEnabled.Value)
                    {
                        break;
                    }
                    goto IL_0040;
                case DecalPoolType.Buckshot:
                    if (BulletDecalsEnabled.Value)
                    {
                        break;
                    }
                    goto IL_0040;
                case DecalPoolType.Bullet:
                    {
                        if (BulletDecalsEnabled.Value)
                        {
                            break;
                        }
                        goto IL_0040;
                    }
                IL_0040:
                    decal = null;
                    return false;
            }
            foreach (Decal decalPrefab in _decalPrefabs)
            {
                if (decalPrefab.DecalPoolType == decalType)
                {
                    if (PoolManager.Singleton.TryGetPoolObject(decalPrefab.gameObject, out var poolObject) && poolObject is Decal decal2)
                    {
                        decal = decal2;
                        _spawnedDecals.Add(decal);
                        return true;
                    }
                    break;
                }
            }
            decal = null;
            return false;
        }

        public void ReturnDecal(Decal decal)
        {
            decal.ReturnToPool();
        }

        private void Awake()
        {
            Singleton = this;
            foreach (Decal decalPrefab in _decalPrefabs)
            {
                PoolManager.Singleton.TryAddPool(decalPrefab);
            }
            UserSetting<bool>.AddListener(PerformanceVideoSetting.BloodDecalsEnabled, OnBloodSettingChanged);
            UserSetting<bool>.AddListener(PerformanceVideoSetting.BulletDecalsEnabled, OnBulletSettingChanged);
        }

        private void OnDestroy()
        {
            UserSetting<bool>.RemoveListener(PerformanceVideoSetting.BloodDecalsEnabled, OnBloodSettingChanged);
            UserSetting<bool>.RemoveListener(PerformanceVideoSetting.BulletDecalsEnabled, OnBulletSettingChanged);
        }

        private void OnBloodSettingChanged(bool isEnabled)
        {
            if (!isEnabled)
            {
                RemoveConditionally((Decal x) => x.DecalPoolType == DecalPoolType.Blood);
            }
        }

        private void OnBulletSettingChanged(bool isEnabled)
        {
            if (!isEnabled)
            {
                RemoveConditionally((Decal x) => x.DecalPoolType == DecalPoolType.Bullet || x.DecalPoolType == DecalPoolType.Buckshot);
            }
        }

        private void RemoveConditionally(Func<Decal, bool> conditionToRemove)
        {
            if (_spawnedDecals.Count == 0)
            {
                return;
            }
            List<Decal> list = new List<Decal>();
            foreach (Decal spawnedDecal in _spawnedDecals)
            {
                if (!(spawnedDecal == null))
                {
                    if (conditionToRemove(spawnedDecal))
                    {
                        spawnedDecal.ReturnToPool();
                    }
                    else
                    {
                        list.Add(spawnedDecal);
                    }
                }
            }
            _spawnedDecals = list;
        }
    }
}
