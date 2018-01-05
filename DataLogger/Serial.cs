using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Text;

namespace DataLogger
{
	public partial class MainForm
	{		
		StringBuilder sb;
		
		void CloseCom()
		{
			try {
				serialPort1.ReadExisting();
				serialPort1.Close();
				sb = null;
				btnAcquire.Text = "ACQUIRE";
			}
			catch (Exception ex) {
				ExceptionHandler(ex);
			}			
		}

		void SendCommand(string pStr)
		{
			try 
			{
				if (pStr.Length > 0 && serialPort1.IsOpen) 
				{
					serialPort1.Write(pStr);
				}	
				else
					MessageBox.Show("Serial port is not open or data is empty");
			}
			catch (Exception ex) {
				ExceptionHandler(ex);
			}			
		}
		
		void OpenCom(string portName)
		{
			try {
				serialPort1.PortName = portName;
				serialPort1.Open();
				serialPort1.ReadExisting();	// Read any junk out from in buffer
				sb = new StringBuilder();
			}
			catch (Exception ex) {
				ExceptionHandler(ex);
			}			
		}
		
		void SerialPort1DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			int bufLen = 0;
			string[] lineBuf;
			
			try {
		        SerialPort sp = (SerialPort)sender;
		        
		        /*serialBuf = sp.ReadLine();	
		        while (serialBuf.Length > 0)
		        {
		        	this.BeginInvoke(new UpdateTextCallback(UpdateText), new object[] { serialBuf });
		            serialBuf = sp.ReadLine();		        		        
		        }*/
		        
		        sb.Append(sp.ReadExisting());
		        
		        lineBuf = sb.ToString().Split('\n');
		     	bufLen = lineBuf.GetLength(0);
		        if (bufLen > 0)
		        {
			        // Last char is not linefeed -> keep that part of buffer
			        if (sb.ToString().Substring(sb.Length - 1) != "\n")
			        {
			       		bufLen--;
			       		sb = new StringBuilder(lineBuf[bufLen]);
			        }
					else
					{
						sb = new StringBuilder();
					}
		
		        	for (int i = 0; i < bufLen; i++)
		        	{
		        		if (lineBuf[i].Length > 0)
		        		    this.BeginInvoke(new UpdateTextCallback(UpdateText), new object[] { lineBuf[i] });
		        	}			        
		        }
		        /*
		        if (serialBuf.Contains("\n") == true)
		        {
		        	lineBuf = serialBuf.Split('\n');	
		        	serialBuf = String.Empty;
		        	foreach (string s in lineBuf)
		        	{
		        		if (s.Length > 0)
		        		    this.BeginInvoke(new UpdateTextCallback(UpdateText), new object[] { s });
		        	}		        				       
		        }*/
			}
			catch (Exception ex) {
				ExceptionHandler(ex);
			}
		}			
	}
}

