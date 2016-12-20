namespace Book.UI.Settings.BasicData
{
    partial class BaseEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEditForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItemUndo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNew = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemFirst = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrev = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNext = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLast = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAudit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonitemAllAttachment = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemSave,
            this.barButtonItemUndo,
            this.barButtonItemNew,
            this.barButtonItemUpdate,
            this.barButtonItemPrev,
            this.barButtonItemNext,
            this.barButtonItemPrint,
            this.barButtonItemDelete,
            this.barButtonItemFirst,
            this.barButtonItemLast,
            this.barButtonItemAudit,
            this.barButtonitemAllAttachment});
            this.barManager1.MaxItemId = 15;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarItemVertIndent = 6;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemUpdate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemFirst, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemPrev, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemNext, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemLast, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemAudit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonitemAllAttachment, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar1, "bar1");
            // 
            // barButtonItemUndo
            // 
            this.barButtonItemUndo.AccessibleDescription = null;
            this.barButtonItemUndo.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemUndo, "barButtonItemUndo");
            this.barButtonItemUndo.Id = 0;
            this.barButtonItemUndo.ImageIndex = 15;
            this.barButtonItemUndo.Name = "barButtonItemUndo";
            this.barButtonItemUndo.Tag = "undo";
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.AccessibleDescription = null;
            this.barButtonItemSave.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemSave, "barButtonItemSave");
            this.barButtonItemSave.Id = 1;
            this.barButtonItemSave.ImageIndex = 0;
            this.barButtonItemSave.Name = "barButtonItemSave";
            this.barButtonItemSave.Tag = "save";
            // 
            // barButtonItemNew
            // 
            this.barButtonItemNew.AccessibleDescription = null;
            this.barButtonItemNew.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemNew, "barButtonItemNew");
            this.barButtonItemNew.Id = 3;
            this.barButtonItemNew.ImageIndex = 5;
            this.barButtonItemNew.Name = "barButtonItemNew";
            this.barButtonItemNew.Tag = "new";
            // 
            // barButtonItemUpdate
            // 
            this.barButtonItemUpdate.AccessibleDescription = null;
            this.barButtonItemUpdate.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemUpdate, "barButtonItemUpdate");
            this.barButtonItemUpdate.Id = 4;
            this.barButtonItemUpdate.ImageIndex = 4;
            this.barButtonItemUpdate.Name = "barButtonItemUpdate";
            this.barButtonItemUpdate.Tag = "update";
            // 
            // barButtonItemDelete
            // 
            this.barButtonItemDelete.AccessibleDescription = null;
            this.barButtonItemDelete.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemDelete, "barButtonItemDelete");
            this.barButtonItemDelete.Id = 9;
            this.barButtonItemDelete.ImageIndex = 2;
            this.barButtonItemDelete.Name = "barButtonItemDelete";
            this.barButtonItemDelete.Tag = "delete";
            // 
            // barButtonItemFirst
            // 
            this.barButtonItemFirst.AccessibleDescription = null;
            this.barButtonItemFirst.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemFirst, "barButtonItemFirst");
            this.barButtonItemFirst.Id = 11;
            this.barButtonItemFirst.ImageIndex = 10;
            this.barButtonItemFirst.Name = "barButtonItemFirst";
            this.barButtonItemFirst.Tag = "first";
            // 
            // barButtonItemPrev
            // 
            this.barButtonItemPrev.AccessibleDescription = null;
            this.barButtonItemPrev.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemPrev, "barButtonItemPrev");
            this.barButtonItemPrev.Id = 5;
            this.barButtonItemPrev.ImageIndex = 7;
            this.barButtonItemPrev.Name = "barButtonItemPrev";
            this.barButtonItemPrev.Tag = "prev";
            // 
            // barButtonItemNext
            // 
            this.barButtonItemNext.AccessibleDescription = null;
            this.barButtonItemNext.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemNext, "barButtonItemNext");
            this.barButtonItemNext.Id = 6;
            this.barButtonItemNext.ImageIndex = 6;
            this.barButtonItemNext.Name = "barButtonItemNext";
            this.barButtonItemNext.Tag = "next";
            // 
            // barButtonItemLast
            // 
            this.barButtonItemLast.AccessibleDescription = null;
            this.barButtonItemLast.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemLast, "barButtonItemLast");
            this.barButtonItemLast.Id = 12;
            this.barButtonItemLast.ImageIndex = 11;
            this.barButtonItemLast.Name = "barButtonItemLast";
            this.barButtonItemLast.Tag = "last";
            // 
            // barButtonItemAudit
            // 
            this.barButtonItemAudit.AccessibleDescription = null;
            this.barButtonItemAudit.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemAudit, "barButtonItemAudit");
            this.barButtonItemAudit.Id = 13;
            this.barButtonItemAudit.ImageIndex = 0;
            this.barButtonItemAudit.Name = "barButtonItemAudit";
            this.barButtonItemAudit.Tag = "Audit";
            // 
            // barButtonItemPrint
            // 
            this.barButtonItemPrint.AccessibleDescription = null;
            this.barButtonItemPrint.AccessibleName = null;
            resources.ApplyResources(this.barButtonItemPrint, "barButtonItemPrint");
            this.barButtonItemPrint.Id = 8;
            this.barButtonItemPrint.ImageIndex = 8;
            this.barButtonItemPrint.Name = "barButtonItemPrint";
            this.barButtonItemPrint.Tag = "print";
            this.barButtonItemPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPrint_ItemClick);
            // 
            // barButtonitemAllAttachment
            // 
            this.barButtonitemAllAttachment.AccessibleDescription = null;
            this.barButtonitemAllAttachment.AccessibleName = null;
            resources.ApplyResources(this.barButtonitemAllAttachment, "barButtonitemAllAttachment");
            this.barButtonitemAllAttachment.Id = 14;
            this.barButtonitemAllAttachment.ImageIndex = 13;
            this.barButtonitemAllAttachment.Name = "barButtonitemAllAttachment";
            this.barButtonitemAllAttachment.Tag = "Attachment";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.AccessibleDescription = null;
            this.barDockControlTop.AccessibleName = null;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlTop.Appearance.GradientMode")));
            this.barDockControlTop.Appearance.Image = null;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Font = null;
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.AccessibleDescription = null;
            this.barDockControlBottom.AccessibleName = null;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlBottom.Appearance.GradientMode")));
            this.barDockControlBottom.Appearance.Image = null;
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Font = null;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.AccessibleDescription = null;
            this.barDockControlLeft.AccessibleName = null;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlLeft.Appearance.GradientMode")));
            this.barDockControlLeft.Appearance.Image = null;
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Font = null;
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.AccessibleDescription = null;
            this.barDockControlRight.AccessibleName = null;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlRight.Appearance.GradientMode")));
            this.barDockControlRight.Appearance.Image = null;
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Font = null;
            // 
            // imageCollection1
            // 
            resources.ApplyResources(this.imageCollection1, "imageCollection1");
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // BaseEditForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.Name = "BaseEditForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.BaseEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barButtonItemUndo;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSave;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPrev;
        private DevExpress.XtraBars.BarButtonItem barButtonItemNext;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLast;
        protected DevExpress.XtraBars.BarManager barManager1;
        protected DevExpress.Utils.ImageCollection imageCollection1;
        protected DevExpress.XtraBars.BarButtonItem barButtonItemFirst;
        protected DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAudit;
        protected DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonitemAllAttachment;
        protected DevExpress.XtraBars.BarButtonItem barButtonItemNew;


    }
}