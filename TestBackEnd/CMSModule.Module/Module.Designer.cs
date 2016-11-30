namespace CMSModule.Module {
	partial class CMSModuleModule {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            // 
            // CMSModuleModule
            // 
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.BaseObject));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileData));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.FileAttachmentBase));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.OidGenerator));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Xpo.XPBaseObject));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Xpo.PersistentBase));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.ServerPrefix));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Xpo.XPObject));
            this.AdditionalExportedTypes.Add(typeof(DevExpress.Xpo.XPCustomObject));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.HtmlPropertyEditor.Web.HtmlPropertyEditorAspNetModule));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule));

		}

		#endregion
	}
}
