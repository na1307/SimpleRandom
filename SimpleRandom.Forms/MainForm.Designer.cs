namespace SimpleRandom.Forms;

partial class MainForm : Form {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        label1 = new Label();
        startBox = new TextBox();
        label2 = new Label();
        endBox = new TextBox();
        checkBox1 = new CheckBox();
        button1 = new Button();
        numlabel = new Label();
        listBox1 = new ListBox();
        button2 = new Button();
        progressBar1 = new ProgressBar();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(26, 15);
        label1.Name = "label1";
        label1.Size = new Size(42, 15);
        label1.TabIndex = 0;
        label1.Text = "최소 : ";
        // 
        // startBox
        // 
        startBox.Location = new Point(74, 12);
        startBox.Name = "startBox";
        startBox.Size = new Size(100, 23);
        startBox.TabIndex = 1;
        startBox.TextChanged += textBox_TextChanged;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(196, 15);
        label2.Name = "label2";
        label2.Size = new Size(42, 15);
        label2.TabIndex = 2;
        label2.Text = "최대 : ";
        // 
        // endBox
        // 
        endBox.Location = new Point(244, 12);
        endBox.Name = "endBox";
        endBox.Size = new Size(100, 23);
        endBox.TabIndex = 3;
        endBox.TextChanged += textBox_TextChanged;
        // 
        // checkBox1
        // 
        checkBox1.AutoSize = true;
        checkBox1.Location = new Point(389, 14);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new Size(74, 19);
        checkBox1.TabIndex = 4;
        checkBox1.Text = "중복없음";
        checkBox1.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        button1.Enabled = false;
        button1.Location = new Point(12, 41);
        button1.Name = "button1";
        button1.Size = new Size(460, 50);
        button1.TabIndex = 5;
        button1.Text = "뽑기";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // numlabel
        // 
        numlabel.Font = new Font("맑은 고딕", 24F);
        numlabel.Location = new Point(12, 110);
        numlabel.Name = "numlabel";
        numlabel.Size = new Size(460, 84);
        numlabel.TabIndex = 6;
        numlabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Location = new Point(12, 197);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(460, 199);
        listBox1.TabIndex = 7;
        // 
        // button2
        // 
        button2.Location = new Point(12, 399);
        button2.Name = "button2";
        button2.Size = new Size(460, 50);
        button2.TabIndex = 8;
        button2.Text = "비우기";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // progressBar1
        // 
        progressBar1.Location = new Point(12, 97);
        progressBar1.Maximum = 0;
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(460, 10);
        progressBar1.TabIndex = 9;
        // 
        // MainForm
        // 
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(484, 461);
        Controls.Add(progressBar1);
        Controls.Add(button2);
        Controls.Add(listBox1);
        Controls.Add(numlabel);
        Controls.Add(button1);
        Controls.Add(checkBox1);
        Controls.Add(endBox);
        Controls.Add(label2);
        Controls.Add(startBox);
        Controls.Add(label1);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        Text = "숫자 뽑기 프로그램";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox startBox;
    private Label label2;
    private TextBox endBox;
    private CheckBox checkBox1;
    private Button button1;
    private Label numlabel;
    private ListBox listBox1;
    private Button button2;
    private ProgressBar progressBar1;
}
