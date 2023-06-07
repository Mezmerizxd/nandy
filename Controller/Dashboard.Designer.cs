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
      GetVersion = new Button();
      GetNandFlasher.SuspendLayout();
      SuspendLayout();
      // 
      // FindNandy
      // 
      FindNandy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      FindNandy.Location = new Point(6, 27);
      FindNandy.Name = "FindNandy";
      FindNandy.Size = new Size(147, 23);
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
      SerialPortDevices.Location = new Point(6, 56);
      SerialPortDevices.Name = "SerialPortDevices";
      SerialPortDevices.Size = new Size(147, 214);
      SerialPortDevices.TabIndex = 2;
      SerialPortDevices.SelectedIndexChanged += SerialPortDevices_SelectedIndexChanged;
      // 
      // GetNandFlasher
      // 
      GetNandFlasher.Controls.Add(SerialPortDevices);
      GetNandFlasher.Controls.Add(FindNandy);
      GetNandFlasher.Location = new Point(12, 12);
      GetNandFlasher.Name = "GetNandFlasher";
      GetNandFlasher.Size = new Size(159, 277);
      GetNandFlasher.TabIndex = 3;
      GetNandFlasher.TabStop = false;
      GetNandFlasher.Text = "Get Nand Flasher";
      // 
      // GetVersion
      // 
      GetVersion.Location = new Point(12, 295);
      GetVersion.Name = "GetVersion";
      GetVersion.Size = new Size(159, 23);
      GetVersion.TabIndex = 4;
      GetVersion.Text = "Get Version";
      GetVersion.UseVisualStyleBackColor = true;
      GetVersion.Click += GetVersion_Click;
      // 
      // Dashboard
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(784, 461);
      Controls.Add(GetVersion);
      Controls.Add(GetNandFlasher);
      Name = "Dashboard";
      Text = "Dashboard";
      GetNandFlasher.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion
    private Button FindNandy;
    private ListBox SerialPortDevices;
    private GroupBox GetNandFlasher;
    private Button GetVersion;
  }
}