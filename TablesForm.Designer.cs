namespace CTranslator
{
    partial class TablesForm
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
            this.lblLexemTable = new System.Windows.Forms.Label();
            this.dgvLexems = new System.Windows.Forms.DataGridView();
            this.LexemValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LexemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSpecialWords = new System.Windows.Forms.Label();
            this.dgvSpecialWords = new System.Windows.Forms.DataGridView();
            this.SpecialWordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDelimiters = new System.Windows.Forms.Label();
            this.dgvDelimiters = new System.Windows.Forms.DataGridView();
            this.DelimiterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delimiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLiterals = new System.Windows.Forms.Label();
            this.dgvLiterals = new System.Windows.Forms.DataGridView();
            this.LiteralID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Literal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblIdentifiers = new System.Windows.Forms.Label();
            this.dgvIdentifiers = new System.Windows.Forms.DataGridView();
            this.IdentifierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLexems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecialWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelimiters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiterals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentifiers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLexemTable
            // 
            this.lblLexemTable.AutoSize = true;
            this.lblLexemTable.Location = new System.Drawing.Point(86, 9);
            this.lblLexemTable.Name = "lblLexemTable";
            this.lblLexemTable.Size = new System.Drawing.Size(123, 15);
            this.lblLexemTable.TabIndex = 0;
            this.lblLexemTable.Text = "Таблица 0 - Лексемы";
            // 
            // dgvLexems
            // 
            this.dgvLexems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLexems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LexemValue,
            this.LexemType});
            this.dgvLexems.Location = new System.Drawing.Point(0, 29);
            this.dgvLexems.Name = "dgvLexems";
            this.dgvLexems.RowTemplate.Height = 25;
            this.dgvLexems.Size = new System.Drawing.Size(256, 543);
            this.dgvLexems.TabIndex = 1;
            // 
            // LexemValue
            // 
            this.LexemValue.HeaderText = "Лексема";
            this.LexemValue.Name = "LexemValue";
            this.LexemValue.ReadOnly = true;
            // 
            // LexemType
            // 
            this.LexemType.HeaderText = "Предварительный тип";
            this.LexemType.Name = "LexemType";
            this.LexemType.ReadOnly = true;
            this.LexemType.Width = 110;
            // 
            // lblSpecialWords
            // 
            this.lblSpecialWords.AutoSize = true;
            this.lblSpecialWords.Location = new System.Drawing.Point(311, 9);
            this.lblSpecialWords.Name = "lblSpecialWords";
            this.lblSpecialWords.Size = new System.Drawing.Size(166, 15);
            this.lblSpecialWords.TabIndex = 2;
            this.lblSpecialWords.Text = "Таблица 1 - Ключевые слова";
            // 
            // dgvSpecialWords
            // 
            this.dgvSpecialWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpecialWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SpecialWordID,
            this.SpecialWord});
            this.dgvSpecialWords.Location = new System.Drawing.Point(270, 27);
            this.dgvSpecialWords.Name = "dgvSpecialWords";
            this.dgvSpecialWords.RowTemplate.Height = 25;
            this.dgvSpecialWords.Size = new System.Drawing.Size(256, 263);
            this.dgvSpecialWords.TabIndex = 3;
            // 
            // SpecialWordID
            // 
            this.SpecialWordID.HeaderText = "№";
            this.SpecialWordID.Name = "SpecialWordID";
            this.SpecialWordID.ReadOnly = true;
            // 
            // SpecialWord
            // 
            this.SpecialWord.HeaderText = "Ключевое слово";
            this.SpecialWord.Name = "SpecialWord";
            this.SpecialWord.ReadOnly = true;
            // 
            // lblDelimiters
            // 
            this.lblDelimiters.AutoSize = true;
            this.lblDelimiters.Location = new System.Drawing.Point(311, 304);
            this.lblDelimiters.Name = "lblDelimiters";
            this.lblDelimiters.Size = new System.Drawing.Size(142, 15);
            this.lblDelimiters.TabIndex = 4;
            this.lblDelimiters.Text = "Таблица 2 - Разделители";
            // 
            // dgvDelimiters
            // 
            this.dgvDelimiters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelimiters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DelimiterID,
            this.Delimiter});
            this.dgvDelimiters.Location = new System.Drawing.Point(270, 322);
            this.dgvDelimiters.Name = "dgvDelimiters";
            this.dgvDelimiters.RowTemplate.Height = 25;
            this.dgvDelimiters.Size = new System.Drawing.Size(249, 250);
            this.dgvDelimiters.TabIndex = 5;
            // 
            // DelimiterID
            // 
            this.DelimiterID.HeaderText = "№";
            this.DelimiterID.Name = "DelimiterID";
            this.DelimiterID.ReadOnly = true;
            // 
            // Delimiter
            // 
            this.Delimiter.HeaderText = "Разделитель";
            this.Delimiter.Name = "Delimiter";
            this.Delimiter.ReadOnly = true;
            // 
            // lblLiterals
            // 
            this.lblLiterals.AutoSize = true;
            this.lblLiterals.Location = new System.Drawing.Point(590, 9);
            this.lblLiterals.Name = "lblLiterals";
            this.lblLiterals.Size = new System.Drawing.Size(128, 15);
            this.lblLiterals.TabIndex = 6;
            this.lblLiterals.Text = "Таблица 3 - Литералы";
            // 
            // dgvLiterals
            // 
            this.dgvLiterals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiterals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LiteralID,
            this.Literal});
            this.dgvLiterals.Location = new System.Drawing.Point(541, 27);
            this.dgvLiterals.Name = "dgvLiterals";
            this.dgvLiterals.RowTemplate.Height = 25;
            this.dgvLiterals.Size = new System.Drawing.Size(256, 263);
            this.dgvLiterals.TabIndex = 7;
            // 
            // LiteralID
            // 
            this.LiteralID.HeaderText = "№";
            this.LiteralID.Name = "LiteralID";
            this.LiteralID.ReadOnly = true;
            // 
            // Literal
            // 
            this.Literal.HeaderText = "Литерал";
            this.Literal.Name = "Literal";
            this.Literal.ReadOnly = true;
            // 
            // lblIdentifiers
            // 
            this.lblIdentifiers.AutoSize = true;
            this.lblIdentifiers.Location = new System.Drawing.Point(590, 304);
            this.lblIdentifiers.Name = "lblIdentifiers";
            this.lblIdentifiers.Size = new System.Drawing.Size(169, 15);
            this.lblIdentifiers.TabIndex = 8;
            this.lblIdentifiers.Text = "Таблица 5 - Идентификаторы";
            // 
            // dgvIdentifiers
            // 
            this.dgvIdentifiers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIdentifiers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdentifierID,
            this.Identifier});
            this.dgvIdentifiers.Location = new System.Drawing.Point(541, 322);
            this.dgvIdentifiers.Name = "dgvIdentifiers";
            this.dgvIdentifiers.RowTemplate.Height = 25;
            this.dgvIdentifiers.Size = new System.Drawing.Size(256, 250);
            this.dgvIdentifiers.TabIndex = 9;
            // 
            // IdentifierID
            // 
            this.IdentifierID.HeaderText = "№";
            this.IdentifierID.Name = "IdentifierID";
            this.IdentifierID.ReadOnly = true;
            // 
            // Identifier
            // 
            this.Identifier.HeaderText = "Идентификатор";
            this.Identifier.Name = "Identifier";
            this.Identifier.ReadOnly = true;
            // 
            // TablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 574);
            this.Controls.Add(this.dgvIdentifiers);
            this.Controls.Add(this.lblIdentifiers);
            this.Controls.Add(this.dgvLiterals);
            this.Controls.Add(this.lblLiterals);
            this.Controls.Add(this.dgvDelimiters);
            this.Controls.Add(this.lblDelimiters);
            this.Controls.Add(this.dgvSpecialWords);
            this.Controls.Add(this.lblSpecialWords);
            this.Controls.Add(this.dgvLexems);
            this.Controls.Add(this.lblLexemTable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TablesForm";
            this.Text = "Таблицы символов";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLexems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpecialWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelimiters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiterals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIdentifiers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblLexemTable;
        private DataGridView dgvLexems;
        private DataGridViewTextBoxColumn LexemValue;
        private DataGridViewTextBoxColumn LexemType;
        private Label lblSpecialWords;
        private DataGridView dgvSpecialWords;
        private Label lblDelimiters;
        private DataGridView dgvDelimiters;
        private Label lblLiterals;
        private DataGridView dgvLiterals;
        private Label lblIdentifiers;
        private DataGridView dgvIdentifiers;
        private DataGridViewTextBoxColumn SpecialWordID;
        private DataGridViewTextBoxColumn SpecialWord;
        private DataGridViewTextBoxColumn DelimiterID;
        private DataGridViewTextBoxColumn Delimiter;
        private DataGridViewTextBoxColumn LiteralID;
        private DataGridViewTextBoxColumn Literal;
        private DataGridViewTextBoxColumn IdentifierID;
        private DataGridViewTextBoxColumn Identifier;
    }
}