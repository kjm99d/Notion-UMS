namespace Notion_UMS
{
    partial class Form1
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
            button1 = new Button();
            button2 = new Button();
            tbDbWriteTitle = new TextBox();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(17, 20);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(254, 38);
            button1.TabIndex = 0;
            button1.Text = "DB ReadTest";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(17, 145);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(254, 38);
            button2.TabIndex = 1;
            button2.Text = "DB WriteTest";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tbDbWriteTitle
            // 
            tbDbWriteTitle.Location = new Point(17, 97);
            tbDbWriteTitle.Name = "tbDbWriteTitle";
            tbDbWriteTitle.PlaceholderText = "타이틀 정보";
            tbDbWriteTitle.Size = new Size(254, 31);
            tbDbWriteTitle.TabIndex = 2;
            tbDbWriteTitle.TextAlign = HorizontalAlignment.Center;
            // 
            // button3
            // 
            button3.Location = new Point(19, 257);
            button3.Name = "button3";
            button3.Size = new Size(252, 34);
            button3.TabIndex = 3;
            button3.Text = "페이지 내용 불러오기";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(button3);
            Controls.Add(tbDbWriteTitle);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox tbDbWriteTitle;
        private Button button3;
    }
}