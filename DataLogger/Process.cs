using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Collections; 
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using ZedGraph;

namespace DataLogger
{
	public partial class MainForm : Form
	{			
		int noCommandCounter = 0;
		IrDecoder irDecoder = new IrDecoder();

			
		private void ProcessData(string pDataStr)
		{
			int i = 0;
			double x, y;

			//string[] buf = pDataStr.Split('\n');
			//string fileName = GetMbedDriveLetter() + @"\" + buf[0];
			string tempFileName = String.Empty;
			//Debug.WriteLine(fileName);
			
			try 
			{	
				//if (File.Exists(fileName) == false) return;
				
				//tempFileName = @"C:\Temp\" + Path.GetFileName(fileName);
				//File.Copy(fileName, tempFileName, true);
				
				//string line = File.ReadAllText(tempFileName);
				//using (StreamReader sr = File.OpenText(tempFileName)
				{
					string line = pDataStr.Replace(",out.txt", "");
					//string line = buf[0].Replace(",out.txt", "");
					//string line = String.Empty;
			        //while ((line = sr.ReadLine()) != null)
			        {
			        	i = 0;
			        	//list.Clear();		        
			        	
			        	string[] s_buf = line.Split(',');	
			        	//Debug.WriteLine("Received: " + s_buf.Length.ToString() + " samples.");

			        	// Remove points from start if list "is full"
			        	list.Clear();
			        	/*if (list.Count >= s_buf.Length * 4)
			        	{
				        	if (s_buf.Length < list.Count)
				        	{
				        		list.RemoveRange(0, s_buf.Length);
				        	}			        	
			        	}*/
			        	
			        	//return;
			        	//x = list[list.Count - 1].X;
						foreach (string s in s_buf)
						{
							if (s.Length > 0)
							{
								x = i * sampleInterval * 1000.0;
								//y = Double.Parse(s) / 65535.0 * 3.3;
								y = Double.Parse(s) / 100.0 * 3.3;
								list.Add(x, y);
								i++;							
							}
							
							//if (i > 1000) break;
						}
						
						// Build list2 with filtered values to plot a new curve in graph pane
						list2.Clear();
						
						// Filter glitches
						int highSamples = 0;
						var indexes = new List<int>();
						var points = list.Select(pointPair => pointPair.Y).ToList();
						for (i = 0; i < points.Count; i++)
						{
							//list2.Add(list[i]);
							
							if (points[i] > 0.8)
							{
								highSamples++;								
							}
							else 
							{	//										 __
								// "Peak" pulse (glitch) detected ( ____|  |________ )
								if (highSamples > 0 && highSamples <= 4)
								{
									// Zero samples according to high samples count ( ______________ )
									var offset = i - highSamples;
									for (var j = 0; j < highSamples; j++)
									{
										//list[offset + j].Y = 0.0;
										//list2[offset + j].Y = 0.0;
										//indexes.Add(offset + j);
									}
								}
								highSamples = 0;
							}
						}										
						
						/*for (i = 0; i < points.Count; i++)
						{
							var item = list[i];
							if (indexes.Contains(i))
							{
								item.Y = 0.0;
								
							}
							list2.Add(item.X, item.Y + 0.5);
						}*/
						
						UpdateGraph();
						//AnalyzeReceivedData(); // Drop detect
						//if (!AnalyzeReceivedIrData_Backup())
						//if (!AnalyzeReceivedIrData())
						if (irDecoder.AnalyzeData(points))
						{
							noCommandCounter++;
						}
						
						if (noCommandCounter > 4)
						{
							lblCount.Text = "";
							noCommandCounter = 0;
						}
			        }
				}			
			}	
			catch (IOException) 
			{
				Debug.WriteLine(tempFileName + " not accessible");
			}
			catch (Exception ex)
			{
				ExceptionHandler(ex);
			}
		}		

		/*bool AnalyzeReceivedIrData()
		{
            //var dcLevel = points.Average() / 65535.0 * 3.3;
            var pulseHigh = false;
            int databits = 0;
            var length = 0;
            var pulseLengths = new List<int>();
            var receiving = false;
            long data = 0;
            bool commandReceived = false;
            IrDecoder.IrBitType bitType;
            
            //points = Statistics.MovingAverage(points, 3).ToList();
			var points = list.Select(pointPair => pointPair.Y).ToList();
						
            for (var i = 0; i < points.Count; i++)
            {
            	if (points[i] > 0.8)
                {               	
                    // Rising edge starts new pulse
                    if (!pulseHigh)
                    {
                        // Handle current pulse
                        if (length > 0)
                        {
                            //var len = length;
                            //pulseLengths.Add(length * IR_SAMPLING_PERIOD_US);
                            //Debug.WriteLine("Pulse: " + len);
                            bitType = GetBitType(length);
                            //Debug.WriteLine(" (" + bitType + ")");

                            if (receiving)
                            {
                            	if (bitType == IrBitType.IR_DATA_BIT_ONE)
                                {
                                	try
                                	{
                                		data |= (long)1 << databits;
                                		databits++;
                                	}
                                	catch (Exception e) {
                                		Debug.WriteLine(e.Message);
                                	}
                                    
                                }
                            	else if (bitType == IrBitType.IR_DATA_BIT_ZERO)
                                {
                                    databits++;
                                }
                                else
                                {
                                    //Log.Files.Debug($"Idle: {len}");
                                    //Log.Files.Debug($"Index: {i}");
                                    receiving = false;
                                }
								
                                if (receiving && databits == 32)
                                {
                                	foreach(var item in pulseLengths)
                                	{
                                		Debug.WriteLine(item);
                                	}
                                    receiving = false;
                                    Debug.WriteLine("Data: 0x" + data.ToString("X2"));
                                    if ((data & 0xFFFFFFFF) == IR_TV_VOL_UP)
                                    {
                                    	lblCount.Text = "UP"; 
                                    	commandReceived = true;
                                    	//SendKeys.SendWait("{UP}");
                                    }
                                    else if ((data & 0xFFFFFFFF) == IR_TV_VOL_DOWN)
                                    {
                                    	lblCount.Text = "DOWN";
                                    	commandReceived = true;
                                    	//SendKeys.SendWait("{DOWN}");
                                    }
                                    else if ((data & 0xFFFFFFFF) == IR_TV_VOL_MUTE)
                                    {
                                    	lblCount.Text = "MUTE";
                                    	commandReceived = true;
                                    	//SendKeys.SendWait("{DOWN}");
                                    }
                                }
                            }
                            
                            // Start pulse
                            if (bitType == IrBitType.IR_START_BIT)
                            {
                                //Debug.WriteLine($"Start: {i}");
                                receiving = true;
                                data = 0;
                                databits = 0;
                            }
                        }
                        pulseHigh = true;
                        length = 0;
                    }
                    else
                    {
                        length++;
                    }
                }
                else
                {
                    if (pulseHigh)
                    {
                        pulseHigh = false;
                    }
                    if (length > 0)
                    {
                        length++;
                    }                    
                }
            }            
			
            return commandReceived;
		}*/
		
		/*bool AnalyzeReceivedIrData_Backup()
		{
            //var dcLevel = points.Average() / 65535.0 * 3.3;
            var pulseHigh = false;
            int pulses = 0;
            var length = 0;
            var pulseLengths = new List<int>();
            var receiving = false;
            long data = 0;
            bool commandReceived = false;
            
            //points = Statistics.MovingAverage(points, 3).ToList();
			var points = list.Select(pointPair => pointPair.Y).ToList();
			var scaler = 0.5;
            for (var i = 0; i < points.Count; i++)
            {
            	if (points[i] > 0.8)
                {               	
                    // Rising edge starts new pulse
                    if (!pulseHigh)
                    {
                        // Handle current pulse
                        if (length > 0)
                        {
                            var len = length;
                            pulseLengths.Add(len);
                            //Debug.WriteLine("Pulse: " + len);

                            if (receiving)
                            {
                            	if (len >= (40 * scaler) && len < (48 * scaler))
                                {
                                	try
                                	{
                                		data |= (long)1 << pulses;
                                	}
                                	catch (Exception e) {
                                		Debug.WriteLine(e.Message);
                                	}
                                    
                                }
                            	else if (len < (25 * scaler))
                                {
                                    // Zero
                                }
                                else
                                {
                                    //Log.Files.Debug($"Idle: {len}");
                                    //Log.Files.Debug($"Index: {i}");
                                    receiving = false;
                                }

								pulses++;
                                if (pulses == 32)
                                {
                                    receiving = false;
                                    Debug.WriteLine("Data: 0x" + data.ToString("X2"));
                                    if ((data & 0xFFFFFFFF) == IR_TV_VOL_UP)
                                    {
                                    	lblCount.Text = "UP"; 
                                    	commandReceived = true;
                                    }
                                    else if ((data & 0xFFFFFFFF) == IR_TV_VOL_DOWN)
                                    {
                                    	lblCount.Text = "DOWN";
                                    	commandReceived = true;
                                    }
                                }
                            }

                            // Start pulse
                            if (len >= (178 * scaler) && len < (182 * scaler))
                            {
                                //Debug.WriteLine($"Start: {i}");
                                receiving = true;
                                data = 0;
                                pulses = 0;
                            }
                        }
                        pulseHigh = true;
                        length = 0;
                    }
                    else
                    {
                        length++;
                    }
                }
                else
                {
                    if (pulseHigh)
                    {
                        pulseHigh = false;
                    }
                    if (length > 0)
                    {
                        length++;
                    }                    
                }
            }
	
            return commandReceived;
		}*/
		
		void AnalyzeReceivedData()
		{	
			//lblCount.Text = "";
			StringBuilder sb = new StringBuilder();
			double[] input = list.Select(pointPair => pointPair.Y).ToArray();
			double[] samples = new Double[input.Length];
			int decimateFactor = (int)numDecimateFactor.Value;
			
			// Calculate moving average with SimpleRunningAverage class
			//SimpleRunningAverage avg = new SimpleRunningAverage(4);			
			for(int i=0; i<input.Length; i++) 
			{
				//samples[i] = avg.Add(input[i]);
				samples[i] = input[i];
	        }				

			// Build list2 with filtered values to plot a new curve in graph pane
			int j = 0;
			list2.Clear();
			foreach (PointPair p in list)
			{	
				// Decimate result data
				if (j % decimateFactor == 0)
					list2.Add(p.X, samples[j]);
				j++;
			}						
			
			// Loop to detect a drop from measurement data
			///////////////////////////////////////////////////
			// Threshold is 0.05 V (992 / 65535 * 3.3 V = 0.04995 V)
			int thresh = 794; // 794 = 0.04 V 
  			int dropCount = 0;
  			StringBuilder sb2 = new StringBuilder();
			samples = list2.Select(pointPair => pointPair.Y).ToArray();
			double xScale = (sampleInterval * decimateFactor) * 1000.0;
			Int16 dxsum = 0;
			
			list3.Clear();
			
			// Iterate sample buffer to detect drops
  			for(int i = 1; i < samples.Length; i++)
			{
				// Calculate delta between previous and current sample
	  			dxsum += (Int16)((samples[i-1]-samples[i])*65535.0/3.3);  				
	  			//sb2.AppendLine(i.ToString() + ": " + dx.ToString());
					  			
	  			if ((i % 2) == 0)
	  			{
	  				//sb2.AppendLine(i.ToString() + ": " + dxsum.ToString());
	  				// If sum exceeds threshold -> drop detected
	  				if (dxsum < (thresh * -2))
	  				{
	  					dropCount++;
	  					list3.Add( (i-1) * xScale, samples[i-1]);
	  					i += (10 / decimateFactor); // discard next samples to avoid double detect
	  					if (i < samples.Length)
	  						list3.Add( i * xScale, 0.0);
		  				//sb2.AppendLine(i.ToString() + ": " + dxsum.ToString());
	  				}
	  				dxsum = 0;
	  			}	  			
	  			else
	  			{
	  				list3.Add( i * xScale, samples[i]);
	  			}
			}
  			Debug.WriteLine(sb2.ToString());
  			
  			// Update drop count
  			dropCount += int.Parse(lblCount.Text);
  			lblCount.Text = dropCount.ToString();
  					
			// Plot curves in graph control
			myPane.CurveList.Clear();
			myAnalCurve = myPane.AddCurve( "filtered", list2, Color.Red, SymbolType.Circle);	
			myCurve = myPane.AddCurve( "p20(in)", list, Color.Blue, SymbolType.XCross);			
			myDropCurve = myPane.AddCurve( "drops", list3, Color.Black, SymbolType.Star);	
			
			zg1.AxisChange();
			zg1.Invalidate();
			zg1.Refresh();			
		}		
	}
	
	class SimpleRunningAverage
	{
	  int _size;
	  double[] _values = null;
	  int _valuesIndex = 0;
	  int _valueCount = 0;
	  double _sum = 0;
	
	  public SimpleRunningAverage(int size)
	  {
	     System.Diagnostics.Debug.Assert(size > 0);
	     _size = Math.Max(size, 1);
	     _values = new double[_size];
	  }
	
	  public double Add(double newValue)
	  {
	     // calculate new value to add to sum by subtracting the
	     // value that is replaced from the new value;
	     double temp = newValue - _values[_valuesIndex];
	     _values[_valuesIndex] = newValue;
	     _sum += temp;
	
	     _valuesIndex++;
	     _valuesIndex %= _size;
	    
	     if (_valueCount < _size)
	        _valueCount++;
	
	     return _sum / _valueCount;
	  }      
	} 	
}

