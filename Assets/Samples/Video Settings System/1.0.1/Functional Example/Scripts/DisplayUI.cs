
using System.Collections.Generic;
using Studio23.SS2.Settings.Video.Core;
using UnityEngine;

namespace Studio23.SS2.Settings.Video.Samples
{
    public class DisplayUI : MonoBehaviour
    {
        [SerializeField] private LoopedStepper _Resolutionstepper;
        [SerializeField] private LoopedStepper _displayModeStepper;
        [SerializeField] private LoopedStepper _vSyncStepper;

        void Start()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            _Resolutionstepper.InitializeData(VideoSettingsManager.Instance.DisplayController.GetSupportedResolutions(), VideoSettingsManager.Instance.DisplayController.GetSelectedResolutionIndex());
            _Resolutionstepper.SelectedIndexUpdated.AddListener(VideoSettingsManager.Instance.DisplayController.ChangeResolution);
            
            _displayModeStepper.InitializeData(VideoSettingsManager.Instance.DisplayController.GetFullScreenModes());
            _displayModeStepper.SelectedIndexUpdated.AddListener(VideoSettingsManager.Instance.DisplayController.ChangeFullScreenMode);
            
            _vSyncStepper.InitializeData(new List<string>() { "Off", "On", "Every 2nd V-Blank" });
            _vSyncStepper.SelectedIndexUpdated.AddListener(VideoSettingsManager.Instance.DisplayController.ChangeVSync);
        }
    }
}

