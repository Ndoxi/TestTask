using System;
using System.Collections.Generic;

namespace TT.Core.UI
{
    public class LevelSelectModel
    {
        public event Action<int> LevelAdded;
        public event Action<int> LevelRemoved;
        private int _levelCount;

        public void AddLevel()
        {
            LevelAdded?.Invoke(_levelCount++);
        }

        public void RemoveLevel()
        {
            if (_levelCount > 0)
            {
                LevelRemoved?.Invoke(--_levelCount);
            }
        }
    }
}