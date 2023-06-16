namespace 日历
{
    partial class learning
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.xyfx = new System.Windows.Forms.Label();
            this.xyfxn = new System.Windows.Forms.Label();
            this.zcs = new System.Windows.Forms.Label();
            this.zcsn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 363);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "认识";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(464, 363);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "不认识";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 274);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(337, 28);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(20, 18);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(764, 200);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(334, 451);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 34);
            this.button4.TabIndex = 5;
            this.button4.Text = "显示";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // xyfx
            // 
            this.xyfx.AutoSize = true;
            this.xyfx.Location = new System.Drawing.Point(602, 274);
            this.xyfx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xyfx.Name = "xyfx";
            this.xyfx.Size = new System.Drawing.Size(98, 18);
            this.xyfx.TabIndex = 7;
            this.xyfx.Text = "需要复习：";
            // 
            // xyfxn
            // 
            this.xyfxn.AutoSize = true;
            this.xyfxn.Location = new System.Drawing.Point(711, 274);
            this.xyfxn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xyfxn.Name = "xyfxn";
            this.xyfxn.Size = new System.Drawing.Size(62, 18);
            this.xyfxn.TabIndex = 8;
            this.xyfxn.Text = "label1";
            // 
            // zcs
            // 
            this.zcs.AutoSize = true;
            this.zcs.Location = new System.Drawing.Point(620, 242);
            this.zcs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zcs.Name = "zcs";
            this.zcs.Size = new System.Drawing.Size(80, 18);
            this.zcs.TabIndex = 9;
            this.zcs.Text = "总词数：";
            // 
            // zcsn
            // 
            this.zcsn.AutoSize = true;
            this.zcsn.Location = new System.Drawing.Point(714, 240);
            this.zcsn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zcsn.Name = "zcsn";
            this.zcsn.Size = new System.Drawing.Size(44, 18);
            this.zcsn.TabIndex = 10;
            this.zcsn.Text = "zcsn";
            this.zcsn.Click += new System.EventHandler(this.zcsn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 552);
            this.Controls.Add(this.zcsn);
            this.Controls.Add(this.zcs);
            this.Controls.Add(this.xyfxn);
            this.Controls.Add(this.xyfx);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "我爱背单词";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label xyfx;
        private System.Windows.Forms.Label xyfxn;
        private System.Windows.Forms.Label zcs;
        private System.Windows.Forms.Label zcsn;
    }
}