namespace AzureVMApp
{
    partial class frmVMManager
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
            this.lblVMStatus = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbResourceGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstVM = new System.Windows.Forms.ListBox();
            this.btnDeallocate = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label4 = new System.Windows.Forms.Label();
            this.lstBoxLog = new System.Windows.Forms.ListBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action : ";
            // 
            // lblVMStatus
            // 
            this.lblVMStatus.AutoSize = true;
            this.lblVMStatus.Location = new System.Drawing.Point(104, 229);
            this.lblVMStatus.Name = "lblVMStatus";
            this.lblVMStatus.Size = new System.Drawing.Size(0, 13);
            this.lblVMStatus.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStart.Location = new System.Drawing.Point(117, 182);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(81, 30);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.DarkOrange;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStop.Location = new System.Drawing.Point(201, 182);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(81, 30);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Power Off";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Resource Groups : ";
            // 
            // cmbResourceGroup
            // 
            this.cmbResourceGroup.FormattingEnabled = true;
            this.cmbResourceGroup.Location = new System.Drawing.Point(117, 22);
            this.cmbResourceGroup.Name = "cmbResourceGroup";
            this.cmbResourceGroup.Size = new System.Drawing.Size(358, 21);
            this.cmbResourceGroup.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Virtual Machines:";
            // 
            // lstVM
            // 
            this.lstVM.FormattingEnabled = true;
            this.lstVM.Location = new System.Drawing.Point(117, 59);
            this.lstVM.Name = "lstVM";
            this.lstVM.Size = new System.Drawing.Size(358, 108);
            this.lstVM.TabIndex = 7;
            this.lstVM.SelectedIndexChanged += new System.EventHandler(this.lstVM_SelectedIndexChanged);
            // 
            // btnDeallocate
            // 
            this.btnDeallocate.BackColor = System.Drawing.Color.DarkRed;
            this.btnDeallocate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeallocate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeallocate.Location = new System.Drawing.Point(285, 182);
            this.btnDeallocate.Name = "btnDeallocate";
            this.btnDeallocate.Size = new System.Drawing.Size(81, 30);
            this.btnDeallocate.TabIndex = 8;
            this.btnDeallocate.Text = "Deallocate";
            this.btnDeallocate.UseVisualStyleBackColor = false;
            this.btnDeallocate.Click += new System.EventHandler(this.btnDeallocate_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(487, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Log :";
            // 
            // lstBoxLog
            // 
            this.lstBoxLog.FormattingEnabled = true;
            this.lstBoxLog.HorizontalScrollbar = true;
            this.lstBoxLog.Location = new System.Drawing.Point(117, 229);
            this.lstBoxLog.Name = "lstBoxLog";
            this.lstBoxLog.ScrollAlwaysVisible = true;
            this.lstBoxLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstBoxLog.Size = new System.Drawing.Size(358, 147);
            this.lstBoxLog.TabIndex = 11;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel";
            // 
            // frmVMManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 412);
            this.Controls.Add(this.lstBoxLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDeallocate);
            this.Controls.Add(this.lstVM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbResourceGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblVMStatus);
            this.Controls.Add(this.label1);
            this.Name = "frmVMManager";
            this.Text = "Azure VM Manager";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVMStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbResourceGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstVM;
        private System.Windows.Forms.Button btnDeallocate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstBoxLog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

