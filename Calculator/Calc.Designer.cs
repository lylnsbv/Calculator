namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CalculatorPanel = new System.Windows.Forms.Panel();
            this.Equartion = new System.Windows.Forms.Label();
            this.DisplayResultLbl = new System.Windows.Forms.Label();
            this.Xbtn = new System.Windows.Forms.Button();
            this.Percentbtn = new System.Windows.Forms.Button();
            this.DoubleNull = new System.Windows.Forms.Button();
            this.Sqrtbtn = new System.Windows.Forms.Button();
            this.Backbtn = new System.Windows.Forms.Button();
            this.Equalbtn = new System.Windows.Forms.Button();
            this.Clearbtn = new System.Windows.Forms.Button();
            this.Resetbtn = new System.Windows.Forms.Button();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Dotbtn = new System.Windows.Forms.Button();
            this.Divbtn = new System.Windows.Forms.Button();
            this.Ninebtn = new System.Windows.Forms.Button();
            this.Eightbtn = new System.Windows.Forms.Button();
            this.Sevenbtn = new System.Windows.Forms.Button();
            this.Multbtn = new System.Windows.Forms.Button();
            this.Sixbtn = new System.Windows.Forms.Button();
            this.Subbtn = new System.Windows.Forms.Button();
            this.Threebtn = new System.Windows.Forms.Button();
            this.Fivebtn = new System.Windows.Forms.Button();
            this.Fourbtn = new System.Windows.Forms.Button();
            this.Twobtn = new System.Windows.Forms.Button();
            this.Onebtn = new System.Windows.Forms.Button();
            this.Nullbtn = new System.Windows.Forms.Button();
            this.CalculatorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CalculatorPanel
            // 
            this.CalculatorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(101)))), ((int)(((byte)(112)))));
            this.CalculatorPanel.Controls.Add(this.Equartion);
            this.CalculatorPanel.Controls.Add(this.DisplayResultLbl);
            this.CalculatorPanel.Controls.Add(this.Xbtn);
            this.CalculatorPanel.Controls.Add(this.Percentbtn);
            this.CalculatorPanel.Controls.Add(this.DoubleNull);
            this.CalculatorPanel.Controls.Add(this.Sqrtbtn);
            this.CalculatorPanel.Controls.Add(this.Backbtn);
            this.CalculatorPanel.Controls.Add(this.Equalbtn);
            this.CalculatorPanel.Controls.Add(this.Clearbtn);
            this.CalculatorPanel.Controls.Add(this.Resetbtn);
            this.CalculatorPanel.Controls.Add(this.Addbtn);
            this.CalculatorPanel.Controls.Add(this.Dotbtn);
            this.CalculatorPanel.Controls.Add(this.Divbtn);
            this.CalculatorPanel.Controls.Add(this.Ninebtn);
            this.CalculatorPanel.Controls.Add(this.Eightbtn);
            this.CalculatorPanel.Controls.Add(this.Sevenbtn);
            this.CalculatorPanel.Controls.Add(this.Multbtn);
            this.CalculatorPanel.Controls.Add(this.Sixbtn);
            this.CalculatorPanel.Controls.Add(this.Subbtn);
            this.CalculatorPanel.Controls.Add(this.Threebtn);
            this.CalculatorPanel.Controls.Add(this.Fivebtn);
            this.CalculatorPanel.Controls.Add(this.Fourbtn);
            this.CalculatorPanel.Controls.Add(this.Twobtn);
            this.CalculatorPanel.Controls.Add(this.Onebtn);
            this.CalculatorPanel.Controls.Add(this.Nullbtn);
            this.CalculatorPanel.Location = new System.Drawing.Point(0, 0);
            this.CalculatorPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CalculatorPanel.Name = "CalculatorPanel";
            this.CalculatorPanel.Size = new System.Drawing.Size(214, 258);
            this.CalculatorPanel.TabIndex = 36;
            this.CalculatorPanel.Click += new System.EventHandler(this.CalculatorFocus_Click);
            // 
            // Equartion
            // 
            this.Equartion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Equartion.AutoEllipsis = true;
            this.Equartion.BackColor = System.Drawing.Color.White;
            this.Equartion.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Equartion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Equartion.Location = new System.Drawing.Point(11, 17);
            this.Equartion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Equartion.Name = "Equartion";
            this.Equartion.Size = new System.Drawing.Size(191, 14);
            this.Equartion.TabIndex = 19;
            this.Equartion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Equartion.Click += new System.EventHandler(this.CalculatorFocus_Click);
            // 
            // DisplayResultLbl
            // 
            this.DisplayResultLbl.BackColor = System.Drawing.Color.White;
            this.DisplayResultLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.DisplayResultLbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DisplayResultLbl.Location = new System.Drawing.Point(11, 31);
            this.DisplayResultLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DisplayResultLbl.Name = "DisplayResultLbl";
            this.DisplayResultLbl.Size = new System.Drawing.Size(191, 28);
            this.DisplayResultLbl.TabIndex = 37;
            this.DisplayResultLbl.Text = "0";
            this.DisplayResultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DisplayResultLbl.Click += new System.EventHandler(this.CalculatorFocus_Click);
            // 
            // Xbtn
            // 
            this.Xbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Xbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Xbtn.Location = new System.Drawing.Point(169, 144);
            this.Xbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Xbtn.Name = "Xbtn";
            this.Xbtn.Size = new System.Drawing.Size(35, 30);
            this.Xbtn.TabIndex = 24;
            this.Xbtn.Text = "1/x";
            this.Xbtn.UseVisualStyleBackColor = true;
            this.Xbtn.Click += new System.EventHandler(this.Operationbtn_Click);
            this.Xbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Percentbtn
            // 
            this.Percentbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Percentbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Percentbtn.Location = new System.Drawing.Point(169, 109);
            this.Percentbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Percentbtn.Name = "Percentbtn";
            this.Percentbtn.Size = new System.Drawing.Size(35, 30);
            this.Percentbtn.TabIndex = 23;
            this.Percentbtn.Text = "%";
            this.Percentbtn.UseVisualStyleBackColor = true;
            this.Percentbtn.Click += new System.EventHandler(this.Operationbtn_Click);
            this.Percentbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // DoubleNull
            // 
            this.DoubleNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DoubleNull.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DoubleNull.Location = new System.Drawing.Point(48, 215);
            this.DoubleNull.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DoubleNull.Name = "DoubleNull";
            this.DoubleNull.Size = new System.Drawing.Size(74, 30);
            this.DoubleNull.TabIndex = 22;
            this.DoubleNull.Text = "00";
            this.DoubleNull.UseVisualStyleBackColor = true;
            this.DoubleNull.Click += new System.EventHandler(this.Btn_Click);
            this.DoubleNull.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Sqrtbtn
            // 
            this.Sqrtbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Sqrtbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Sqrtbtn.Location = new System.Drawing.Point(169, 74);
            this.Sqrtbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Sqrtbtn.Name = "Sqrtbtn";
            this.Sqrtbtn.Size = new System.Drawing.Size(35, 30);
            this.Sqrtbtn.TabIndex = 21;
            this.Sqrtbtn.Text = "√";
            this.Sqrtbtn.UseVisualStyleBackColor = true;
            this.Sqrtbtn.Click += new System.EventHandler(this.Operationbtn_Click);
            this.Sqrtbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Backbtn
            // 
            this.Backbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Backbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Backbtn.Location = new System.Drawing.Point(8, 74);
            this.Backbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(35, 30);
            this.Backbtn.TabIndex = 20;
            this.Backbtn.Text = "<--";
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.Backbtn_Click);
            this.Backbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Equalbtn
            // 
            this.Equalbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.Equalbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Equalbtn.Location = new System.Drawing.Point(169, 180);
            this.Equalbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Equalbtn.Name = "Equalbtn";
            this.Equalbtn.Size = new System.Drawing.Size(34, 65);
            this.Equalbtn.TabIndex = 17;
            this.Equalbtn.Text = "=";
            this.Equalbtn.UseVisualStyleBackColor = true;
            this.Equalbtn.Click += new System.EventHandler(this.Equalbtn_Click);
            this.Equalbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Clearbtn
            // 
            this.Clearbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Clearbtn.Location = new System.Drawing.Point(48, 74);
            this.Clearbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Clearbtn.Name = "Clearbtn";
            this.Clearbtn.Size = new System.Drawing.Size(35, 30);
            this.Clearbtn.TabIndex = 16;
            this.Clearbtn.Text = "CE";
            this.Clearbtn.UseVisualStyleBackColor = true;
            this.Clearbtn.Click += new System.EventHandler(this.Clearbtn_Click);
            this.Clearbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Resetbtn
            // 
            this.Resetbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Resetbtn.Location = new System.Drawing.Point(88, 74);
            this.Resetbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Resetbtn.Name = "Resetbtn";
            this.Resetbtn.Size = new System.Drawing.Size(35, 30);
            this.Resetbtn.TabIndex = 15;
            this.Resetbtn.Text = "C";
            this.Resetbtn.UseVisualStyleBackColor = true;
            this.Resetbtn.Click += new System.EventHandler(this.ClearAllbtn_Click);
            this.Resetbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Addbtn
            // 
            this.Addbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Addbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Addbtn.Location = new System.Drawing.Point(128, 180);
            this.Addbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(35, 30);
            this.Addbtn.TabIndex = 14;
            this.Addbtn.Text = "+";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Operationbtn_Click);
            this.Addbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Dotbtn
            // 
            this.Dotbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Dotbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Dotbtn.Location = new System.Drawing.Point(128, 215);
            this.Dotbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Dotbtn.Name = "Dotbtn";
            this.Dotbtn.Size = new System.Drawing.Size(35, 30);
            this.Dotbtn.TabIndex = 13;
            this.Dotbtn.Text = ",";
            this.Dotbtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Dotbtn.UseVisualStyleBackColor = true;
            this.Dotbtn.Click += new System.EventHandler(this.Btn_Click);
            this.Dotbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Divbtn
            // 
            this.Divbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Divbtn.Location = new System.Drawing.Point(128, 74);
            this.Divbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Divbtn.Name = "Divbtn";
            this.Divbtn.Size = new System.Drawing.Size(35, 30);
            this.Divbtn.TabIndex = 12;
            this.Divbtn.Text = "/";
            this.Divbtn.UseVisualStyleBackColor = true;
            this.Divbtn.Click += new System.EventHandler(this.Operationbtn_Click);
            this.Divbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Ninebtn
            // 
            this.Ninebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Ninebtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Ninebtn.Location = new System.Drawing.Point(88, 109);
            this.Ninebtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Ninebtn.Name = "Ninebtn";
            this.Ninebtn.Size = new System.Drawing.Size(35, 30);
            this.Ninebtn.TabIndex = 11;
            this.Ninebtn.Text = "9";
            this.Ninebtn.UseVisualStyleBackColor = true;
            this.Ninebtn.Click += new System.EventHandler(this.Btn_Click);
            this.Ninebtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Eightbtn
            // 
            this.Eightbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Eightbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Eightbtn.Location = new System.Drawing.Point(48, 109);
            this.Eightbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Eightbtn.Name = "Eightbtn";
            this.Eightbtn.Size = new System.Drawing.Size(35, 30);
            this.Eightbtn.TabIndex = 10;
            this.Eightbtn.Text = "8";
            this.Eightbtn.UseVisualStyleBackColor = true;
            this.Eightbtn.Click += new System.EventHandler(this.Btn_Click);
            this.Eightbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Sevenbtn
            // 
            this.Sevenbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Sevenbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Sevenbtn.Location = new System.Drawing.Point(8, 109);
            this.Sevenbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Sevenbtn.Name = "Sevenbtn";
            this.Sevenbtn.Size = new System.Drawing.Size(35, 30);
            this.Sevenbtn.TabIndex = 9;
            this.Sevenbtn.Text = "7";
            this.Sevenbtn.UseVisualStyleBackColor = true;
            this.Sevenbtn.Click += new System.EventHandler(this.Btn_Click);
            this.Sevenbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Multbtn
            // 
            this.Multbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Multbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Multbtn.Location = new System.Drawing.Point(128, 109);
            this.Multbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Multbtn.Name = "Multbtn";
            this.Multbtn.Size = new System.Drawing.Size(35, 30);
            this.Multbtn.TabIndex = 8;
            this.Multbtn.Text = "*";
            this.Multbtn.UseVisualStyleBackColor = true;
            this.Multbtn.Click += new System.EventHandler(this.Operationbtn_Click);
            this.Multbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Sixbtn
            // 
            this.Sixbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Sixbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Sixbtn.Location = new System.Drawing.Point(88, 144);
            this.Sixbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Sixbtn.Name = "Sixbtn";
            this.Sixbtn.Size = new System.Drawing.Size(35, 30);
            this.Sixbtn.TabIndex = 7;
            this.Sixbtn.Text = "6";
            this.Sixbtn.UseVisualStyleBackColor = true;
            this.Sixbtn.Click += new System.EventHandler(this.Btn_Click);
            this.Sixbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Subbtn
            // 
            this.Subbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Subbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Subbtn.Location = new System.Drawing.Point(128, 144);
            this.Subbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Subbtn.Name = "Subbtn";
            this.Subbtn.Size = new System.Drawing.Size(35, 30);
            this.Subbtn.TabIndex = 6;
            this.Subbtn.Text = "-";
            this.Subbtn.UseVisualStyleBackColor = true;
            this.Subbtn.Click += new System.EventHandler(this.Operationbtn_Click);
            this.Subbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Threebtn
            // 
            this.Threebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Threebtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Threebtn.Location = new System.Drawing.Point(88, 180);
            this.Threebtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Threebtn.Name = "Threebtn";
            this.Threebtn.Size = new System.Drawing.Size(35, 30);
            this.Threebtn.TabIndex = 5;
            this.Threebtn.Text = "3";
            this.Threebtn.UseVisualStyleBackColor = true;
            this.Threebtn.Click += new System.EventHandler(this.Btn_Click);
            this.Threebtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Fivebtn
            // 
            this.Fivebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Fivebtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Fivebtn.Location = new System.Drawing.Point(48, 144);
            this.Fivebtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Fivebtn.Name = "Fivebtn";
            this.Fivebtn.Size = new System.Drawing.Size(35, 30);
            this.Fivebtn.TabIndex = 4;
            this.Fivebtn.Text = "5";
            this.Fivebtn.UseVisualStyleBackColor = true;
            this.Fivebtn.Click += new System.EventHandler(this.Btn_Click);
            this.Fivebtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Fourbtn
            // 
            this.Fourbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Fourbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Fourbtn.Location = new System.Drawing.Point(8, 144);
            this.Fourbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Fourbtn.Name = "Fourbtn";
            this.Fourbtn.Size = new System.Drawing.Size(35, 30);
            this.Fourbtn.TabIndex = 3;
            this.Fourbtn.Text = "4";
            this.Fourbtn.UseVisualStyleBackColor = true;
            this.Fourbtn.Click += new System.EventHandler(this.Btn_Click);
            this.Fourbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Twobtn
            // 
            this.Twobtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Twobtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Twobtn.Location = new System.Drawing.Point(48, 180);
            this.Twobtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Twobtn.Name = "Twobtn";
            this.Twobtn.Size = new System.Drawing.Size(35, 30);
            this.Twobtn.TabIndex = 2;
            this.Twobtn.Text = "2";
            this.Twobtn.UseVisualStyleBackColor = true;
            this.Twobtn.Click += new System.EventHandler(this.Btn_Click);
            this.Twobtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Onebtn
            // 
            this.Onebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Onebtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Onebtn.Location = new System.Drawing.Point(8, 180);
            this.Onebtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Onebtn.Name = "Onebtn";
            this.Onebtn.Size = new System.Drawing.Size(35, 30);
            this.Onebtn.TabIndex = 1;
            this.Onebtn.Text = "1";
            this.Onebtn.UseVisualStyleBackColor = true;
            this.Onebtn.Click += new System.EventHandler(this.Btn_Click);
            this.Onebtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Nullbtn
            // 
            this.Nullbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Nullbtn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Nullbtn.Location = new System.Drawing.Point(8, 215);
            this.Nullbtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Nullbtn.Name = "Nullbtn";
            this.Nullbtn.Size = new System.Drawing.Size(35, 30);
            this.Nullbtn.TabIndex = 0;
            this.Nullbtn.Text = "0";
            this.Nullbtn.UseVisualStyleBackColor = true;
            this.Nullbtn.Click += new System.EventHandler(this.Btn_Click);
            this.Nullbtn.Enter += new System.EventHandler(this.Focusbtn_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(214, 257);
            this.Controls.Add(this.CalculatorPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form_KeyPress);
            this.CalculatorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CalculatorPanel;
        private System.Windows.Forms.Label Equartion;
        private System.Windows.Forms.Label DisplayResultLbl;
        private System.Windows.Forms.Button Xbtn;
        private System.Windows.Forms.Button Percentbtn;
        private System.Windows.Forms.Button DoubleNull;
        private System.Windows.Forms.Button Sqrtbtn;
        private System.Windows.Forms.Button Backbtn;
        private System.Windows.Forms.Button Equalbtn;
        private System.Windows.Forms.Button Clearbtn;
        private System.Windows.Forms.Button Resetbtn;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Button Dotbtn;
        private System.Windows.Forms.Button Divbtn;
        private System.Windows.Forms.Button Ninebtn;
        private System.Windows.Forms.Button Eightbtn;
        private System.Windows.Forms.Button Sevenbtn;
        private System.Windows.Forms.Button Multbtn;
        private System.Windows.Forms.Button Sixbtn;
        private System.Windows.Forms.Button Subbtn;
        private System.Windows.Forms.Button Threebtn;
        private System.Windows.Forms.Button Fivebtn;
        private System.Windows.Forms.Button Fourbtn;
        private System.Windows.Forms.Button Twobtn;
        private System.Windows.Forms.Button Onebtn;
        private System.Windows.Forms.Button Nullbtn;
    }
}

