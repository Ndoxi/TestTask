using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TT.Core.UI
{
    public class LevelScreenController : MonoBehaviour
    {
        [SerializeField] private Button _backToMainMenuButton;
        [SerializeField] private Canvas _levelSelectCanvas;
        [SerializeField] private LevelSelectView _levelSelectView;
        private LevelSelectModel _levelSelectModel;

        private void Awake()
        {
            _levelSelectModel = new LevelSelectModel();
        }

        private void OnEnable()
        {
            _backToMainMenuButton.onClick.AddListener(ShowMainMenu);
            _levelSelectView.OnAddLevel += OnLevelAddUIEvent;
            _levelSelectView.OnRemoveLevel += OnLevelRemoveUIEvent;
            _levelSelectModel.LevelAdded += OnModelAddUpdate;
            _levelSelectModel.LevelRemoved += OnModelRemoveUpdate;
        }

        private void OnDisable()
        {
            _backToMainMenuButton.onClick.RemoveListener(ShowMainMenu);
            _levelSelectView.OnAddLevel -= OnLevelAddUIEvent;
            _levelSelectView.OnRemoveLevel -= OnLevelRemoveUIEvent;
            _levelSelectModel.LevelAdded -= OnModelAddUpdate;
            _levelSelectModel.LevelRemoved -= OnModelRemoveUpdate;
        }

        private void ShowMainMenu()
        {
            _levelSelectCanvas.enabled = false;
        }

        private void OnLevelAddUIEvent() 
        {
            _levelSelectModel.AddLevel();
        }

        private void OnLevelRemoveUIEvent() 
        {
            _levelSelectModel.RemoveLevel();
        }

        private void OnModelAddUpdate(int levelId)
        {
            _levelSelectView.AddLevel(levelId);
        }

        private void OnModelRemoveUpdate(int levelId)
        {
            _levelSelectView.RemoveLevel(levelId);
        }
    }
}