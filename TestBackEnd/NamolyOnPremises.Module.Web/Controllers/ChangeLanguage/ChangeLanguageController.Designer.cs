namespace NamolyOnPremises.Module.Web.Controllers.ChangeLanguage
{
    partial class ChangeLanguageController
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ChooseLanguage = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // ChooseLanguage
            // 
            this.ChooseLanguage.Caption = "Choose Language";
            this.ChooseLanguage.Category = "Search";
            this.ChooseLanguage.ConfirmationMessage = null;
            this.ChooseLanguage.Id = "@ChooseLanguage";
            this.ChooseLanguage.IsExecuting = false;
            this.ChooseLanguage.ToolTip = null;
            this.ChooseLanguage.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.ChooseLanguage_Execute);
            // 
            // ChangeLanguageController
            // 
            this.Activated += new System.EventHandler(this.ChangeLanguageController_Activated);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction ChooseLanguage;
    }
}
