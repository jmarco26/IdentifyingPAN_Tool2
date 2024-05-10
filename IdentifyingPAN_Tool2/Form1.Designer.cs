namespace IdentifyingPAN_Tool2
{
    partial class PAN_Tool2
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
            back_panel = new Panel();
            checkBox1 = new CheckBox();
            tbx_outputName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            btn_clearOut = new Button();
            btn_browseOUT = new Button();
            tbx_out = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btn_Identify = new Button();
            btn_PreviewTXT = new Button();
            btn_PreviewDAT = new Button();
            btn_browseTXT = new Button();
            btn_browseDAT = new Button();
            tbx_txt = new TextBox();
            tbx_dat = new TextBox();
            back_panel.SuspendLayout();
            SuspendLayout();
            // 
            // back_panel
            // 
            back_panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            back_panel.BackColor = SystemColors.Control;
            back_panel.Controls.Add(checkBox1);
            back_panel.Controls.Add(tbx_outputName);
            back_panel.Controls.Add(label4);
            back_panel.Controls.Add(label5);
            back_panel.Controls.Add(label3);
            back_panel.Controls.Add(btn_clearOut);
            back_panel.Controls.Add(btn_browseOUT);
            back_panel.Controls.Add(tbx_out);
            back_panel.Controls.Add(label2);
            back_panel.Controls.Add(label1);
            back_panel.Controls.Add(btn_Identify);
            back_panel.Controls.Add(btn_PreviewTXT);
            back_panel.Controls.Add(btn_PreviewDAT);
            back_panel.Controls.Add(btn_browseTXT);
            back_panel.Controls.Add(btn_browseDAT);
            back_panel.Controls.Add(tbx_txt);
            back_panel.Controls.Add(tbx_dat);
            back_panel.Location = new Point(12, 12);
            back_panel.Name = "back_panel";
            back_panel.Size = new Size(709, 334);
            back_panel.TabIndex = 0;
            back_panel.TabStop = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(27, 304);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(285, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Set the name of output file (default to output.txt)";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // tbx_outputName
            // 
            tbx_outputName.Enabled = false;
            tbx_outputName.Location = new Point(27, 275);
            tbx_outputName.Name = "tbx_outputName";
            tbx_outputName.Size = new Size(152, 23);
            tbx_outputName.TabIndex = 13;
            tbx_outputName.TabStop = false;
            tbx_outputName.Text = "output";
            tbx_outputName.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(177, 278);
            label4.Name = "label4";
            label4.Size = new Size(28, 16);
            label4.TabIndex = 12;
            label4.Text = ".log";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 253);
            label5.Name = "label5";
            label5.Size = new Size(201, 19);
            label5.TabIndex = 12;
            label5.Text = "Name of the .txt file output";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(27, 171);
            label3.Name = "label3";
            label3.Size = new Size(225, 19);
            label3.TabIndex = 12;
            label3.Text = "Choose Folder to Store Output";
            // 
            // btn_clearOut
            // 
            btn_clearOut.Enabled = false;
            btn_clearOut.FlatAppearance.MouseDownBackColor = Color.Gray;
            btn_clearOut.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_clearOut.FlatStyle = FlatStyle.Flat;
            btn_clearOut.Location = new Point(593, 193);
            btn_clearOut.Name = "btn_clearOut";
            btn_clearOut.Size = new Size(88, 26);
            btn_clearOut.TabIndex = 11;
            btn_clearOut.TabStop = false;
            btn_clearOut.Text = "Clear";
            btn_clearOut.UseVisualStyleBackColor = true;
            btn_clearOut.Click += btn_clearOut_Click;
            // 
            // btn_browseOUT
            // 
            btn_browseOUT.FlatAppearance.MouseDownBackColor = Color.Gray;
            btn_browseOUT.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_browseOUT.FlatStyle = FlatStyle.Flat;
            btn_browseOUT.Location = new Point(499, 193);
            btn_browseOUT.Name = "btn_browseOUT";
            btn_browseOUT.Size = new Size(88, 26);
            btn_browseOUT.TabIndex = 10;
            btn_browseOUT.TabStop = false;
            btn_browseOUT.Text = "Browse";
            btn_browseOUT.UseVisualStyleBackColor = true;
            btn_browseOUT.Click += btn_browseOUT_Click;
            // 
            // tbx_out
            // 
            tbx_out.BackColor = SystemColors.ControlLightLight;
            tbx_out.Location = new Point(27, 193);
            tbx_out.Multiline = true;
            tbx_out.Name = "tbx_out";
            tbx_out.ReadOnly = true;
            tbx_out.Size = new Size(457, 26);
            tbx_out.TabIndex = 9;
            tbx_out.TabStop = false;
            tbx_out.TextChanged += tbx_out_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 105);
            label2.Name = "label2";
            label2.Size = new Size(179, 19);
            label2.TabIndex = 8;
            label2.Text = "Choose Path for .txt File";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 36);
            label1.Name = "label1";
            label1.Size = new Size(183, 19);
            label1.TabIndex = 7;
            label1.Text = "Choose Path for .dat File";
            // 
            // btn_Identify
            // 
            btn_Identify.Enabled = false;
            btn_Identify.FlatAppearance.MouseDownBackColor = Color.Gray;
            btn_Identify.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_Identify.FlatStyle = FlatStyle.Flat;
            btn_Identify.Location = new Point(593, 294);
            btn_Identify.Name = "btn_Identify";
            btn_Identify.Size = new Size(88, 26);
            btn_Identify.TabIndex = 6;
            btn_Identify.TabStop = false;
            btn_Identify.Text = "Identify";
            btn_Identify.UseVisualStyleBackColor = true;
            btn_Identify.Click += btn_Identify_Click;
            // 
            // btn_PreviewTXT
            // 
            btn_PreviewTXT.Enabled = false;
            btn_PreviewTXT.FlatAppearance.MouseDownBackColor = Color.Gray;
            btn_PreviewTXT.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_PreviewTXT.FlatStyle = FlatStyle.Flat;
            btn_PreviewTXT.Location = new Point(593, 127);
            btn_PreviewTXT.Name = "btn_PreviewTXT";
            btn_PreviewTXT.Size = new Size(88, 26);
            btn_PreviewTXT.TabIndex = 5;
            btn_PreviewTXT.TabStop = false;
            btn_PreviewTXT.Text = "Preview";
            btn_PreviewTXT.UseVisualStyleBackColor = true;
            btn_PreviewTXT.Click += btn_PreviewTXT_Click;
            // 
            // btn_PreviewDAT
            // 
            btn_PreviewDAT.Enabled = false;
            btn_PreviewDAT.FlatAppearance.MouseDownBackColor = Color.Gray;
            btn_PreviewDAT.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_PreviewDAT.FlatStyle = FlatStyle.Flat;
            btn_PreviewDAT.Location = new Point(593, 58);
            btn_PreviewDAT.Name = "btn_PreviewDAT";
            btn_PreviewDAT.Size = new Size(88, 26);
            btn_PreviewDAT.TabIndex = 4;
            btn_PreviewDAT.TabStop = false;
            btn_PreviewDAT.Text = "Preview";
            btn_PreviewDAT.UseVisualStyleBackColor = true;
            btn_PreviewDAT.Click += btn_PreviewDAT_Click;
            // 
            // btn_browseTXT
            // 
            btn_browseTXT.FlatAppearance.MouseDownBackColor = Color.Gray;
            btn_browseTXT.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_browseTXT.FlatStyle = FlatStyle.Flat;
            btn_browseTXT.Location = new Point(499, 127);
            btn_browseTXT.Name = "btn_browseTXT";
            btn_browseTXT.Size = new Size(88, 26);
            btn_browseTXT.TabIndex = 3;
            btn_browseTXT.TabStop = false;
            btn_browseTXT.Text = "Browse";
            btn_browseTXT.UseVisualStyleBackColor = true;
            btn_browseTXT.Click += btn_browseTXT_Click;
            // 
            // btn_browseDAT
            // 
            btn_browseDAT.FlatAppearance.MouseDownBackColor = Color.Gray;
            btn_browseDAT.FlatAppearance.MouseOverBackColor = Color.Silver;
            btn_browseDAT.FlatStyle = FlatStyle.Flat;
            btn_browseDAT.Location = new Point(499, 58);
            btn_browseDAT.Name = "btn_browseDAT";
            btn_browseDAT.Size = new Size(88, 26);
            btn_browseDAT.TabIndex = 2;
            btn_browseDAT.TabStop = false;
            btn_browseDAT.Text = "Browse";
            btn_browseDAT.UseVisualStyleBackColor = true;
            btn_browseDAT.Click += btn_browseDAT_Click;
            // 
            // tbx_txt
            // 
            tbx_txt.Location = new Point(27, 127);
            tbx_txt.Multiline = true;
            tbx_txt.Name = "tbx_txt";
            tbx_txt.Size = new Size(457, 26);
            tbx_txt.TabIndex = 1;
            tbx_txt.TabStop = false;
            tbx_txt.TextChanged += tbx_txt_TextChanged;
            // 
            // tbx_dat
            // 
            tbx_dat.Location = new Point(27, 58);
            tbx_dat.Multiline = true;
            tbx_dat.Name = "tbx_dat";
            tbx_dat.Size = new Size(457, 26);
            tbx_dat.TabIndex = 0;
            tbx_dat.TabStop = false;
            tbx_dat.TextChanged += tbx_dat_TextChanged;
            // 
            // PAN_Tool2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(733, 358);
            Controls.Add(back_panel);
            MaximizeBox = false;
            Name = "PAN_Tool2";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PAN Matching Tool";
            back_panel.ResumeLayout(false);
            back_panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel back_panel;
        private TextBox tbx_dat;
        private Button btn_browseTXT;
        private Button btn_browseDAT;
        private TextBox tbx_txt;
        private Button btn_PreviewDAT;
        private Button btn_PreviewTXT;
        private Button btn_Identify;
        private Label label2;
        private Label label1;
        private Label label3;
        private Button btn_clearOut;
        private Button btn_browseOUT;
        private TextBox tbx_out;
        private Label label4;
        private TextBox tbx_outputName;
        private Label label5;
        private CheckBox checkBox1;
    }
}
