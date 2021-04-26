using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestAsset", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class TestAsset : ScriptableObject
{internal const float DEFAULT_DEFAULT_MIX = 0.2f;
        public float defaultMix = DEFAULT_DEFAULT_MIX;

        internal const string DEFAULT_DEFAULT_SHADER = "Spine/Skeleton";
        public string defaultShader = DEFAULT_DEFAULT_SHADER;

        internal const float DEFAULT_DEFAULT_ZSPACING = 0f;
        public float defaultZSpacing = DEFAULT_DEFAULT_ZSPACING;

        internal const bool DEFAULT_DEFAULT_INSTANTIATE_LOOP = true;
        public bool defaultInstantiateLoop = DEFAULT_DEFAULT_INSTANTIATE_LOOP;

        internal const bool DEFAULT_SHOW_HIERARCHY_ICONS = true;
        public bool showHierarchyIcons = DEFAULT_SHOW_HIERARCHY_ICONS;

        internal const bool DEFAULT_SET_TEXTUREIMPORTER_SETTINGS = true;
        public bool setTextureImporterSettings = DEFAULT_SET_TEXTUREIMPORTER_SETTINGS;

        internal const string DEFAULT_TEXTURE_SETTINGS_REFERENCE = "";
        public string textureSettingsReference = DEFAULT_TEXTURE_SETTINGS_REFERENCE;

        internal const bool DEFAULT_ATLASTXT_WARNING = true;
        public bool atlasTxtImportWarning = DEFAULT_ATLASTXT_WARNING;

        internal const bool DEFAULT_TEXTUREIMPORTER_WARNING = true;
        public bool textureImporterWarning = DEFAULT_TEXTUREIMPORTER_WARNING;

        public const float DEFAULT_MIPMAPBIAS = -0.5f;

        public const bool DEFAULT_AUTO_RELOAD_SCENESKELETONS = true;
        public bool autoReloadSceneSkeletons = DEFAULT_AUTO_RELOAD_SCENESKELETONS;

        public const string SCENE_ICONS_SCALE_KEY = "SPINE_SCENE_ICONS_SCALE";
        internal const float DEFAULT_SCENE_ICONS_SCALE = 1f;

        [Range(0.01f, 2f)]
        public float handleScale = DEFAULT_SCENE_ICONS_SCALE;

        public const bool DEFAULT_MECANIM_EVENT_INCLUDE_FOLDERNAME = true;
        public bool mecanimEventIncludeFolderName = DEFAULT_MECANIM_EVENT_INCLUDE_FOLDERNAME;

        // Timeline extension module
        public const bool DEFAULT_TIMELINE_USE_BLEND_DURATION = true;
        public bool timelineUseBlendDuration = DEFAULT_TIMELINE_USE_BLEND_DURATION;
}
