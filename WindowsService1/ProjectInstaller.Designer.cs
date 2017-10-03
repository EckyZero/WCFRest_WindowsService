namespace WindowsService1
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.ServiceProcess.ServiceProcessInstaller DMServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller DMServiceInstaller;

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
            this.DMServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.DMServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // DMServiceProcessInstaller
            // 
            this.DMServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.DMServiceProcessInstaller.Password = null;
            this.DMServiceProcessInstaller.Username = null;
            // 
            // DMServiceInstaller
            // 
            this.DMServiceInstaller.Description = "Provides an API for Swing Suite applications to share session and game data (v1.0" +
    ".0).";
            this.DMServiceInstaller.ServiceName = "TEST Student Host Window Service";
            this.DMServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
                this.DMServiceProcessInstaller,
                this.DMServiceInstaller
            });
        }

        #endregion
    }
}