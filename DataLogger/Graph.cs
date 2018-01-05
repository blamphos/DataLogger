using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using ZedGraph;

namespace DataLogger
{
	public partial class MainForm : Form
	{	
		GraphPane myPane = new GraphPane();
		PointPairList list = new PointPairList();
		PointPairList list2 = new PointPairList();
		PointPairList list3 = new PointPairList();
		LineItem myCurve;
		LineItem myAnalCurve;
		LineItem myDropCurve;
		
		private void CreateGraph(  )
		{			
			myPane = zg1.GraphPane;

			// Set the titles and axis labels
			myPane.Title.Text = "ADC result";
			myPane.XAxis.Title.Text = "Samples";
			myPane.YAxis.Title.Text = "Amplitude [V]";

			// Make up some data points from the Sine function
			//PointPairList list = new PointPairList();
			for ( double x = 0; x < 36; x++ )
			{
				double y = Math.Sin( x * Math.PI / 15.0 );

				list.Add( x, y );
			}

			// Generate a blue curve with circle symbols, and "My Curve 2" in the legend
			myCurve = myPane.AddCurve( "p20(in)", list, Color.Blue, SymbolType.Circle );			
			// Fill the area under the curve with a white-red gradient at 45 degrees
			//myCurve.Line.Fill = new Fill( Color.White, Color.Red, 45F );
			// Make the symbols opaque by filling them with white
			myCurve.Symbol.Fill = new Fill( Color.White );

			// Fill the axis background with a color gradient
			myPane.Chart.Fill = new Fill( Color.White, Color.LightGoldenrodYellow, 45F );

			// Fill the pane background with a color gradient
			myPane.Fill = new Fill( Color.White, Color.FromArgb( 220, 220, 255 ), 45F );

  			// Show the x axis grid
   			myPane.XAxis.MajorGrid.IsVisible = true;
   			// Show the y axis grid
   			myPane.YAxis.MajorGrid.IsVisible = true;
   
			// Calculate the Axis Scale Ranges
			zg1.AxisChange();
		}
		
		public void UpdateGraph()
		{			
			myPane.CurveList.Clear();
			
			myCurve = myPane.AddCurve( "ADC (in)", list, Color.Blue, SymbolType.Diamond );			
			//myAnalCurve = myPane.AddCurve( "filtered", list2, Color.Red, SymbolType.Circle);	
			//myDropCurve = myPane.AddCurve( "drops", list3, Color.Black, SymbolType.Star);	
			
		    myPane.YAxis.Scale.Min = (double) numericUpDownYMin.Value;
		    myPane.YAxis.Scale.Max = (double) numericUpDownYMax.Value;
		    myPane.YAxis.Scale.MaxAuto = false;
        	//zg1.RestoreScale(myPane);
        	//zg1.ZoomOut(myPane);
			zg1.AxisChange();
			zg1.Refresh();
		}
	}
}