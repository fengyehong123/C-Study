namespace WindowsFormsStudy
{
    partial class S004_batchLog
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchKbn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jikkouYMD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jikkouResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kousinYMD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kosinCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "バーチ处理履历画面";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.batchKbn,
            this.name,
            this.jikkouYMD,
            this.jikkouResult,
            this.message,
            this.kousinYMD,
            this.kosinCd});
            this.dataGridView1.Location = new System.Drawing.Point(83, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(643, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // id
            // 
            this.id.HeaderText = "バッチID(自动采番)";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // batchKbn
            // 
            this.batchKbn.HeaderText = "バッチ区分";
            this.batchKbn.Name = "batchKbn";
            this.batchKbn.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "バッチ名前";
            this.name.Name = "name";
            // 
            // jikkouYMD
            // 
            this.jikkouYMD.DataPropertyName = "jikkouYMD";
            this.jikkouYMD.HeaderText = "実行時間";
            this.jikkouYMD.Name = "jikkouYMD";
            // 
            // jikkouResult
            // 
            this.jikkouResult.DataPropertyName = "jikkouResult";
            this.jikkouResult.HeaderText = "実行結果";
            this.jikkouResult.Name = "jikkouResult";
            // 
            // message
            // 
            this.message.DataPropertyName = "message";
            this.message.HeaderText = "エラーメッセージ";
            this.message.Name = "message";
            // 
            // kousinYMD
            // 
            this.kousinYMD.DataPropertyName = "kousinYMD";
            this.kousinYMD.HeaderText = "更新日付";
            this.kousinYMD.Name = "kousinYMD";
            // 
            // kosinCd
            // 
            this.kosinCd.DataPropertyName = "kosinCd";
            this.kosinCd.HeaderText = "更新者";
            this.kosinCd.Name = "kosinCd";
            // 
            // S004_batchLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "S004_batchLog";
            this.Text = "S004_batchLog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.S004_batchLog_FormClosing);
            this.Load += new System.EventHandler(this.S004_batchLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchKbn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn jikkouYMD;
        private System.Windows.Forms.DataGridViewTextBoxColumn jikkouResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn kousinYMD;
        private System.Windows.Forms.DataGridViewTextBoxColumn kosinCd;
    }
}