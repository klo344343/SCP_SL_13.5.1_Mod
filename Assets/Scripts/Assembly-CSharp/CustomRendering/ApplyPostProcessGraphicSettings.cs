using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UserSettings;

namespace CustomRendering
{
    public class ApplyPostProcessGraphicSettings : MonoBehaviour
    {
        private VolumeProfile _volumeProfile;

        private const float MinBrightness = -0.7f;

        private const float MaxBrightness = 0f;

        private void Start()
        {
            Volume volume = GetComponent<Volume>();
            _volumeProfile = volume.profile;

            float brightness = UserSetting<float>.Get(UserSettings.VideoSettings.MiscVideoSetting.Brightness);
            if (_volumeProfile.TryGet<LiftGammaGain>(out var liftGammaGain))
            {
                liftGammaGain.gain.value = new Vector4(brightness > 0 ? brightness : 0, brightness > 0 ? brightness : 0, brightness > 0 ? brightness : 0, brightness < 0 ? -brightness : 0);
            }

            UserSetting<float>.AddListener(UserSettings.VideoSettings.MiscVideoSetting.Brightness, UpdateBrightness);

            int bloomQuality = UserSetting<int>.Get(UserSettings.VideoSettings.PerformanceVideoSetting.BloomQuality);
            UpdateBloom(bloomQuality);
            UserSetting<int>.AddListener(UserSettings.VideoSettings.PerformanceVideoSetting.BloomQuality, UpdateBloom);

            int aoQuality = UserSetting<int>.Get(UserSettings.VideoSettings.PerformanceVideoSetting.AOQuality);
            UpdateAO(aoQuality);
            UserSetting<int>.AddListener(UserSettings.VideoSettings.PerformanceVideoSetting.AOQuality, UpdateAO);

            bool shakeEnabled = UserSetting<bool>.Get(UserSettings.VideoSettings.MiscVideoSetting.ExplosionShake);
            UpdateShake(shakeEnabled);
            UserSetting<bool>.AddListener(UserSettings.VideoSettings.MiscVideoSetting.ExplosionShake, UpdateShake);
        }

        private void OnDestroy()
        {
            UserSetting<float>.RemoveListener(UserSettings.VideoSettings.MiscVideoSetting.Brightness, UpdateBrightness);
            UserSetting<int>.RemoveListener(UserSettings.VideoSettings.PerformanceVideoSetting.BloomQuality, UpdateBloom);
            UserSetting<int>.RemoveListener(UserSettings.VideoSettings.PerformanceVideoSetting.AOQuality, UpdateAO);
            UserSetting<bool>.RemoveListener(UserSettings.VideoSettings.MiscVideoSetting.ExplosionShake, UpdateShake);
        }

        private void UpdateBrightness(float brightness)
        {
            if (_volumeProfile.TryGet<LiftGammaGain>(out var liftGammaGain))
            {
                liftGammaGain.gain.value = new Vector4(brightness > 0 ? brightness : 0, brightness > 0 ? brightness : 0, brightness > 0 ? brightness : 0, brightness < 0 ? -brightness : 0);
            }
        }

        private void UpdateBloom(int qualityLevel)
        {
            if (_volumeProfile.TryGet<Bloom>(out var bloom))
            {
                bloom.active = qualityLevel != 0;
                bloom.quality.value = qualityLevel - 1;
            }
        }

        private void UpdateAO(int qualityLevel)
        {
            if (_volumeProfile.TryGet<AmbientOcclusion>(out var ao))
            {
                ao.active = qualityLevel != 0;
                switch (qualityLevel - 1)
                {
                    case 0:
                        ao.quality.value = (int)ScalableSettingLevelParameter.Level.Low;
                        break;
                    case 1:
                        ao.quality.value = (int)ScalableSettingLevelParameter.Level.Medium;
                        break;
                    case 2:
                        ao.quality.value = (int)ScalableSettingLevelParameter.Level.High;
                        break;
                }
            }
        }

        private void UpdateShake(bool enable)
        {
            if (_volumeProfile.TryGet<CameraShake>(out var shake))
            {
                shake.active = enable;
            }
        }
    }
}
