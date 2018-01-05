/*
 * Created by SharpDevelop.
 * User: RTM
 * Date: 31.12.2017
 * Time: 14:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataLogger
{
	/// <summary>
	/// Description of IrDecoder.
	/// </summary>
	public class IrDecoder
	{
		const int IR_SAMPLING_PERIOD_US = 100;
		
		// Samsung IR codes (32-bit data)
		const long IR_TV_VOL_UP = 0xF8070707;
		const long IR_TV_VOL_DOWN = 0xF40B0707;
		const long IR_TV_VOL_MUTE = 0xF00F0707;
		
		// IR Timing
		// UL => Upper Tolerance Limit; LL => Lower Tolerance Limit
		const int IR_TOLERANCE_US = 	IR_SAMPLING_PERIOD_US * 2;
		const int IR_START_BIT_US = 	9000;
		const int IR_DATA_BIT_ZERO_US = 1120;
		const int IR_DATA_BIT_ONE_US = 	2250;
		
		const int IR_START_BIT_US_LL = 		IR_START_BIT_US - IR_TOLERANCE_US;
		const int IR_START_BIT_US_UL = 		IR_START_BIT_US + IR_TOLERANCE_US;
		const int IR_DATA_BIT_ZERO_US_LL =  IR_DATA_BIT_ZERO_US - IR_TOLERANCE_US;
		const int IR_DATA_BIT_ZERO_US_UL =  IR_DATA_BIT_ZERO_US + IR_TOLERANCE_US;
		const int IR_DATA_BIT_ONE_US_LL = 	IR_DATA_BIT_ONE_US - IR_TOLERANCE_US;
		const int IR_DATA_BIT_ONE_US_UL =   IR_DATA_BIT_ONE_US + IR_TOLERANCE_US;				
		
		public enum IrCommandType
		{
			IrTvVolUp,
			IrTvVolDown,
			IrTvVolMute			
		}
		
		enum IrBitType
		{
			IR_INVALID = -1,
			IR_DATA_BIT_ONE,
			IR_DATA_BIT_ZERO,
			IR_START_BIT
		}
		
        bool pulseHigh = false;
        int databits = 0;
        int length = 0;
        readonly List<int> pulseLengths = new List<int>();
        bool receiving = false;
        long data = 0;
        bool commandReceived = false;
        IrBitType bitType;
            
		public IrDecoder()
		{
			Reset();
		}
		
		IrBitType GetBitType(int samples)
		{
			var pulseLengthUs = IR_SAMPLING_PERIOD_US * samples;
			//Debug.Write(pulseLengthUs);
			
			if (pulseLengthUs >= IR_START_BIT_US_LL && pulseLengthUs < IR_START_BIT_US_UL)
			{
				return IrBitType.IR_START_BIT;
			}
			else if (pulseLengthUs >= IR_DATA_BIT_ONE_US_LL && pulseLengthUs < IR_DATA_BIT_ONE_US_UL)
			{
				return IrBitType.IR_DATA_BIT_ONE;
			}
			else if (pulseLengthUs >= IR_DATA_BIT_ZERO_US_LL && pulseLengthUs < IR_DATA_BIT_ZERO_US_UL)
			{
				//Debug.WriteLine("'0' bit: " + pulseLengthUs);
				return IrBitType.IR_DATA_BIT_ZERO;
			}
			/*else if (pulseLengthUs < IR_DATA_BIT_ZERO_US_UL)
			{
				return IrBitType.IR_DATA_BIT_ZERO; 
			}*/
			
			return IrBitType.IR_INVALID;
		}
		
		public void Reset()
		{
			pulseHigh = false;
			databits = 0;
			length = 0;
			pulseLengths.Clear();
			receiving = false;
			data = 0;
			commandReceived = false;
			bitType = IrBitType.IR_INVALID;
			
			Debug.WriteLine("IR detection reset");
		}
		
		public bool AnalyzeData(List<double> points)
		{
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
                                    //receiving = false;
                                    // Invalid bit received --> clear all and start over
                                    Reset();
                                    continue;
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
                                    	//lblCount.Text = "UP"; 
                                    	commandReceived = true;
                                    	//SendKeys.SendWait("{UP}");
                                    }
                                    else if ((data & 0xFFFFFFFF) == IR_TV_VOL_DOWN)
                                    {
                                    	//lblCount.Text = "DOWN";
                                    	commandReceived = true;
                                    	//SendKeys.SendWait("{DOWN}");
                                    }
                                    else if ((data & 0xFFFFFFFF) == IR_TV_VOL_MUTE)
                                    {
                                    	//lblCount.Text = "MUTE";
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
		}
	}
}
