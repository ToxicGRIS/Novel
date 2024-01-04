using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GRIS.Editor {
    public static class AssemblyPipelineSettings {
        private static bool _isNeedAutoReloading;
        
        private const string _CONFIG_DIRECTORY_NAME = "Config";
        private const string _FILE_NAME = "ReloadDomainButtonConfig";

        private const bool _DEFAULT_VALUE = true;

        [InitializeOnLoadMethod]
        public static void Initialize() => EditorApplication.playModeStateChanged += OnStateChanged;
        
        private static void OnStateChanged(PlayModeStateChange playModeStateChange) {
            if (playModeStateChange != PlayModeStateChange.ExitingPlayMode) return;
            if (!IsEnableReloading(_DEFAULT_VALUE)) return;
            ForceReloading();
        }

    #region Menu

        [MenuItem("Assets/Refresh Assembly", false, 39)]
        public static void ForceReloading() {
            AssetDatabase.RefreshSettings();
            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            AssetDatabase.SaveAssets();
            EditorUtility.RequestScriptReload();
        }

        [MenuItem("Edit/HotKeys/ChangeMaximizeState")]
        public static void ChangeMaximizeState() {
            EditorWindow window = EditorWindow.focusedWindow;
            if (window == null) return;
            window.maximized = !window.maximized;
        }

    #endregion
        
    #region Settings

        [SettingsProvider]
        public static SettingsProvider CreateMyCustomSettingsProvider() {
            SettingsProvider provider = new SettingsProvider("Preferences/Asset Pipeline/Assembly Pipeline", SettingsScope.User);
            
            provider.label = "Assembly Pipeline";
            provider.guiHandler = OnDrawSettings;
            provider.keywords = new HashSet<string>(new[] {"Assembly"});

            _isNeedAutoReloading = IsEnableReloading(_DEFAULT_VALUE);
            
            return provider;
        }

        private static void OnDrawSettings(string obj) {
            bool newValue = EditorGUILayout.Toggle("Auto Reload Assembly", _isNeedAutoReloading);

            if (newValue == _isNeedAutoReloading) return;
            
            _isNeedAutoReloading = newValue;
            SetReloading(newValue);
        }

    #endregion

    #region FileSaves

        private static bool IsEnableReloading(bool defaultValue) {
            string path = Path.Combine(Application.persistentDataPath);
            if (!Directory.Exists(path)) return defaultValue;
            path = Path.Combine(Application.persistentDataPath, _CONFIG_DIRECTORY_NAME);
            if (!Directory.Exists(path)) return defaultValue;
            path = Path.Combine(Application.persistentDataPath, _CONFIG_DIRECTORY_NAME, _FILE_NAME);
            if (!File.Exists(path)) return defaultValue;
            return File.ReadAllBytes(path)[0] == 1;
        }

        private static void SetReloading(bool value) {
            string path = Path.Combine(Application.persistentDataPath);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            path = Path.Combine(Application.persistentDataPath, _CONFIG_DIRECTORY_NAME);
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            path = Path.Combine(Application.persistentDataPath, _CONFIG_DIRECTORY_NAME, _FILE_NAME);
            File.WriteAllBytes(path, new[] {(byte) (value ? 1 : 0)});
        }
        
    #endregion
        
    }
}