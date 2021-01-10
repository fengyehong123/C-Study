namespace WindowsFormsStudy
{
    partial class S001_Touroku
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.torihikiCd = new System.Windows.Forms.TextBox();
            this.toriNm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.torirkNm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.torijyusyo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.yubin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.telNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.faxNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tantoNm = new System.Windows.Forms.TextBox();
            this.addData = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.データ登録ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.データ一覧ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バーチ処理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バーチ处理履历ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // torihikiCd
            // 
            this.torihikiCd.Location = new System.Drawing.Point(167, 104);
            this.torihikiCd.Name = "torihikiCd";
            this.torihikiCd.Size = new System.Drawing.Size(149, 19);
            this.torihikiCd.TabIndex = 0;
            // 
            // toriNm
            // 
            this.toriNm.Location = new System.Drawing.Point(167, 152);
            this.toriNm.Name = "toriNm";
            this.toriNm.Size = new System.Drawing.Size(149, 19);
            this.toriNm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "データ登録画面";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "取引先コード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "取引先名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "取引先略称";
            // 
            // torirkNm
            // 
            this.torirkNm.Location = new System.Drawing.Point(167, 202);
            this.torirkNm.Name = "torirkNm";
            this.torirkNm.Size = new System.Drawing.Size(149, 19);
            this.torirkNm.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "取引先住所";
            // 
            // torijyusyo
            // 
            this.torijyusyo.Location = new System.Drawing.Point(167, 256);
            this.torijyusyo.Name = "torijyusyo";
            this.torijyusyo.Size = new System.Drawing.Size(149, 19);
            this.torijyusyo.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(458, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "郵便番号";
            // 
            // yubin
            // 
            this.yubin.Location = new System.Drawing.Point(517, 108);
            this.yubin.Name = "yubin";
            this.yubin.Size = new System.Drawing.Size(149, 19);
            this.yubin.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(458, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "電話番号";
            // 
            // telNo
            // 
            this.telNo.Location = new System.Drawing.Point(517, 153);
            this.telNo.Name = "telNo";
            this.telNo.Size = new System.Drawing.Size(149, 19);
            this.telNo.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(458, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "FAX";
            // 
            // faxNo
            // 
            this.faxNo.Location = new System.Drawing.Point(517, 206);
            this.faxNo.Name = "faxNo";
            this.faxNo.Size = new System.Drawing.Size(149, 19);
            this.faxNo.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(458, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "担当者名";
            // 
            // tantoNm
            // 
            this.tantoNm.Location = new System.Drawing.Point(517, 256);
            this.tantoNm.Name = "tantoNm";
            this.tantoNm.Size = new System.Drawing.Size(149, 19);
            this.tantoNm.TabIndex = 16;
            // 
            // addData
            // 
            this.addData.Location = new System.Drawing.Point(636, 353);
            this.addData.Name = "addData";
            this.addData.Size = new System.Drawing.Size(75, 23);
            this.addData.TabIndex = 17;
            this.addData.Text = "登録";
            this.addData.UseVisualStyleBackColor = true;
            this.addData.Click += new System.EventHandler(this.addData_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.データ登録ToolStripMenuItem,
            this.データ一覧ToolStripMenuItem,
            this.バーチ処理ToolStripMenuItem,
            this.バーチ处理履历ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // データ登録ToolStripMenuItem
            // 
            this.データ登録ToolStripMenuItem.Name = "データ登録ToolStripMenuItem";
            this.データ登録ToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.データ登録ToolStripMenuItem.Text = "データ登録";
            // 
            // データ一覧ToolStripMenuItem
            // 
            this.データ一覧ToolStripMenuItem.Name = "データ一覧ToolStripMenuItem";
            this.データ一覧ToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.データ一覧ToolStripMenuItem.Text = "データ一覧";
            this.データ一覧ToolStripMenuItem.Click += new System.EventHandler(this.データ一覧ToolStripMenuItem_Click);
            // 
            // バーチ処理ToolStripMenuItem
            // 
            this.バーチ処理ToolStripMenuItem.Name = "バーチ処理ToolStripMenuItem";
            this.バーチ処理ToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.バーチ処理ToolStripMenuItem.Text = "バーチ処理";
            this.バーチ処理ToolStripMenuItem.Click += new System.EventHandler(this.バーチ処理ToolStripMenuItem_Click);
            // 
            // バーチ处理履历ToolStripMenuItem
            // 
            this.バーチ处理履历ToolStripMenuItem.Name = "バーチ处理履历ToolStripMenuItem";
            this.バーチ处理履历ToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.バーチ处理履历ToolStripMenuItem.Text = "バーチ处理履历";
            this.バーチ处理履历ToolStripMenuItem.Click += new System.EventHandler(this.バーチ处理履历ToolStripMenuItem_Click);
            // 
            // S001_Touroku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addData);
            this.Controls.Add(this.tantoNm);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.faxNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.telNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.yubin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.torijyusyo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.torirkNm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toriNm);
            this.Controls.Add(this.torihikiCd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "S001_Touroku";
            this.Text = "データ登録";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.S001_Touroku_FormClosing);
            this.Load += new System.EventHandler(this.S001_Touroku_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox torihikiCd;
        private System.Windows.Forms.TextBox toriNm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox torirkNm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox torijyusyo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox yubin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox telNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox faxNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tantoNm;
        private System.Windows.Forms.Button addData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem データ登録ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem データ一覧ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バーチ処理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バーチ处理履历ToolStripMenuItem;
    }
}

