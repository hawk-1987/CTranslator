namespace CTranslator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.mFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mFileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.mPerform = new System.Windows.Forms.ToolStripMenuItem();
            this.mTranslateSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mTables = new System.Windows.Forms.ToolStripMenuItem();
            this.lstErrors = new System.Windows.Forms.ListBox();
            this.edtCode = new System.Windows.Forms.RichTextBox();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFile,
            this.mTranslate});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // mFile
            // 
            this.mFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOpen,
            this.mSave,
            this.mFileSeparator,
            this.mExit});
            this.mFile.Name = "mFile";
            this.mFile.Size = new System.Drawing.Size(48, 20);
            this.mFile.Text = "Файл";
            // 
            // mOpen
            // 
            this.mOpen.Name = "mOpen";
            this.mOpen.Size = new System.Drawing.Size(133, 22);
            this.mOpen.Text = "Открыть";
            this.mOpen.Click += new System.EventHandler(this.mOpen_Click);
            // 
            // mSave
            // 
            this.mSave.Name = "mSave";
            this.mSave.Size = new System.Drawing.Size(133, 22);
            this.mSave.Text = "Сохранить";
            this.mSave.Click += new System.EventHandler(this.mSave_Click);
            // 
            // mFileSeparator
            // 
            this.mFileSeparator.Name = "mFileSeparator";
            this.mFileSeparator.Size = new System.Drawing.Size(130, 6);
            // 
            // mExit
            // 
            this.mExit.Name = "mExit";
            this.mExit.Size = new System.Drawing.Size(133, 22);
            this.mExit.Text = "Выход";
            this.mExit.Click += new System.EventHandler(this.mExit_Click);
            // 
            // mTranslate
            // 
            this.mTranslate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mPerform,
            this.mTranslateSeparator,
            this.mTables});
            this.mTranslate.Name = "mTranslate";
            this.mTranslate.Size = new System.Drawing.Size(84, 20);
            this.mTranslate.Text = "Трансляция";
            // 
            // mPerform
            // 
            this.mPerform.Name = "mPerform";
            this.mPerform.Size = new System.Drawing.Size(181, 22);
            this.mPerform.Text = "Выполнить";
            this.mPerform.Click += new System.EventHandler(this.mPerform_Click);
            // 
            // mTranslateSeparator
            // 
            this.mTranslateSeparator.Name = "mTranslateSeparator";
            this.mTranslateSeparator.Size = new System.Drawing.Size(178, 6);
            // 
            // mTables
            // 
            this.mTables.Name = "mTables";
            this.mTables.Size = new System.Drawing.Size(181, 22);
            this.mTables.Text = "Таблицы символов";
            this.mTables.Click += new System.EventHandler(this.mTables_Click);
            // 
            // lstErrors
            // 
            this.lstErrors.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstErrors.FormattingEnabled = true;
            this.lstErrors.ItemHeight = 15;
            this.lstErrors.Location = new System.Drawing.Point(0, 356);
            this.lstErrors.Name = "lstErrors";
            this.lstErrors.Size = new System.Drawing.Size(800, 94);
            this.lstErrors.TabIndex = 1;
            // 
            // edtCode
            // 
            this.edtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtCode.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.edtCode.Location = new System.Drawing.Point(0, 24);
            this.edtCode.Name = "edtCode";
            this.edtCode.Size = new System.Drawing.Size(800, 332);
            this.edtCode.TabIndex = 2;
            this.edtCode.Text = "";
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "Файлы языка C|*.c";
            // 
            // dlgSave
            // 
            this.dlgSave.Filter = "Файлы языка C|*.c";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.edtCode);
            this.Controls.Add(this.lstErrors);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Трансляция с подмножества языка С";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MainMenu;
        private ToolStripMenuItem mFile;
        private ToolStripMenuItem mOpen;
        private ToolStripMenuItem mSave;
        private ToolStripSeparator mFileSeparator;
        private ToolStripMenuItem mExit;
        private ToolStripMenuItem mTranslate;
        private ToolStripMenuItem mPerform;
        private ToolStripSeparator mTranslateSeparator;
        private ToolStripMenuItem mTables;
        private ListBox lstErrors;
        private RichTextBox edtCode;
        private OpenFileDialog dlgOpen;
        private SaveFileDialog dlgSave;
    }
}