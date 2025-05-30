using lab04.Data.Models;
using System.ComponentModel;

namespace lab04;

partial class AdminDashboardForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        label1 = new Label();
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(39, 11);
        label1.Name = "label1";
        label1.Size = new Size(37, 15);
        label1.TabIndex = 0;
        label1.Text = "Witaj ";
        // 
        // button1
        // 
        button1.Location = new Point(84, 111);
        button1.Name = "button1";
        button1.Size = new Size(100, 23);
        button1.TabIndex = 1;
        button1.Text = "Użytkownicy";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(330, 114);
        button2.Name = "button2";
        button2.Size = new Size(98, 23);
        button2.TabIndex = 2;
        button2.Text = "Wydarzenia";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // button3
        // 
        button3.Location = new Point(538, 114);
        button3.Name = "button3";
        button3.Size = new Size(75, 23);
        button3.TabIndex = 3;
        button3.Text = "Zapisy";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // AdminDashboardForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(label1);
        Name = "AdminDashboardForm";
        Text = "AdminDashboardForm";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Button button1;
    private Button button2;
    private Button button3;
}