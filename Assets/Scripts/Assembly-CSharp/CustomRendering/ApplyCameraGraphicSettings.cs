using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UserSettings;
using static UnityEngine.Rendering.HighDefinition.HDAdditionalCameraData;

namespace CustomRendering
{
    public class ApplyCameraGraphicSettings : MonoBehaviour
    {
        private enum AntiAliasingType
        {
            Disabled = 0,
            FXAA = 1,
            SMAA = 2
        }

        [SerializeField]
        private int _defaultAAType;

        [SerializeField]
        private int _defaultAAQuality;

        private void Start()
        {
            UserSetting<int>.AddListener(UserSettings.VideoSettings.PerformanceVideoSetting.AntiAliasingType, UpdateAAType);
            UserSetting<int>.AddListener(UserSettings.VideoSettings.PerformanceVideoSetting.AntiAliasingQuality, UpdateAAQuality);

            int aaType = UserSetting<int>.Get(UserSettings.VideoSettings.PerformanceVideoSetting.AntiAliasingType);
            HDAdditionalCameraData hdCamera = GetComponent<HDAdditionalCameraData>();
            hdCamera.antialiasing = (aaType == 1) ? AntialiasingMode.FastApproximateAntialiasing : AntialiasingMode.SubpixelMorphologicalAntiAliasing;

            int aaQuality = UserSetting<int>.Get(UserSettings.VideoSettings.PerformanceVideoSetting.AntiAliasingQuality);
            hdCamera.SMAAQuality = (SMAAQualityLevel)aaQuality;
        }

        private void OnDestroy()
        {
            UserSetting<int>.RemoveListener(UserSettings.VideoSettings.PerformanceVideoSetting.AntiAliasingType, UpdateAAType);
            UserSetting<int>.RemoveListener(UserSettings.VideoSettings.PerformanceVideoSetting.AntiAliasingQuality, UpdateAAQuality);
        }

        private void UpdateAAType(int type)
        {
            HDAdditionalCameraData hdCamera = GetComponent<HDAdditionalCameraData>();
            hdCamera.antialiasing = (type == 1) ? AntialiasingMode.FastApproximateAntialiasing : AntialiasingMode.SubpixelMorphologicalAntiAliasing;
        }

        private void UpdateAAQuality(int quality)
        {
            HDAdditionalCameraData hdCamera = GetComponent<HDAdditionalCameraData>();
            hdCamera.SMAAQuality = (SMAAQualityLevel)quality;
        }
    }
}
