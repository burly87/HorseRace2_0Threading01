namespace ThreadingProject
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_StartStop = new System.Windows.Forms.Button();
            this.cb_ThreadCount = new System.Windows.Forms.ComboBox();
            this.cb_TypeOfThread = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.totalTime = new System.Windows.Forms.Label();
            this.num_Timer = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_Timer)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_StartStop
            // 
            this.btn_StartStop.Location = new System.Drawing.Point(435, 17);
            this.btn_StartStop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_StartStop.Name = "btn_StartStop";
            this.btn_StartStop.Size = new System.Drawing.Size(81, 36);
            this.btn_StartStop.TabIndex = 0;
            this.btn_StartStop.Text = "Start";
            this.btn_StartStop.UseVisualStyleBackColor = true;
            this.btn_StartStop.Click += new System.EventHandler(this.startStop_Click);
            // 
            // cb_ThreadCount
            // 
            this.cb_ThreadCount.FormattingEnabled = true;
            this.cb_ThreadCount.Location = new System.Drawing.Point(127, 25);
            this.cb_ThreadCount.Margin = new System.Windows.Forms.Padding(2);
            this.cb_ThreadCount.Name = "cb_ThreadCount";
            this.cb_ThreadCount.Size = new System.Drawing.Size(53, 21);
            this.cb_ThreadCount.TabIndex = 1;
            this.cb_ThreadCount.SelectedIndexChanged += new System.EventHandler(this.number_SelectedIndexChanged);
            // 
            // cb_TypeOfThread
            // 
            this.cb_TypeOfThread.FormattingEnabled = true;
            this.cb_TypeOfThread.Location = new System.Drawing.Point(127, 4);
            this.cb_TypeOfThread.Margin = new System.Windows.Forms.Padding(2);
            this.cb_TypeOfThread.Name = "cb_TypeOfThread";
            this.cb_TypeOfThread.Size = new System.Drawing.Size(184, 21);
            this.cb_TypeOfThread.TabIndex = 2;
            this.cb_TypeOfThread.SelectedIndexChanged += new System.EventHandler(this.threads_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Threads";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type of Threads";
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(8, 57);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(517, 191);
            this.mainPanel.TabIndex = 7;
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Location = new System.Drawing.Point(245, 263);
            this.totalTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(0, 13);
            this.totalTime.TabIndex = 8;
            // 
            // num_Timer
            // 
            this.num_Timer.Location = new System.Drawing.Point(320, 26);
            this.num_Timer.Margin = new System.Windows.Forms.Padding(2);
            this.num_Timer.Name = "num_Timer";
            this.num_Timer.Size = new System.Drawing.Size(80, 20);
            this.num_Timer.TabIndex = 10;
            this.num_Timer.ValueChanged += new System.EventHandler(this.timer_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Time in Seconds";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_Timer);
            this.Controls.Add(this.totalTime);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_TypeOfThread);
            this.Controls.Add(this.cb_ThreadCount);
            this.Controls.Add(this.btn_StartStop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_Timer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StartStop;
        private System.Windows.Forms.ComboBox cb_ThreadCount;
        private System.Windows.Forms.ComboBox cb_TypeOfThread;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.Label totalTime;
        private System.Windows.Forms.NumericUpDown num_Timer;
        private System.Windows.Forms.Label label3;
    }
}

