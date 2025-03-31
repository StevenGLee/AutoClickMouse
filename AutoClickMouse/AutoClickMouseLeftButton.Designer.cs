namespace AutoClickMouse
{
    partial class AutoClickMouseLeftButton
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoClickMouseLeftButton));
            this.BT_TestClick = new System.Windows.Forms.Button();
            this.BT_Start = new System.Windows.Forms.Button();
            this.BT_Stop = new System.Windows.Forms.Button();
            this.LB_Numbers = new System.Windows.Forms.TextBox();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.check_EnableStartTime = new System.Windows.Forms.CheckBox();
            this.clickTimes = new System.Windows.Forms.NumericUpDown();
            this.check_EnableClickTimes = new System.Windows.Forms.CheckBox();
            this.clickInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.clickTimes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clickInterval)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_TestClick
            // 
            this.BT_TestClick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BT_TestClick.Location = new System.Drawing.Point(4, 168);
            this.BT_TestClick.Margin = new System.Windows.Forms.Padding(4);
            this.BT_TestClick.Name = "BT_TestClick";
            this.BT_TestClick.Size = new System.Drawing.Size(109, 34);
            this.BT_TestClick.TabIndex = 0;
            this.BT_TestClick.Text = "计数器→";
            this.BT_TestClick.UseVisualStyleBackColor = true;
            this.BT_TestClick.Click += new System.EventHandler(this.BT_TestClick_Click);
            // 
            // BT_Start
            // 
            this.BT_Start.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BT_Start.Location = new System.Drawing.Point(4, 221);
            this.BT_Start.Margin = new System.Windows.Forms.Padding(4);
            this.BT_Start.Name = "BT_Start";
            this.BT_Start.Size = new System.Drawing.Size(109, 34);
            this.BT_Start.TabIndex = 1;
            this.BT_Start.Text = "开始(F9)";
            this.BT_Start.UseVisualStyleBackColor = true;
            this.BT_Start.Click += new System.EventHandler(this.BT_Start_Click);
            // 
            // BT_Stop
            // 
            this.BT_Stop.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BT_Stop.Location = new System.Drawing.Point(270, 221);
            this.BT_Stop.Margin = new System.Windows.Forms.Padding(4);
            this.BT_Stop.Name = "BT_Stop";
            this.BT_Stop.Size = new System.Drawing.Size(112, 34);
            this.BT_Stop.TabIndex = 2;
            this.BT_Stop.Text = "结束(F10)";
            this.BT_Stop.UseVisualStyleBackColor = true;
            this.BT_Stop.Click += new System.EventHandler(this.BT_Stop_Click);
            // 
            // LB_Numbers
            // 
            this.LB_Numbers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LB_Numbers.Location = new System.Drawing.Point(121, 171);
            this.LB_Numbers.Margin = new System.Windows.Forms.Padding(4);
            this.LB_Numbers.Name = "LB_Numbers";
            this.LB_Numbers.ReadOnly = true;
            this.LB_Numbers.Size = new System.Drawing.Size(261, 28);
            this.LB_Numbers.TabIndex = 3;
            // 
            // startTime
            // 
            this.startTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.startTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTime.Location = new System.Drawing.Point(120, 118);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(263, 28);
            this.startTime.TabIndex = 4;
            // 
            // enableStartTime
            // 
            this.check_EnableStartTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.check_EnableStartTime.AutoSize = true;
            this.check_EnableStartTime.Location = new System.Drawing.Point(3, 121);
            this.check_EnableStartTime.Name = "enableStartTime";
            this.check_EnableStartTime.Size = new System.Drawing.Size(106, 22);
            this.check_EnableStartTime.TabIndex = 5;
            this.check_EnableStartTime.Text = "开始时间";
            this.check_EnableStartTime.UseVisualStyleBackColor = true;
            // 
            // clickTimes
            // 
            this.clickTimes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.clickTimes.Location = new System.Drawing.Point(120, 65);
            this.clickTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.clickTimes.Name = "clickTimes";
            this.clickTimes.Size = new System.Drawing.Size(263, 28);
            this.clickTimes.TabIndex = 6;
            this.clickTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // enableClickTimes
            // 
            this.check_EnableClickTimes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.check_EnableClickTimes.AutoSize = true;
            this.check_EnableClickTimes.Location = new System.Drawing.Point(3, 68);
            this.check_EnableClickTimes.Name = "enableClickTimes";
            this.check_EnableClickTimes.Size = new System.Drawing.Size(106, 22);
            this.check_EnableClickTimes.TabIndex = 7;
            this.check_EnableClickTimes.Text = "点击次数";
            this.check_EnableClickTimes.UseVisualStyleBackColor = true;
            // 
            // clickInterval
            // 
            this.clickInterval.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.clickInterval.DecimalPlaces = 2;
            this.clickInterval.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.clickInterval.Location = new System.Drawing.Point(120, 12);
            this.clickInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.clickInterval.Name = "clickInterval";
            this.clickInterval.Size = new System.Drawing.Size(263, 28);
            this.clickInterval.TabIndex = 8;
            this.clickInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "点击间隔/秒";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.5483F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.4517F));
            this.tableLayoutPanel1.Controls.Add(this.BT_Stop, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.LB_Numbers, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.clickTimes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.clickInterval, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.check_EnableClickTimes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.check_EnableStartTime, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.BT_TestClick, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.BT_Start, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.startTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(386, 265);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // AutoClickMouseLeftButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 285);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AutoClickMouseLeftButton";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "鼠标自动点击器 by Tanpopo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoClickMouseLeftButton_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.clickTimes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clickInterval)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_TestClick;
        private System.Windows.Forms.Button BT_Start;
        private System.Windows.Forms.Button BT_Stop;
        private System.Windows.Forms.TextBox LB_Numbers;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.CheckBox check_EnableStartTime;
        private System.Windows.Forms.NumericUpDown clickTimes;
        private System.Windows.Forms.CheckBox check_EnableClickTimes;
        private System.Windows.Forms.NumericUpDown clickInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

