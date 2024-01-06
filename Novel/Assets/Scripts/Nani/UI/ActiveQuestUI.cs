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

        protected override void Awake()
        {
            base.Awake();
            _textManager = Engine.GetService<ITextManager>();
        }

        public void SetText(string key, string category = ManagedTextRecord.DefaultCategoryName)
        {
            Debug.Log($"___Quest text: {key}");
            _text.gameObject.SetActive(key != "none");
            _text.text = _textManager.GetRecordValue(key, category);
        }
    }
}