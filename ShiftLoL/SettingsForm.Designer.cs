using System;

namespace ShiftLoL
{
    partial class SettingsForm
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
            this.checkTimer = new System.Windows.Forms.CheckBox();
            this.textTimer = new System.Windows.Forms.NumericUpDown();
            this.labelTimer = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.labelSound = new System.Windows.Forms.Label();
            this.textSound = new System.Windows.Forms.TextBox();
            this.checkSound = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelHotkey = new System.Windows.Forms.Label();
            this.textHotkey = new System.Windows.Forms.TextBox();
            this.checkHotkey = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSmallWindow = new System.Windows.Forms.Label();
            this.textMarginTop = new System.Windows.Forms.NumericUpDown();
            this.textMarginLeft = new System.Windows.Forms.NumericUpDown();
            this.textWaitAfter = new System.Windows.Forms.NumericUpDown();
            this.labelWaitAfter = new System.Windows.Forms.Label();
            this.labelMarginLeft = new System.Windows.Forms.Label();
            this.labelMarginTop = new System.Windows.Forms.Label();
            this.smallWindowPanel = new System.Windows.Forms.TableLayoutPanel();
            this.smallWindowRadio9 = new System.Windows.Forms.RadioButton();
            this.smallWindowRadio8 = new System.Windows.Forms.RadioButton();
            this.smallWindowRadio7 = new System.Windows.Forms.RadioButton();
            this.smallWindowRadio6 = new System.Windows.Forms.RadioButton();
            this.smallWindowRadio5 = new System.Windows.Forms.RadioButton();
            this.smallWindowRadio4 = new System.Windows.Forms.RadioButton();
            this.smallWindowRadio3 = new System.Windows.Forms.RadioButton();
            this.smallWindowRadio2 = new System.Windows.Forms.RadioButton();
            this.smallWindowRadio1 = new System.Windows.Forms.RadioButton();
            this.resetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.textTimer)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textMarginTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMarginLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWaitAfter)).BeginInit();
            this.smallWindowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkTimer
            // 
            this.checkTimer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkTimer.Location = new System.Drawing.Point(4, 4);
            this.checkTimer.Name = "checkTimer";
            this.checkTimer.Size = new System.Drawing.Size(149, 23);
            this.checkTimer.TabIndex = 0;
            this.checkTimer.Text = "Enable Timer:";
            this.checkTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkTimer.UseVisualStyleBackColor = true;
            // 
            // textTimer
            // 
            this.textTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textTimer.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.textTimer.Location = new System.Drawing.Point(175, 35);
            this.textTimer.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.textTimer.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.textTimer.Name = "textTimer";
            this.textTimer.Size = new System.Drawing.Size(120, 20);
            this.textTimer.TabIndex = 1;
            this.textTimer.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelTimer
            // 
            this.labelTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimer.Location = new System.Drawing.Point(4, 31);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(149, 29);
            this.labelTimer.TabIndex = 2;
            this.labelTimer.Text = "Timer Interval (milliseconds):";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(251, 396);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveButton.Location = new System.Drawing.Point(12, 396);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(79, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // labelSound
            // 
            this.labelSound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSound.Location = new System.Drawing.Point(4, 151);
            this.labelSound.Name = "labelSound";
            this.labelSound.Size = new System.Drawing.Size(149, 29);
            this.labelSound.TabIndex = 10;
            this.labelSound.Text = "Sound Path:";
            this.labelSound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textSound
            // 
            this.textSound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textSound.Location = new System.Drawing.Point(170, 155);
            this.textSound.Name = "textSound";
            this.textSound.Size = new System.Drawing.Size(129, 20);
            this.textSound.TabIndex = 9;
            // 
            // checkSound
            // 
            this.checkSound.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkSound.Location = new System.Drawing.Point(4, 124);
            this.checkSound.Name = "checkSound";
            this.checkSound.Size = new System.Drawing.Size(149, 23);
            this.checkSound.TabIndex = 8;
            this.checkSound.Text = "Enable Sound:";
            this.checkSound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSound.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(154, 0);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // labelHotkey
            // 
            this.labelHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHotkey.Location = new System.Drawing.Point(4, 91);
            this.labelHotkey.Name = "labelHotkey";
            this.labelHotkey.Size = new System.Drawing.Size(149, 29);
            this.labelHotkey.TabIndex = 9;
            this.labelHotkey.Text = "Hotkey:";
            this.labelHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textHotkey
            // 
            this.textHotkey.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textHotkey.Location = new System.Drawing.Point(170, 95);
            this.textHotkey.Name = "textHotkey";
            this.textHotkey.Size = new System.Drawing.Size(129, 20);
            this.textHotkey.TabIndex = 8;
            this.textHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textHotkey_KeyDown);
            // 
            // checkHotkey
            // 
            this.checkHotkey.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkHotkey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkHotkey.Location = new System.Drawing.Point(4, 64);
            this.checkHotkey.Name = "checkHotkey";
            this.checkHotkey.Size = new System.Drawing.Size(149, 23);
            this.checkHotkey.TabIndex = 11;
            this.checkHotkey.Text = "Enable Global Hotkey:";
            this.checkHotkey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkHotkey.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(121, 282);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(154, 0);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.labelSmallWindow, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.textMarginTop, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.textMarginLeft, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.textWaitAfter, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.labelWaitAfter, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.textSound, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.labelHotkey, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.textHotkey, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.textTimer, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelTimer, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkHotkey, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.checkTimer, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkSound, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.labelSound, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.labelMarginLeft, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.labelMarginTop, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.smallWindowPanel, 1, 9);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 10;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(314, 378);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // labelSmallWindow
            // 
            this.labelSmallWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSmallWindow.Location = new System.Drawing.Point(4, 271);
            this.labelSmallWindow.Name = "labelSmallWindow";
            this.labelSmallWindow.Size = new System.Drawing.Size(149, 106);
            this.labelSmallWindow.TabIndex = 22;
            this.labelSmallWindow.Text = "Small Window Position\r\n(When window size is smaller than screen size)";
            this.labelSmallWindow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textMarginTop
            // 
            this.textMarginTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textMarginTop.Location = new System.Drawing.Point(175, 245);
            this.textMarginTop.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.textMarginTop.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.textMarginTop.Name = "textMarginTop";
            this.textMarginTop.Size = new System.Drawing.Size(120, 20);
            this.textMarginTop.TabIndex = 21;
            // 
            // textMarginLeft
            // 
            this.textMarginLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textMarginLeft.Location = new System.Drawing.Point(175, 215);
            this.textMarginLeft.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.textMarginLeft.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.textMarginLeft.Name = "textMarginLeft";
            this.textMarginLeft.Size = new System.Drawing.Size(120, 20);
            this.textMarginLeft.TabIndex = 20;
            // 
            // textWaitAfter
            // 
            this.textWaitAfter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textWaitAfter.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.textWaitAfter.Location = new System.Drawing.Point(175, 185);
            this.textWaitAfter.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.textWaitAfter.Name = "textWaitAfter";
            this.textWaitAfter.Size = new System.Drawing.Size(120, 20);
            this.textWaitAfter.TabIndex = 19;
            // 
            // labelWaitAfter
            // 
            this.labelWaitAfter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWaitAfter.Location = new System.Drawing.Point(4, 181);
            this.labelWaitAfter.Name = "labelWaitAfter";
            this.labelWaitAfter.Size = new System.Drawing.Size(149, 29);
            this.labelWaitAfter.TabIndex = 13;
            this.labelWaitAfter.Text = "Wait after window detection (milliseconds):";
            this.labelWaitAfter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMarginLeft
            // 
            this.labelMarginLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMarginLeft.Location = new System.Drawing.Point(4, 211);
            this.labelMarginLeft.Name = "labelMarginLeft";
            this.labelMarginLeft.Size = new System.Drawing.Size(149, 29);
            this.labelMarginLeft.TabIndex = 14;
            this.labelMarginLeft.Text = "Window Left Margin (pixels):";
            this.labelMarginLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMarginTop
            // 
            this.labelMarginTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMarginTop.Location = new System.Drawing.Point(4, 241);
            this.labelMarginTop.Name = "labelMarginTop";
            this.labelMarginTop.Size = new System.Drawing.Size(149, 29);
            this.labelMarginTop.TabIndex = 15;
            this.labelMarginTop.Text = "Window Top Margin (pixels):";
            this.labelMarginTop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // smallWindowPanel
            // 
            this.smallWindowPanel.ColumnCount = 3;
            this.smallWindowPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.smallWindowPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.smallWindowPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.smallWindowPanel.Controls.Add(this.smallWindowRadio9, 2, 2);
            this.smallWindowPanel.Controls.Add(this.smallWindowRadio8, 1, 2);
            this.smallWindowPanel.Controls.Add(this.smallWindowRadio7, 0, 2);
            this.smallWindowPanel.Controls.Add(this.smallWindowRadio6, 2, 1);
            this.smallWindowPanel.Controls.Add(this.smallWindowRadio5, 1, 1);
            this.smallWindowPanel.Controls.Add(this.smallWindowRadio4, 0, 1);
            this.smallWindowPanel.Controls.Add(this.smallWindowRadio3, 2, 0);
            this.smallWindowPanel.Controls.Add(this.smallWindowRadio2, 1, 0);
            this.smallWindowPanel.Controls.Add(this.smallWindowRadio1, 0, 0);
            this.smallWindowPanel.Location = new System.Drawing.Point(160, 274);
            this.smallWindowPanel.Name = "smallWindowPanel";
            this.smallWindowPanel.RowCount = 3;
            this.smallWindowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.smallWindowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.smallWindowPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.smallWindowPanel.Size = new System.Drawing.Size(150, 100);
            this.smallWindowPanel.TabIndex = 23;
            // 
            // smallWindowRadio9
            // 
            this.smallWindowRadio9.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smallWindowRadio9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallWindowRadio9.Location = new System.Drawing.Point(102, 69);
            this.smallWindowRadio9.Name = "smallWindowRadio9";
            this.smallWindowRadio9.Size = new System.Drawing.Size(45, 28);
            this.smallWindowRadio9.TabIndex = 8;
            this.smallWindowRadio9.TabStop = true;
            this.smallWindowRadio9.UseVisualStyleBackColor = true;
            // 
            // smallWindowRadio8
            // 
            this.smallWindowRadio8.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smallWindowRadio8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallWindowRadio8.Location = new System.Drawing.Point(52, 69);
            this.smallWindowRadio8.Name = "smallWindowRadio8";
            this.smallWindowRadio8.Size = new System.Drawing.Size(44, 28);
            this.smallWindowRadio8.TabIndex = 7;
            this.smallWindowRadio8.TabStop = true;
            this.smallWindowRadio8.UseVisualStyleBackColor = true;
            // 
            // smallWindowRadio7
            // 
            this.smallWindowRadio7.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smallWindowRadio7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallWindowRadio7.Location = new System.Drawing.Point(3, 69);
            this.smallWindowRadio7.Name = "smallWindowRadio7";
            this.smallWindowRadio7.Size = new System.Drawing.Size(43, 28);
            this.smallWindowRadio7.TabIndex = 6;
            this.smallWindowRadio7.TabStop = true;
            this.smallWindowRadio7.UseVisualStyleBackColor = true;
            // 
            // smallWindowRadio6
            // 
            this.smallWindowRadio6.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smallWindowRadio6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallWindowRadio6.Location = new System.Drawing.Point(102, 36);
            this.smallWindowRadio6.Name = "smallWindowRadio6";
            this.smallWindowRadio6.Size = new System.Drawing.Size(45, 27);
            this.smallWindowRadio6.TabIndex = 5;
            this.smallWindowRadio6.TabStop = true;
            this.smallWindowRadio6.UseVisualStyleBackColor = true;
            // 
            // smallWindowRadio5
            // 
            this.smallWindowRadio5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smallWindowRadio5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallWindowRadio5.Location = new System.Drawing.Point(52, 36);
            this.smallWindowRadio5.Name = "smallWindowRadio5";
            this.smallWindowRadio5.Size = new System.Drawing.Size(44, 27);
            this.smallWindowRadio5.TabIndex = 4;
            this.smallWindowRadio5.TabStop = true;
            this.smallWindowRadio5.UseVisualStyleBackColor = true;
            // 
            // smallWindowRadio4
            // 
            this.smallWindowRadio4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smallWindowRadio4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallWindowRadio4.Location = new System.Drawing.Point(3, 36);
            this.smallWindowRadio4.Name = "smallWindowRadio4";
            this.smallWindowRadio4.Size = new System.Drawing.Size(43, 27);
            this.smallWindowRadio4.TabIndex = 3;
            this.smallWindowRadio4.TabStop = true;
            this.smallWindowRadio4.UseVisualStyleBackColor = true;
            // 
            // smallWindowRadio3
            // 
            this.smallWindowRadio3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smallWindowRadio3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallWindowRadio3.Location = new System.Drawing.Point(102, 3);
            this.smallWindowRadio3.Name = "smallWindowRadio3";
            this.smallWindowRadio3.Size = new System.Drawing.Size(45, 27);
            this.smallWindowRadio3.TabIndex = 2;
            this.smallWindowRadio3.TabStop = true;
            this.smallWindowRadio3.UseVisualStyleBackColor = true;
            // 
            // smallWindowRadio2
            // 
            this.smallWindowRadio2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smallWindowRadio2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallWindowRadio2.Location = new System.Drawing.Point(52, 3);
            this.smallWindowRadio2.Name = "smallWindowRadio2";
            this.smallWindowRadio2.Size = new System.Drawing.Size(44, 27);
            this.smallWindowRadio2.TabIndex = 1;
            this.smallWindowRadio2.TabStop = true;
            this.smallWindowRadio2.UseVisualStyleBackColor = true;
            // 
            // smallWindowRadio1
            // 
            this.smallWindowRadio1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.smallWindowRadio1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smallWindowRadio1.Location = new System.Drawing.Point(3, 3);
            this.smallWindowRadio1.Name = "smallWindowRadio1";
            this.smallWindowRadio1.Size = new System.Drawing.Size(43, 27);
            this.smallWindowRadio1.TabIndex = 0;
            this.smallWindowRadio1.TabStop = true;
            this.smallWindowRadio1.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.resetButton.Location = new System.Drawing.Point(131, 396);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(76, 23);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(338, 431);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShiftLoL Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.VisibleChanged += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textTimer)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textMarginTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textMarginLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textWaitAfter)).EndInit();
            this.smallWindowPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkTimer;
        private System.Windows.Forms.NumericUpDown textTimer;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label labelSound;
        private System.Windows.Forms.TextBox textSound;
        private System.Windows.Forms.CheckBox checkSound;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelHotkey;
        private System.Windows.Forms.TextBox textHotkey;
        private System.Windows.Forms.CheckBox checkHotkey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label labelWaitAfter;
        private System.Windows.Forms.Label labelMarginLeft;
        private System.Windows.Forms.Label labelMarginTop;
        private System.Windows.Forms.NumericUpDown textMarginTop;
        private System.Windows.Forms.NumericUpDown textMarginLeft;
        private System.Windows.Forms.NumericUpDown textWaitAfter;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label labelSmallWindow;
        private System.Windows.Forms.TableLayoutPanel smallWindowPanel;
        private System.Windows.Forms.RadioButton smallWindowRadio9;
        private System.Windows.Forms.RadioButton smallWindowRadio8;
        private System.Windows.Forms.RadioButton smallWindowRadio7;
        private System.Windows.Forms.RadioButton smallWindowRadio6;
        private System.Windows.Forms.RadioButton smallWindowRadio5;
        private System.Windows.Forms.RadioButton smallWindowRadio4;
        private System.Windows.Forms.RadioButton smallWindowRadio3;
        private System.Windows.Forms.RadioButton smallWindowRadio2;
        private System.Windows.Forms.RadioButton smallWindowRadio1;
    }
}