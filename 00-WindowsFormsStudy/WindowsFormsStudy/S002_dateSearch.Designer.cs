namespace WindowsFormsStudy
{
    partial class S002_dateSearch
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
            this.checkBoxFlag = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.printCSV = new System.Windows.Forms.Button();
            this.checkBoxObj = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoriFlg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torihikiCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toriNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torirkNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.torijyusyo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yubin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tantoNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kousinYMD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kosinCd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "データ一覧画面";
            // 
            // checkBoxFlag
            // 
            this.checkBoxFlag.AutoSize = true;
            this.checkBoxFlag.Location = new System.Drawing.Point(35, 72);
            this.checkBoxFlag.Name = "checkBoxFlag";
            this.checkBoxFlag.Size = new System.Drawing.Size(73, 16);
            this.checkBoxFlag.TabIndex = 2;
            this.checkBoxFlag.Text = "処理フラグ";
            this.checkBoxFlag.UseVisualStyleBackColor = true;
            this.checkBoxFlag.CheckedChanged += new System.EventHandler(this.checkBoxFlag_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkBoxObj,
            this.ID,
            this.shoriFlg,
            this.torihikiCd,
            this.toriNm,
            this.torirkNm,
            this.torijyusyo,
            this.yubin,
            this.telNo,
            this.faxNo,
            this.tantoNm,
            this.kousinYMD,
            this.kosinCd});
            this.dataGridView1.Location = new System.Drawing.Point(31, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(943, 188);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // printCSV
            // 
            this.printCSV.Location = new System.Drawing.Point(899, 392);
            this.printCSV.Name = "printCSV";
            this.printCSV.Size = new System.Drawing.Size(75, 23);
            this.printCSV.TabIndex = 4;
            this.printCSV.Text = "CSV出力";
            this.printCSV.UseVisualStyleBackColor = true;
            this.printCSV.Click += new System.EventHandler(this.printCSV_Click);
            // 
            // checkBoxObj
            // 
            this.checkBoxObj.FalseValue = "0";
            this.checkBoxObj.HeaderText = "选择";
            this.checkBoxObj.Name = "checkBoxObj";
            this.checkBoxObj.TrueValue = "1";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // shoriFlg
            // 
            this.shoriFlg.DataPropertyName = "shoriFlg";
            this.shoriFlg.HeaderText = "処理フラグ";
            this.shoriFlg.Name = "shoriFlg";
            this.shoriFlg.Visible = false;
            // 
            // torihikiCd
            // 
            this.torihikiCd.DataPropertyName = "torihikiCd";
            this.torihikiCd.HeaderText = "取引先コード";
            this.torihikiCd.Name = "torihikiCd";
            // 
            // toriNm
            // 
            this.toriNm.DataPropertyName = "toriNm";
            this.toriNm.HeaderText = "取引先名称";
            this.toriNm.Name = "toriNm";
            // 
            // torirkNm
            // 
            this.torirkNm.DataPropertyName = "torirkNm";
            this.torirkNm.HeaderText = "取引先略称";
            this.torirkNm.Name = "torirkNm";
            // 
            // torijyusyo
            // 
            this.torijyusyo.DataPropertyName = "torijyusyo";
            this.torijyusyo.HeaderText = "取引先住所";
            this.torijyusyo.Name = "torijyusyo";
            // 
            // yubin
            // 
            this.yubin.DataPropertyName = "yubin";
            this.yubin.HeaderText = "郵便番号";
            this.yubin.Name = "yubin";
            // 
            // telNo
            // 
            this.telNo.DataPropertyName = "telNo";
            this.telNo.HeaderText = "電話番号";
            this.telNo.Name = "telNo";
            // 
            // faxNo
            // 
            this.faxNo.DataPropertyName = "faxNo";
            this.faxNo.HeaderText = "FAX";
            this.faxNo.Name = "faxNo";
            // 
            // tantoNm
            // 
            this.tantoNm.DataPropertyName = "tantoNm";
            this.tantoNm.HeaderText = "担当者名";
            this.tantoNm.Name = "tantoNm";
            // 
            // kousinYMD
            // 
            this.kousinYMD.DataPropertyName = "kousinYMD";
            this.kousinYMD.HeaderText = "更新年月日";
            this.kousinYMD.Name = "kousinYMD";
            this.kousinYMD.Visible = false;
            // 
            // kosinCd
            // 
            this.kosinCd.DataPropertyName = "kosinCd";
            this.kosinCd.HeaderText = "更新者";
            this.kosinCd.Name = "kosinCd";
            // 
            // S002_dateSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 450);
            this.Controls.Add(this.printCSV);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBoxFlag);
            this.Controls.Add(this.label1);
            this.Name = "S002_dateSearch";
            this.Text = "S002_dateSearch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.S002_dateSearch_FormClosing);
            this.Load += new System.EventHandler(this.S002_dateSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxFlag;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button printCSV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkBoxObj;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoriFlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn torihikiCd;
        private System.Windows.Forms.DataGridViewTextBoxColumn toriNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn torirkNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn torijyusyo;
        private System.Windows.Forms.DataGridViewTextBoxColumn yubin;
        private System.Windows.Forms.DataGridViewTextBoxColumn telNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn faxNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tantoNm;
        private System.Windows.Forms.DataGridViewTextBoxColumn kousinYMD;
        private System.Windows.Forms.DataGridViewTextBoxColumn kosinCd;
    }
}