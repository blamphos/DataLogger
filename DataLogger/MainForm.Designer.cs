/*
 * Created by SharpDevelop.
 * User: Rami
 * Date: 14.8.2014
 * Time: 13:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DataLogger
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
			this.btnFindCom = new System.Windows.Forms.Button();
			this.cbPorts = new System.Windows.Forms.ComboBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.tbData = new System.Windows.Forms.TextBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.tbSend = new System.Windows.Forms.TextBox();
			this.zg1 = new ZedGraph.ZedGraphControl();
			this.btnExportGraph = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.btnResetZoom = new System.Windows.Forms.Button();
			this.btnAcquire = new System.Windows.Forms.Button();
			this.btnSampleRate = new System.Windows.Forms.Button();
			this.tbSampleRate = new System.Windows.Forms.TextBox();
			this.tbLength = new System.Windows.Forms.TextBox();
			this.btnSetLength = new System.Windows.Forms.Button();
			this.btnExportData = new System.Windows.Forms.Button();
			this.chkSingle = new System.Windows.Forms.CheckBox();
			this.btnImportData = new System.Windows.Forms.Button();
			this.btnAnalyze = new System.Windows.Forms.Button();
			this.lblCount = new System.Windows.Forms.Label();
			this.numDecimateFactor = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownYMax = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDownYMin = new System.Windows.Forms.NumericUpDown();
			this.buttonClearGraph = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numDecimateFactor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownYMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownYMin)).BeginInit();
			this.SuspendLayout();
			// 
			// serialPort1
			// 
			this.serialPort1.BaudRate = 921600;
			this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1DataReceived);
			// 
			// btnFindCom
			// 
			this.btnFindCom.Location = new System.Drawing.Point(12, 12);
			this.btnFindCom.Name = "btnFindCom";
			this.btnFindCom.Size = new System.Drawing.Size(75, 23);
			this.btnFindCom.TabIndex = 1;
			this.btnFindCom.Text = "Find COM";
			this.btnFindCom.UseVisualStyleBackColor = true;
			this.btnFindCom.Click += new System.EventHandler(this.BtnFindComClick);
			// 
			// cbPorts
			// 
			this.cbPorts.FormattingEnabled = true;
			this.cbPorts.Location = new System.Drawing.Point(93, 14);
			this.cbPorts.Name = "cbPorts";
			this.cbPorts.Size = new System.Drawing.Size(251, 21);
			this.cbPorts.TabIndex = 2;
			// 
			// btnConnect
			// 
			this.btnConnect.Enabled = false;
			this.btnConnect.Location = new System.Drawing.Point(350, 14);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 23);
			this.btnConnect.TabIndex = 3;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
			// 
			// tbData
			// 
			this.tbData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.tbData.Location = new System.Drawing.Point(12, 43);
			this.tbData.Multiline = true;
			this.tbData.Name = "tbData";
			this.tbData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbData.Size = new System.Drawing.Size(332, 284);
			this.tbData.TabIndex = 4;
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClear.Location = new System.Drawing.Point(12, 333);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 3;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSend.Location = new System.Drawing.Point(350, 334);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 23);
			this.btnSend.TabIndex = 5;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Visible = false;
			this.btnSend.Click += new System.EventHandler(this.BtnSendClick);
			// 
			// tbSend
			// 
			this.tbSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbSend.Location = new System.Drawing.Point(174, 336);
			this.tbSend.Name = "tbSend";
			this.tbSend.Size = new System.Drawing.Size(170, 20);
			this.tbSend.TabIndex = 6;
			this.tbSend.Visible = false;
			// 
			// zg1
			// 
			this.zg1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.zg1.EditButtons = System.Windows.Forms.MouseButtons.Left;
			this.zg1.Location = new System.Drawing.Point(440, 41);
			this.zg1.Name = "zg1";
			this.zg1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
			this.zg1.ScrollGrace = 0D;
			this.zg1.ScrollMaxX = 0D;
			this.zg1.ScrollMaxY = 0D;
			this.zg1.ScrollMaxY2 = 0D;
			this.zg1.ScrollMinX = 0D;
			this.zg1.ScrollMinY = 0D;
			this.zg1.ScrollMinY2 = 0D;
			this.zg1.Size = new System.Drawing.Size(607, 315);
			this.zg1.TabIndex = 8;
			// 
			// btnExportGraph
			// 
			this.btnExportGraph.Location = new System.Drawing.Point(439, 12);
			this.btnExportGraph.Name = "btnExportGraph";
			this.btnExportGraph.Size = new System.Drawing.Size(87, 23);
			this.btnExportGraph.TabIndex = 7;
			this.btnExportGraph.Text = "Export Graph";
			this.btnExportGraph.UseVisualStyleBackColor = true;
			this.btnExportGraph.Click += new System.EventHandler(this.BtnExportGraphClick);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(93, 333);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "Test";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// btnResetZoom
			// 
			this.btnResetZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnResetZoom.Location = new System.Drawing.Point(972, 12);
			this.btnResetZoom.Name = "btnResetZoom";
			this.btnResetZoom.Size = new System.Drawing.Size(75, 23);
			this.btnResetZoom.TabIndex = 7;
			this.btnResetZoom.Text = "Reset Zoom";
			this.btnResetZoom.UseVisualStyleBackColor = true;
			this.btnResetZoom.Click += new System.EventHandler(this.BtnResetZoomClick);
			// 
			// btnAcquire
			// 
			this.btnAcquire.Location = new System.Drawing.Point(350, 43);
			this.btnAcquire.Name = "btnAcquire";
			this.btnAcquire.Size = new System.Drawing.Size(75, 23);
			this.btnAcquire.TabIndex = 5;
			this.btnAcquire.Text = "ACQUIRE";
			this.btnAcquire.UseVisualStyleBackColor = true;
			this.btnAcquire.Visible = false;
			this.btnAcquire.Click += new System.EventHandler(this.BtnAcquireClick);
			// 
			// btnSampleRate
			// 
			this.btnSampleRate.Location = new System.Drawing.Point(350, 114);
			this.btnSampleRate.Name = "btnSampleRate";
			this.btnSampleRate.Size = new System.Drawing.Size(75, 23);
			this.btnSampleRate.TabIndex = 5;
			this.btnSampleRate.Text = "Set Rate";
			this.btnSampleRate.UseVisualStyleBackColor = true;
			this.btnSampleRate.Visible = false;
			this.btnSampleRate.Click += new System.EventHandler(this.BtnSampleRateClick);
			// 
			// tbSampleRate
			// 
			this.tbSampleRate.Location = new System.Drawing.Point(350, 102);
			this.tbSampleRate.Name = "tbSampleRate";
			this.tbSampleRate.Size = new System.Drawing.Size(75, 20);
			this.tbSampleRate.TabIndex = 6;
			this.tbSampleRate.Text = "1000";
			this.tbSampleRate.Visible = false;
			// 
			// tbLength
			// 
			this.tbLength.Location = new System.Drawing.Point(350, 143);
			this.tbLength.Name = "tbLength";
			this.tbLength.Size = new System.Drawing.Size(75, 20);
			this.tbLength.TabIndex = 11;
			this.tbLength.Text = "1024";
			this.tbLength.Visible = false;
			// 
			// btnSetLength
			// 
			this.btnSetLength.Location = new System.Drawing.Point(350, 154);
			this.btnSetLength.Name = "btnSetLength";
			this.btnSetLength.Size = new System.Drawing.Size(75, 23);
			this.btnSetLength.TabIndex = 10;
			this.btnSetLength.Text = "Set Length";
			this.btnSetLength.UseVisualStyleBackColor = true;
			this.btnSetLength.Visible = false;
			this.btnSetLength.Click += new System.EventHandler(this.BtnSetLengthClick);
			// 
			// btnExportData
			// 
			this.btnExportData.Location = new System.Drawing.Point(532, 12);
			this.btnExportData.Name = "btnExportData";
			this.btnExportData.Size = new System.Drawing.Size(75, 23);
			this.btnExportData.TabIndex = 7;
			this.btnExportData.Text = "Export Data";
			this.btnExportData.UseVisualStyleBackColor = true;
			this.btnExportData.Click += new System.EventHandler(this.BtnExportDataClick);
			// 
			// chkSingle
			// 
			this.chkSingle.Checked = true;
			this.chkSingle.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSingle.Location = new System.Drawing.Point(350, 72);
			this.chkSingle.Name = "chkSingle";
			this.chkSingle.Size = new System.Drawing.Size(84, 24);
			this.chkSingle.TabIndex = 12;
			this.chkSingle.Text = "Single Shot";
			this.chkSingle.UseVisualStyleBackColor = true;
			this.chkSingle.Visible = false;
			// 
			// btnImportData
			// 
			this.btnImportData.Location = new System.Drawing.Point(613, 12);
			this.btnImportData.Name = "btnImportData";
			this.btnImportData.Size = new System.Drawing.Size(75, 23);
			this.btnImportData.TabIndex = 7;
			this.btnImportData.Text = "Import Data";
			this.btnImportData.UseVisualStyleBackColor = true;
			this.btnImportData.Click += new System.EventHandler(this.BtnImportDataClick);
			// 
			// btnAnalyze
			// 
			this.btnAnalyze.Location = new System.Drawing.Point(694, 12);
			this.btnAnalyze.Name = "btnAnalyze";
			this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
			this.btnAnalyze.TabIndex = 7;
			this.btnAnalyze.Text = "Analyze";
			this.btnAnalyze.UseVisualStyleBackColor = true;
			this.btnAnalyze.Click += new System.EventHandler(this.BtnAnalyzeClick);
			// 
			// lblCount
			// 
			this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCount.Location = new System.Drawing.Point(350, 288);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(84, 39);
			this.lblCount.TabIndex = 13;
			this.lblCount.Text = "0";
			this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// numDecimateFactor
			// 
			this.numDecimateFactor.Location = new System.Drawing.Point(776, 12);
			this.numDecimateFactor.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.numDecimateFactor.Name = "numDecimateFactor";
			this.numDecimateFactor.Size = new System.Drawing.Size(81, 20);
			this.numDecimateFactor.TabIndex = 14;
			this.numDecimateFactor.Value = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.numDecimateFactor.Visible = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(350, 190);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 11);
			this.label1.TabIndex = 18;
			this.label1.Text = "Y-axis Max";
			// 
			// numericUpDownYMax
			// 
			this.numericUpDownYMax.DecimalPlaces = 1;
			this.numericUpDownYMax.Increment = new decimal(new int[] {
			1,
			0,
			0,
			65536});
			this.numericUpDownYMax.Location = new System.Drawing.Point(350, 204);
			this.numericUpDownYMax.Maximum = new decimal(new int[] {
			5,
			0,
			0,
			0});
			this.numericUpDownYMax.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			65536});
			this.numericUpDownYMax.Name = "numericUpDownYMax";
			this.numericUpDownYMax.Size = new System.Drawing.Size(74, 20);
			this.numericUpDownYMax.TabIndex = 17;
			this.numericUpDownYMax.Value = new decimal(new int[] {
			35,
			0,
			0,
			65536});
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(350, 236);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 11);
			this.label2.TabIndex = 20;
			this.label2.Text = "Y-axis Min";
			// 
			// numericUpDownYMin
			// 
			this.numericUpDownYMin.DecimalPlaces = 1;
			this.numericUpDownYMin.Increment = new decimal(new int[] {
			1,
			0,
			0,
			65536});
			this.numericUpDownYMin.Location = new System.Drawing.Point(350, 250);
			this.numericUpDownYMin.Maximum = new decimal(new int[] {
			32,
			0,
			0,
			65536});
			this.numericUpDownYMin.Name = "numericUpDownYMin";
			this.numericUpDownYMin.Size = new System.Drawing.Size(74, 20);
			this.numericUpDownYMin.TabIndex = 19;
			// 
			// buttonClearGraph
			// 
			this.buttonClearGraph.Location = new System.Drawing.Point(891, 12);
			this.buttonClearGraph.Name = "buttonClearGraph";
			this.buttonClearGraph.Size = new System.Drawing.Size(75, 23);
			this.buttonClearGraph.TabIndex = 21;
			this.buttonClearGraph.Text = "Clear";
			this.buttonClearGraph.UseVisualStyleBackColor = true;
			this.buttonClearGraph.Click += new System.EventHandler(this.BtnClearGraphClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1059, 368);
			this.Controls.Add(this.buttonClearGraph);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDownYMin);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numericUpDownYMax);
			this.Controls.Add(this.numDecimateFactor);
			this.Controls.Add(this.lblCount);
			this.Controls.Add(this.chkSingle);
			this.Controls.Add(this.tbLength);
			this.Controls.Add(this.btnSetLength);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.zg1);
			this.Controls.Add(this.btnResetZoom);
			this.Controls.Add(this.btnAnalyze);
			this.Controls.Add(this.btnImportData);
			this.Controls.Add(this.btnExportData);
			this.Controls.Add(this.btnExportGraph);
			this.Controls.Add(this.tbSampleRate);
			this.Controls.Add(this.tbSend);
			this.Controls.Add(this.btnAcquire);
			this.Controls.Add(this.btnSampleRate);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.tbData);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.cbPorts);
			this.Controls.Add(this.btnFindCom);
			this.Name = "MainForm";
			this.Text = "DataLogger";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			((System.ComponentModel.ISupportInitialize)(this.numDecimateFactor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownYMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownYMin)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.NumericUpDown numericUpDownYMin;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownYMax;
		private System.Windows.Forms.NumericUpDown numDecimateFactor;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.Button btnAnalyze;
		private System.Windows.Forms.Button btnExportGraph;
		private System.Windows.Forms.Button btnImportData;
		private System.Windows.Forms.Button btnExportData;
		private System.Windows.Forms.CheckBox chkSingle;
		private System.Windows.Forms.TextBox tbLength;
		private System.Windows.Forms.Button btnSetLength;
		private System.Windows.Forms.TextBox tbSampleRate;
		private System.Windows.Forms.Button btnSampleRate;
		private System.Windows.Forms.Button btnFindCom;
		private System.Windows.Forms.Button btnAcquire;
		private System.Windows.Forms.Button btnResetZoom;
		private System.Windows.Forms.Button button2;
		private ZedGraph.ZedGraphControl zg1;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox tbSend;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.TextBox tbData;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.ComboBox cbPorts;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.Timer timer1;		
		private System.Windows.Forms.Button buttonClearGraph;
	}
}
