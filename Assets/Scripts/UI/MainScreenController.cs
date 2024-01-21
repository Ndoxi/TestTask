using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TT.Core.UI
{
    public class MainScreenController : MonoBehaviour
    {
        [SerializeField] private Button _levelSelectButton;
        [SerializeField] private Canvas _levelSelectCanvas;

        private void OnEnable()
        {
            _levelSelectButton.onClick.AddListener(ShowLevelSelect);
        }

        private void OnDisable()
        {
            _levelSelectButton.onClick.RemoveListener(ShowLevelSelect);
        }

        private void ShowLevelSelect()
        {
            //Move to the views if more complex behaviour required!
            _levelSelectCanvas.enabled = true;
        }
    }
}