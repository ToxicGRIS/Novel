using Naninovel;
using Naninovel.UI;
using TMPro;
using UnityEngine;

namespace Nani.UI
{
    public class ActiveQuestUI : CustomUI
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        private ITextManager _textManager;
        private string _currentKey = "none";
        private string _currentCategory = ManagedTextRecord.DefaultCategoryName;
        private LocalizationManager _localizationManager;

        protected override void Awake()
        {
            base.Awake();
            _textManager = Engine.GetService<ITextManager>();
            _localizationManager = Engine.GetService<LocalizationManager>();
            _localizationManager.OnLocaleChanged += s => SetText(_currentKey, _currentCategory);
            SetText(_currentKey, _currentCategory);
        }

        public void SetText(string key, string category = ManagedTextRecord.DefaultCategoryName)
        {
            Debug.Log($"___Quest text: {key} : {category}");
            _currentKey = key;
            _currentCategory = category;
            _text.gameObject.SetActive(key != "none");
            _text.text = _textManager.GetRecordValue(key, category);
        }
    }
}