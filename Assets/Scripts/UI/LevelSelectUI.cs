using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TT.Core.UI
{
    public class LevelSelectUI : MonoBehaviour
    {
        private const string GAME_SCENE_NAME = "World";

        public int LevelId => _levelId;

        [SerializeField] private Button _button;
        private int _levelId;

        public void Initialize(int levelId)
        {
            _levelId = levelId;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            SceneManager.LoadSceneAsync(GAME_SCENE_NAME);
        }
    }
}