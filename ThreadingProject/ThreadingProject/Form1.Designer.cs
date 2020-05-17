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
            this.startStop = new System.Windows.Forms.Button();
            this.number = new System.Windows.Forms.ComboBox();
            this.threads = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.totalTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timer)).BeginInit();
            this.SuspendLayout();
            // 
            // startStop
            // 
            this.startStop.Location = new System.Drawing.Point(652, 26);
            this.startStop.Name = "startStop";
            this.startStop.Size = new System.Drawing.Size(121, 56);
            this.startStop.TabIndex = 0;
            this.startStop.Text = "Start";
            this.startStop.UseVisualStyleBackColor = true;
            this.startStop.Click += new System.EventHandler(this.startStop_Click);
            // 
            // number
            // 
            this.number.FormattingEnabled = true;
            this.number.Location = new System.Drawing.Point(190, 38);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(78, 28);
            this.number.TabIndex = 1;
            this.number.SelectedIndexChanged += new System.EventHandler(this.number_SelectedIndexChanged);
            // 
            // threads
            // 
            this.threads.FormattingEnabled = true;
            this.threads.Location = new System.Drawing.Point(190, 6);
            this.threads.Name = "threads";
            this.threads.Size = new System.Drawing.Size(187, 28);
            this.threads.TabIndex = 2;
            this.threads.SelectedIndexChanged += new System.EventHandler(this.threads_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Threads";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Type of Threads";
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(12, 88);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(776, 294);
            this.mainPanel.TabIndex = 7;
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Location = new System.Drawing.Point(368, 405);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(0, 20);
            this.totalTime.TabIndex = 8;
            // 
            // timer
            // 
            this.timer.Location = new System.Drawing.Point(480, 40);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(120, 26);
            this.timer.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Time in Seconds";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.totalTime);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.threads);
            this.Controls.Add(this.number);
            this.Controls.Add(this.startStop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startStop;
        private System.Windows.Forms.ComboBox number;
        private System.Windows.Forms.ComboBox threads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel mainPanel;
        private System.Windows.Forms.Label totalTime;
        private System.Windows.Forms.NumericUpDown timer;
        private System.Windows.Forms.Label label3;
    }
}

