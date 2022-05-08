using System;
using System.Collections.Generic;

    public static class UILoadInfo
    {
        private static Dictionary<Type, UIInfo> UIInfos = new Dictionary<Type, UIInfo>();

        private static void _<T>(EUILoadType euiLoadType, EUILayer euiLayer, string path, EUIPrefabType prefabType)
        {
            Type type = typeof(T);
            string prefabTypeStr = string.Empty;
            
            /*
            switch (prefabType)
            {
                case EUIPrefabType.View:
                    prefabTypeStr = PathUtil.UIViewPrefabs;
                    break;
                case EUIPrefabType.Components:
                    prefabTypeStr = PathUtil.UIComponentPrefabs;
                    break;
                case EUIPrefabType.Other:
                    prefabTypeStr = PathUtil.UIPrefabs;
                    break;
            }
            */

            UIInfos.Add(type,
                new UIInfo(type, euiLoadType == EUILoadType.Single, euiLayer,
                    prefabTypeStr + path));
        }

        static UILoadInfo()
        {
            _<UnityViewImp>(EUILoadType.Single, EUILayer.Splash, "/TestView", EUIPrefabType.View);
        }

        public static UIInfo GetUIInfo<T>()
        {
            return GetUIInfo(typeof(T));
        }

        public static UIInfo GetUIInfo(Type type)
        {
            if (UIInfos.ContainsKey(type))
            {
                return UIInfos[type];
            }

            Contexts.sharedInstance.game.ReplaceLogMsg("未注册");
            return null;
        }
    }

    public enum EUIPrefabType
    {
        View,
        Components,
        Other
    }

    public enum EUILoadType
    {
        Single,
        Mul
    }

    public enum EUILayer
    {
        Splash,
        Main,
        View,
        ViewTop,
        Tips,
        Loading,
        Notice
    }
public class UIInfo
{
    public readonly bool IsSingle;
    public EUILayer EuiLayer;
    public string Path;
    public Type Type;

    public UIInfo(Type type, bool isSingle, EUILayer euiLayer, string path)
    {
        Type = type;
        IsSingle = isSingle;
        EuiLayer = euiLayer;
        Path = path;
    }
}