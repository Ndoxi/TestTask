using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TT.Core.UI
{
    public class LevelSelectView : MonoBehaviour
    {
        public event System.Action OnAddLevel;
        public event System.Action OnRemoveLevel;

        [SerializeField] private LevelSelectUI _levelPrefab;
        [SerializeField] private ScrollRect _levelsSelector;
        [SerializeField] private GridLayoutGroup _gridLayoutGroup;
        [SerializeField] private Button _addButton;
        [SerializeField] private Button _removeButton;
        private Dictionary<int, LevelSelectUI> _levels;

        private void Awake()
        {
            _levels = new Dictionary<int, LevelSelectUI>();
        }

        private void OnEnable()
        {
            _addButton.onClick.AddListener(OnAddLevelClick);
            _removeButton.onClick.AddListener(OnRemoveLevelClick);
        }

        private void OnDisable()
        {
            _addButton.onClick.RemoveListener(OnAddLevelClick);
            _removeButton.onClick.RemoveListener(OnRemoveLevelClick);
        }

        private void OnAddLevelClick()
        {
            OnAddLevel?.Invoke();
        }

        private void OnRemoveLevelClick()
        {
            OnRemoveLevel?.Invoke();
        }

        public void AddLevel(int levelId)
        {
            if (_levels.ContainsKey(levelId))
            {
                Debug.LogError($"The level selector view already contains a level with id:{levelId}");
                return;
            }

            LevelSelectUI level = Instantiate(_levelPrefab, _levelsSelector.content);
            level.Initialize(levelId);
            _levels.Add(level.LevelId, level);
            ScrollToBottom();
        }

        public void RemoveLevel(int levelId)
        {
            if (!_levels.TryGetValue(levelId, out LevelSelectUI level))
            {
                Debug.LogError($"The level selector view doesn't contains a level with id:{levelId}");
                return;
            }

            Destroy(level.gameObject);
            _levels.Remove(levelId);
            ScrollToBottom();
        }

        private void ScrollToBottom()
        {
            Canvas.ForceUpdateCanvases();
            _gridLayoutGroup.enabled = false;
            _gridLayoutGroup.enabled = true;
            _levelsSelector.normalizedPosition = new Vector2(0, 0);
        }
    }
}