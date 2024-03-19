
using System.Collections.Generic;
using Studio23.SS2.Settings.Video.Core;
using Studio23.SS2.Settings.Video.Samples;
using UnityEngine;

public class GrapicsUI : MonoBehaviour
{

    [SerializeField] private LoopedStepper _preset;
    [SerializeField] private LoopedStepper _shadowStepper;
    [SerializeField] private LoopedStepper _shadowResolution;
    [SerializeField] private LoopedStepper _textureQuality;
    [SerializeField] private LoopedStepper _bloom;
    [SerializeField] private LoopedStepper _ambientOcclusion;

    void Start()
    {
        InitializeUI();
    }

    private void InitializeUI()
    {
        _preset.InitializeData(new List<string>() { "High", "Medium", "Low", "Custom" });
        _preset.SelectedIndexUpdated.AddListener(VideoSettingsManager.Instance.GraphicsController.ChangeQualitySetting);

        _shadowStepper.InitializeData(VideoSettingsManager.Instance.GraphicsController.GetShadowType());
        _shadowStepper.SelectedIndexUpdated.AddListener(VideoSettingsManager.Instance.GraphicsController.ChangeShadowType);

        _shadowResolution.InitializeData(VideoSettingsManager.Instance.GraphicsController.GetShadowResolutions());
        _shadowResolution.SelectedIndexUpdated.AddListener(VideoSettingsManager.Instance.GraphicsController.ChangeShadowResolution);

        _textureQuality.InitializeData(new List<string>() { "Full", "Half", "Quarter", "Eighth" });
        _textureQuality.SelectedIndexUpdated.AddListener(VideoSettingsManager.Instance.GraphicsController.ChangeTextureQuality);

        _bloom.InitializeData(new List<string>() { "Off", "On" });
        _bloom.SelectedIndexUpdated.AddListener(VideoSettingsManager.Instance.GraphicsController.SetBloomState);

        _ambientOcclusion.InitializeData(new List<string>() { "Off", "On" });
        _ambientOcclusion.SelectedIndexUpdated.AddListener(VideoSettingsManager.Instance.GraphicsController.SetAmbientOcculsionState);

    }
}
