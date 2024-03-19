
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Studio23.SS2.Settings.Video.Samples
{
    public class LoopedStepper : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI DisplayText;
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;
        [SerializeField] private bool _isLive;
        [SerializeField] private int _selectedIndex;
        private IList _data;
        public UnityEvent<int> SelectedIndexUpdated;

        private void Start()
        {
            _leftButton.onClick.AddListener(Left);
            _rightButton.onClick.AddListener(Right);
        }

        public void InitializeData(IList data, int selectIndex = 0)
        {
            _selectedIndex = selectIndex;
            _data = data;
            Apply(false);
        }


        private void ShowText()
        {
            DisplayText.text = _data[_selectedIndex].ToString();
        }

        public void Right()
        {
            if (_selectedIndex < _data.Count - 1)
            {
                _selectedIndex++;
            }
            else
            {
                _selectedIndex = 0;
            }

            Apply();
        }


        public void Left()
        {
            if (_selectedIndex > 0)
            {
                _selectedIndex--;
            }
            else
            {
                _selectedIndex = _data.Count - 1;
            }

            Apply();
        }

        public void Apply(bool checkLiveStatus = true)
        {
            ShowText();
            if (!_isLive) return;
            ApplyAction();
        }

        private void ApplyAction()
        {
            SelectedIndexUpdated?.Invoke(_selectedIndex);
        }
    }
}
