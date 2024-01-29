using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using VRC.SDK3.Avatars.Components;
using VRC.SDK3.Avatars.ScriptableObjects;
using VRC.Core;
using nadena.dev.modular_avatar.core;
using System;

namespace net.narazaka.avatarmenucreater
{
    public class AvatarMenuCreaterForMA : EditorWindow
    {
        VRCAvatarDescriptor VRCAvatarDescriptor;
        MenuType MenuType = MenuType.Toggle;
        IncludeAssetType IncludeAssetType = IncludeAssetType.AnimatorAndInclude;

        bool BulkSet;

        AvatarToggleMenu AvatarToggleMenu = new AvatarToggleMenu();
        AvatarChooseMenu AvatarChooseMenu = new AvatarChooseMenu();
        AvatarRadialMenu AvatarRadialMenu = new AvatarRadialMenu();

        string SaveFolder = "Assets";

        [MenuItem("Tools/Modular Avatar/AvatarMenuCreater for Modular Avatar")]
        static void CreateWindow()
        {
            GetWindow<AvatarMenuCreaterForMA>("AvatarMenuCreater for Modular Avatar");
        }

        void Update()
        {
            Repaint();
        }

        void OnGUI()
        {
            VRCAvatarDescriptor = EditorGUILayout.ObjectField("Avatar", VRCAvatarDescriptor, typeof(VRCAvatarDescriptor), true) as VRCAvatarDescriptor;

            if (VRCAvatarDescriptor == null)
            {
                EditorGUILayout.LabelField("対象のアバターを選択して下さい");
                return;
            }

            var gameObjects = Selection.gameObjects;

            if (gameObjects.Length == 0 || (gameObjects.Length == 1 && gameObjects[0] == VRCAvatarDescriptor.gameObject))
            {
                EditorGUILayout.LabelField("対象のオブジェクトを選択して下さい");
                return;
            }

            MenuType = (MenuType)EditorGUILayout.EnumPopup(MenuType);

            if (MenuType == MenuType.Toggle)
            {
                AvatarToggleMenu.OnAvatarMenuGUI(VRCAvatarDescriptor.gameObject, gameObjects);
            }
            else if (MenuType == MenuType.Choose)
            {
                AvatarChooseMenu.OnAvatarMenuGUI(VRCAvatarDescriptor.gameObject, gameObjects);
            }
            else
            {
                AvatarRadialMenu.OnAvatarMenuGUI(VRCAvatarDescriptor.gameObject, gameObjects);
            }

            IncludeAssetType = (IncludeAssetType)EditorGUILayout.EnumPopup("保存形式", IncludeAssetType);
            if (GUILayout.Button("Create!"))
            {
                var basePath = EditorUtility.SaveFilePanelInProject("保存場所", "New Menu", "prefab", "アセットの保存場所", SaveFolder);
                if (string.IsNullOrEmpty(basePath)) return;
                basePath = new System.Text.RegularExpressions.Regex(@"\.prefab").Replace(basePath, "");
                var baseName = System.IO.Path.GetFileNameWithoutExtension(basePath);
                if (MenuType == MenuType.Toggle)
                {
                    AvatarToggleMenu.CreateAssets(IncludeAssetType, VRCAvatarDescriptor.gameObject, baseName, basePath, gameObjects);
                }
                else if (MenuType == MenuType.Choose)
                {
                    AvatarChooseMenu.CreateAssets(IncludeAssetType, VRCAvatarDescriptor.gameObject, baseName, basePath, gameObjects);
                }
                else
                {
                    AvatarRadialMenu.CreateAssets(IncludeAssetType, VRCAvatarDescriptor.gameObject, baseName, basePath, gameObjects);
                }
                SaveFolder = System.IO.Path.GetDirectoryName(basePath);
            }
        }
    }
}
