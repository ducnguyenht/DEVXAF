namespace NamolyOnPremises.Module.Controllers.Hotel.Booking
{
    partial class HotelBookingVC
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
            this.HotelFolioPost = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.HotelFolioCancel = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // HotelFolioPost
            // 
            this.HotelFolioPost.Caption = "Post";
            this.HotelFolioPost.Category = "HotelBooking_HotelFolio_Post";
            this.HotelFolioPost.ConfirmationMessage = null;
            this.HotelFolioPost.Id = "@HotelFolioPost";
            this.HotelFolioPost.IsExecuting = false;
            this.HotelFolioPost.ToolTip = null;
            this.HotelFolioPost.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.HotelFolioPost_Execute);
            // 
            // HotelFolioCancel
            // 
            this.HotelFolioCancel.Caption = "Cancel";
            this.HotelFolioCancel.Category = "HotelBooking_HotelFolio_Cancel";
            this.HotelFolioCancel.ConfirmationMessage = null;
            this.HotelFolioCancel.Id = "@HotelFolioCancel";
            this.HotelFolioCancel.IsExecuting = false;
            this.HotelFolioCancel.ToolTip = null;
            this.HotelFolioCancel.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.HotelFolioCancel_Execute);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction HotelFolioPost;
        private DevExpress.ExpressApp.Actions.SimpleAction HotelFolioCancel;
    }
}
