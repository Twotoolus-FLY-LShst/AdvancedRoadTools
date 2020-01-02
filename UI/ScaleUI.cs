using ColossalFramework.UI;
using UnityEngine;
using ColossalFramework;
using System;
using ICities;
using ColossalFramework.Plugins;
using Object = UnityEngine.Object;

namespace AdvancedRoadTools.UI
{
    public class ScaleUI : UIPanel
    {
        public static readonly string cacheName = "ScaleUI";
        public AssetImporterAssetImport baseBuildingWindow;
        public static UITextField scaleX;
        public static UITextField scaleY;
        public static UITextField scaleZ;
        private UILabel scaleXLable;
        private UILabel scaleYLable;
        private UILabel scaleZLable;

        public override void Update()
        {
            base.Update();
        }

        public override void Awake()
        {
            base.Awake();
            DoOnStartup();
        }

        public override void Start()
        {
            base.Start();
            size = new Vector2(150, 150);
            relativePosition = new Vector3((Loader.parentGuiView.fixedWidth / 2 + 20f), 50f);
            canFocus = true;
            isInteractive = true;
            isVisible = true;
            opacity = 1f;
            cachedName = cacheName;
        }

        private void DoOnStartup()
        {
            ShowOnGui();
        }

        private void ShowOnGui()
        {
            scaleX = AddUIComponent<UITextField>();
            scaleY = AddUIComponent<UITextField>();
            scaleZ = AddUIComponent<UITextField>();

            scaleXLable = AddUIComponent<UILabel>();
            scaleYLable = AddUIComponent<UILabel>();
            scaleZLable = AddUIComponent<UILabel>();

            int x = 0; int y = 0;
            SetLabel(scaleXLable, "scaleX", x, y);
            SetTextBox(scaleX, "1", x + 120, y);
            y += 40;

            SetLabel(scaleYLable, "scaleY", x, y);
            SetTextBox(scaleY, "1", x + 120, y);
            y += 40;

            SetLabel(scaleZLable, "scaleZ", x, y);
            SetTextBox(scaleZ, "1", x + 120, y);

            Hide();
        }

        private void SetLabel(UILabel pedestrianLabel, string p, int x, int y)
        {
            pedestrianLabel.relativePosition = new Vector3(x, y);
            pedestrianLabel.text = p;
            pedestrianLabel.textScale = 0.8f;
            pedestrianLabel.size = new Vector3(120, 20);
        }

        private void SetTextBox(UITextField scaleTextBox, string p, int x, int y)
        {
            scaleTextBox.relativePosition = new Vector3(x, y - 4);
            scaleTextBox.horizontalAlignment = UIHorizontalAlignment.Left;
            scaleTextBox.text = p;
            scaleTextBox.textScale = 0.8f;
            scaleTextBox.color = Color.black;
            scaleTextBox.cursorBlinkTime = 0.45f;
            scaleTextBox.cursorWidth = 1;
            scaleTextBox.selectionBackgroundColor = new Color(233, 201, 148, 255);
            scaleTextBox.selectionSprite = "EmptySprite";
            scaleTextBox.verticalAlignment = UIVerticalAlignment.Middle;
            scaleTextBox.padding = new RectOffset(5, 0, 5, 0);
            scaleTextBox.foregroundSpriteMode = UIForegroundSpriteMode.Fill;
            scaleTextBox.normalBgSprite = "TextFieldPanel";
            scaleTextBox.hoveredBgSprite = "TextFieldPanelHovered";
            scaleTextBox.focusedBgSprite = "TextFieldPanel";
            scaleTextBox.size = new Vector3(100, 20);
            scaleTextBox.isInteractive = true;
            scaleTextBox.enabled = true;
            scaleTextBox.readOnly = false;
            scaleTextBox.builtinKeyNavigation = true;
        }

        public void OnGUI()
        {
            if (!isVisible)
            {
                UIComponent uIComponent = UIView.Find("ModelImportPanel");
                AssetImporterAssetImport assetImporterAssetImport = (!((Object)uIComponent != (Object)null)) ? null : uIComponent.GetComponent<AssetImporterAssetImport>();
                if ((Object)assetImporterAssetImport != (Object)null)
                {
                    if (assetImporterAssetImport.component.isVisible)
                    {
                        Show();
                    }
                }
                else
                {
                    Hide();
                }
            }
            else
            {
                UIComponent uIComponent = UIView.Find("ModelImportPanel");
                AssetImporterAssetImport assetImporterAssetImport = (!((Object)uIComponent != (Object)null)) ? null : uIComponent.GetComponent<AssetImporterAssetImport>();
                if ((Object)assetImporterAssetImport != (Object)null)
                {
                    if (!assetImporterAssetImport.component.isVisible)
                    {
                        Hide();
                    }
                }
                else
                {
                    Hide();
                }
            }

            if (UIView.HasModalInput() || UIView.HasInputFocus() || !isVisible) return;

            scaleXLable.text = "scaleX";
            scaleYLable.text = "scaleY";
            scaleZLable.text = "scaleZ";
        }
    }
}
