﻿namespace ShowFilteredListUgly {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose( );
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent( ) {
      this.DisplayListBox = new System.Windows.Forms.ListBox( );
      this.FilterTextBox = new System.Windows.Forms.TextBox( );
      this.button1 = new System.Windows.Forms.Button( );
      this.SuspendLayout( );
      // 
      // DisplayListBox
      // 
      this.DisplayListBox.FormattingEnabled = true;
      this.DisplayListBox.ItemHeight = 29;
      this.DisplayListBox.Location = new System.Drawing.Point(16, 16);
      this.DisplayListBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
      this.DisplayListBox.Name = "DisplayListBox";
      this.DisplayListBox.Size = new System.Drawing.Size(439, 323);
      this.DisplayListBox.TabIndex = 0;
      // 
      // FilterTextBox
      // 
      this.FilterTextBox.Location = new System.Drawing.Point(469, 16);
      this.FilterTextBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
      this.FilterTextBox.Name = "FilterTextBox";
      this.FilterTextBox.Size = new System.Drawing.Size(174, 35);
      this.FilterTextBox.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(469, 65);
      this.button1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(175, 51);
      this.button1.TabIndex = 2;
      this.button1.Text = "Filter";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(661, 356);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.FilterTextBox);
      this.Controls.Add(this.DisplayListBox);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
      this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout( );

    }

    #endregion

    private System.Windows.Forms.ListBox DisplayListBox;
    private System.Windows.Forms.TextBox FilterTextBox;
    private System.Windows.Forms.Button button1;
  }
}

