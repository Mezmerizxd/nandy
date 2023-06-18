namespace Controller
{
  partial class Dashboard
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
      FindNandy = new Button();
      SerialPortDevices = new ListBox();
      GetNandFlasher = new GroupBox();
      Connect = new Button();
      LiveDataDisplay = new GroupBox();
      Version = new Label();
      groupBox1 = new GroupBox();
      Debug_ToggleBlink = new Button();
      GetNandFlasher.SuspendLayout();
      LiveDataDisplay.SuspendLayout();
      groupBox1.SuspendLayout();
      SuspendLayout();
      // 
      // FindNandy
      // 
      FindNandy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      FindNandy.Location = new Point(6, 22);
      FindNandy.Name = "FindNandy";
      FindNandy.Size = new Size(108, 23);
      FindNandy.TabIndex = 1;
      FindNandy.Text = "Find Nandy";
      FindNandy.UseVisualStyleBackColor = true;
      FindNandy.Click += FindNandy_Click;
      // 
      // SerialPortDevices
      // 
      SerialPortDevices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      SerialPortDevices.FormattingEnabled = true;
      SerialPortDevices.ItemHeight = 15;
      SerialPortDevices.Location = new Point(6, 51);
      SerialPortDevices.Name = "SerialPortDevices";
      SerialPortDevices.Size = new Size(108, 259);
      SerialPortDevices.TabIndex = 2;
      SerialPortDevices.SelectedIndexChanged += SerialPortDevices_SelectedIndexChanged;
      // 
      // GetNandFlasher
      // 
      GetNandFlasher.Controls.Add(Connect);
      GetNandFlasher.Controls.Add(SerialPortDevices);
      GetNandFlasher.Controls.Add(FindNandy);
      GetNandFlasher.Location = new Point(12, 12);
      GetNandFlasher.Name = "GetNandFlasher";
      GetNandFlasher.Size = new Size(120, 348);
      GetNandFlasher.TabIndex = 3;
      GetNandFlasher.TabStop = false;
      GetNandFlasher.Text = "Get Nand Flasher";
      // 
      // Connect
      // 
      Connect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      Connect.Enabled = false;
      Connect.Location = new Point(6, 319);
      Connect.Name = "Connect";
      Connect.Size = new Size(108, 23);
      Connect.TabIndex = 3;
      Connect.Text = "Connect";
      Connect.UseVisualStyleBackColor = true;
      Connect.Click += Connect_Click;
      // 
      // LiveDataDisplay
      // 
      LiveDataDisplay.Controls.Add(Version);
      LiveDataDisplay.Location = new Point(12, 360);
      LiveDataDisplay.Name = "LiveDataDisplay";
      LiveDataDisplay.Size = new Size(760, 38);
      LiveDataDisplay.TabIndex = 4;
      LiveDataDisplay.TabStop = false;
      // 
      // Version
      // 
      Version.AutoSize = true;
      Version.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
      Version.Location = new Point(6, 13);
      Version.Name = "Version";
      Version.Size = new Size(74, 19);
      Version.TabIndex = 5;
      Version.Text = "Version: 0";
      Version.TextAlign = ContentAlignment.MiddleCenter;
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(Debug_ToggleBlink);
      groupBox1.Location = new Point(652, 12);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new Size(120, 348);
      groupBox1.TabIndex = 4;
      groupBox1.TabStop = false;
      groupBox1.Text = "Debugging";
      // 
      // Debug_ToggleBlink
      // 
      Debug_ToggleBlink.Location = new Point(6, 22);
      Debug_ToggleBlink.Name = "Debug_ToggleBlink";
      Debug_ToggleBlink.Size = new Size(108, 23);
      Debug_ToggleBlink.TabIndex = 0;
      Debug_ToggleBlink.Text = "Toggle Blink";
      Debug_ToggleBlink.UseVisualStyleBackColor = true;
      Debug_ToggleBlink.Click += Debug_ToggleBlink_Click;
      // 
      // Dashboard
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(784, 401);
      Controls.Add(groupBox1);
      Controls.Add(LiveDataDisplay);
      Controls.Add(GetNandFlasher);
      Name = "Dashboard";
      Text = "Dashboard";
      GetNandFlasher.ResumeLayout(false);
      LiveDataDisplay.ResumeLayout(false);
      LiveDataDisplay.PerformLayout();
      groupBox1.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion
    private Button FindNandy;
    private ListBox SerialPortDevices;
    private GroupBox GetNandFlasher;
    private Button Connect;
    private GroupBox LiveDataDisplay;
    private Label Version;
    private GroupBox groupBox1;
    private Button Debug_ToggleBlink;
  }
}