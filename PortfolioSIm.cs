// =====================  <<<<< DISCLAIMER >>>>>  =====================================================================//
// This script is for demonstration purposes only and the results it generates do not pretend to be accurate nor
// should they be relied on as such. By using this script you accept and understand the above.
// --------------------------------------------------------------------------------------------------------------------//
// SET UP THE MODEL HERE ==============================================================================================//
// Adjust the system scaling in each system to select the relative volatility
// and set an overall scaling and starting captial for all systems in the scenario
// to adjust the overall portfolio volatility
var scenarios = new[] {

	new {
		name="TOS Top 5, age>100, trades>100",
		startingCap=20000,
		scaling=1.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(122037920, "Currency VIX", 1.0),
			Tuple.Create(122174703, "AlgoSys YM - Andromalius",  2.0),
			Tuple.Create(116744132, "PFSignal", 5.0),
			Tuple.Create(102427283, "Smart Volatility Margin", 1.0),
			Tuple.Create(102427198, "Smart Volatility IRA", 1.0),
		}
	},
/*  new {
    name="Older TOS",
    startingCap=50000,
    scaling=2.0,
    systems = new[] {
      // SystemID, SystemName, SystemScaling
      Tuple.Create(102427198,"Smart Volatility IRA", 0.2),
      Tuple.Create(102237387,"25K Emini SP Portfolio",1.0),
      Tuple.Create(102110837,"Correlation Factor",1.0),
      Tuple.Create(81128026,"Carma Stocks",3.0),
      Tuple.Create(102749732,"Euro vs USD",3.0),
    }
   },
   new {
    name="TOS, trades>=100, age>1yr, dd<25",
    startingCap=50000,
    scaling=1.0,
    systems = new[] {
      // SystemID, SystemName, SystemScaling
      Tuple.Create(102427198,"Smart Volatility IRA", 1.0),
      Tuple.Create(112786719,"Smart Bull Portfolio",1.0),
      Tuple.Create(109496813,"30k Futures Portfolio",1.0),
      Tuple.Create(102237387,"25K Emini SP Portfolio",1.0),
      //Tuple.Create(95384675,"Annas Stocks",1.0),
    }
   },
 */

	new {
		name="Alchemy",
		startingCap=50000,
		scaling=2.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(100722273, "VolatilityTrader", 0.1),
			//Tuple.Create(116711157, "Waverunner", 0.1),//Autrading since 28-6-18
			Tuple.Create(94987184,  "Just Forex Trades",  1.0),//Autotrading since 1-6-16
			Tuple.Create(115990904, "Diamond 4x", 0.5),//Autotrading since 21-1-18
		}
	},

/*
   new {
    name="AlchemyX2",
    startingCap=50000,
    scaling=4.0,
    systems = new[] {
      // SystemID, SystemName, SystemScaling
      Tuple.Create(100722273, "VolatilityTrader", 0.1),
      Tuple.Create(116711157, "Waverunner", 0.1),//Autrading since 28-6-18
      Tuple.Create(94987184,  "Just Forex Trades",  1.0),//Autotrading since 1-6-16
      Tuple.Create(115990904, "Diamond 4x", 0.5),//Autotrading since 21-1-18
    }
   },
 */

	new {
		name="Golden Goose",
		startingCap=50000,
		scaling=2.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(100722273, "VolatilityTrader", 0.1),
			Tuple.Create(113004400, "COREX", 2.0),
			Tuple.Create(94987184,  "Just Forex Trades",  1.0),
			Tuple.Create(115990904, "Diamond 4x", 0.5),
		}
	},

	new {
		name="Golden Goose~",
		startingCap=50000,
		scaling=2.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(100722273, "VolatilityTrader", 0.1),
			Tuple.Create(113004400, "COREX", 2.5),
			Tuple.Create(94987184,  "Just Forex Trades",  1.0),
			Tuple.Create(115990904, "Diamond 4x", 0.75),
		}
	},

	new {
		name="Golden Goose 2~",
		startingCap=50000,
		scaling=2.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(100722273, "VolatilityTrader", 0.1),
			Tuple.Create(113004400, "COREX", 4.0),
			Tuple.Create(94987184,  "Just Forex Trades",  1.0),
			Tuple.Create(115990904, "Diamond 4x", 0.75),
		}
	},

	new {
		name="Golden Goose #3",
		startingCap=50000,
		scaling=2.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(100722273, "VolatilityTrader", 0.1),
			Tuple.Create(113004400, "COREX", 5.0),
			Tuple.Create(94987184,  "Just Forex Trades",  1.0),
			Tuple.Create(115990904, "Diamond 4x", 0.75),
		}
	},

	new {
		name="Golden Goose #3- Mini",
		startingCap=25000,
		scaling=1.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(100722273, "VolatilityTrader", 0.1),
			Tuple.Create(113004400, "COREX", 5.0),
			Tuple.Create(94987184,  "Just Forex Trades",  1.0),
			Tuple.Create(115990904, "Diamond 4x", 0.75),
		}
	},

	new {
		name="Golden Goose #3- Mini - SVMb",
		startingCap=13000,
		scaling=1.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(102427283, "Smart Vol Margin", 3.0),
			Tuple.Create(113004400, "COREX", 5.0),
			Tuple.Create(94987184,  "Just Forex Trades",  1.0),
			Tuple.Create(115990904, "Diamond 4x", 0.75),
		}
	},

/*
   new {
    name="Live",
    startingCap=13000,
    scaling=1.0,
    systems = new[] {
      // SystemID, SystemName, SystemScaling
      Tuple.Create(102427283, "Smart Vol Margin", 0.5),
      Tuple.Create(113004400, "COREX", 0.5),
      Tuple.Create(94987184,  "Just Forex Trades",  0.5),
      Tuple.Create(115990904, "Diamond 4x", 0.75),
    }
   },
   new {
    name="Live ~",
    startingCap=13000,
    scaling=1.0,
    systems = new[] {
      // SystemID, SystemName, SystemScaling
      Tuple.Create(102427283, "Smart Vol Margin", 1.0),
      Tuple.Create(113004400, "COREX", 1.0),
      Tuple.Create(94987184,  "Just Forex Trades",  0.25),
      Tuple.Create(115990904, "Diamond 4x", 0.20),
    }
   },
 */

	new {
		name="Bean Stalk",
		startingCap=50000,
		scaling=2.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(100722273, "VolatilityTrader", 0.1),
			Tuple.Create(113004400, "COREX", 2.0),
			Tuple.Create(94987184,  "Just Forex Trades",  1.0),
			Tuple.Create(115990904, "Diamond 4x", 0.5),
			Tuple.Create(112786719, "Smart Bull Portfolio",  2.0),
		}
	},

};

// CODE BELOW HERE =====================================================================================================//
// Get some colors to use
List<System.Drawing.Color> colors = new List<System.Drawing.Color>(new System.Drawing.Color[]
                                                                   {Color.Blue, Color.Brown, Color.Red, Color.Green, Color.Orange, Color.Purple,
                                                                    Color.Pink, Color.DarkGreen, Color.DarkBlue, Color.Olive}
                                                                   );
// Select the output reports
bool showStats = true;
bool showCorrelation = false;
// Do the simulation for these Time Intevals
TimeInterval[] timeIntervals= new[] {TimeInterval.Day, TimeInterval.Month};

// Normally we just use the earliest date common to all system but if you
// want to limit the date range further set a date for inception here
DateTime StartDate = DateTime.Parse("1-jan-2000");
//		 StartDate = DateTime.Parse("19-jan-2018");
// 'WaveRunner' has some suss data before the autraders signed on
StartDate = DateTime.Parse("9-mar-2018");

List<dynamic> scenarioStats = new List<object>();
List<object> debug = new List<object>();

// SCENARIO LOOP BELOW HERE =====================================================================================================//
foreach (var scenario in scenarios) {
	foreach (var timeInterval in timeIntervals ) {
		int colorIndex = 0;
		var startEq = scenario.startingCap;

		// Get the Monthly equity data with commissions and fees
		ITimeSheet timeSheet = TimeSheetFactory( scenario.systems.Select(id => (long)id.Item1),
		                                         timeInterval,
		                                         EquityType.Equity|EquityType.Diff );

		// return Equity Sheet as sparse Deedle.Frame
		var sparseEquityFrame = timeSheet.EquitiesSheet(false);

		// Drop rows from the frame which dont have data for all systems
		var denseEquityFrame = FrameModule.DropSparseRows(sparseEquityFrame);
		// Make a new empty frame with the same keys
		var myFrame = Frame.FromRowKeys(denseEquityFrame.RowKeys.Where(k=>k>=StartDate));

		// Create a chart objects
		ITimeSeriesChart systemsChart = new TimeSeriesChart();
		systemsChart.Name = "Strategies equity progression";
		IChartTimeSeries systemsSeries = new ChartTimeSeries();
		systemsSeries.Type = ChartTypes.Line;

		ITimeSeriesChart portfolioChart = new TimeSeriesChart();
		portfolioChart.Name = "Portfolio equity progression";
		IChartTimeSeries portfolioSeries = new ChartTimeSeries();
		portfolioSeries.Type = ChartTypes.Line;

		var sysData = new List<dynamic>();

		// Iterate our system list
		foreach ( var system in scenario.systems ) {
			var scaling = system.Item3 * scenario.scaling;

			// We'll lookup the system name from the database so that spelling errors in our own list wont give us grief
			String sysName = C2SYSTEMS.Where(s=>s.SystemId == system.Item1).Select(s=>s.SystemName).First();

			// get the "diffs" for this system
			var diffs = denseEquityFrame.GetColumn<decimal>(sysName+" [diff]").Observations.Where(kvp=>kvp.Key>=StartDate).ToList();
			// open some new lists
			var eqty = new List<KeyValuePair<DateTime,decimal> >();
			var ret = new List<KeyValuePair<DateTime,decimal> >();

			for (var i=0; i<diffs.Count; i++) {
				eqty.Add( new KeyValuePair<DateTime,decimal>(
							  diffs[i].Key,
							  (i==0) ? startEq : (eqty[i-1].Value + diffs[i].Value * (decimal)scaling) )
				          );
				ret.Add( new KeyValuePair<DateTime,decimal>(
							 diffs[i].Key,
							 (i==0) ? 0 : Math.Round(((eqty[i].Value/eqty[i-1].Value)-1)*100,2 ))
				         );
			}

			var eqPoints = new Series<DateTime,decimal>( eqty );

			myFrame.AddColumn(sysName+" Eq", eqPoints);
			myFrame.AddColumn(sysName+" Ret", new Series<DateTime,decimal>(ret) );

			systemsChart.Add(eqPoints,
			                 String.Format("{0}({1:N0}%)",sysName,scaling*100),
			                 colors[colorIndex++]);

			double divisor=100;
			var rets = ret.Select(kv=>(double)kv.Value);
			if (timeInterval == TimeInterval.Day) divisor=365;
			if (timeInterval == TimeInterval.Month) divisor=12;

			var sd = new RunningStatistics(rets.Select(d=>d*divisor/100)).StandardDeviation;
			var u = new RunningStatistics(rets.Select(d=>d*divisor)).Mean;
			var sharpe = (u - 2.5 ) / sd;
			sysData.Add( new {
				System = sysName,
				Mean_ROI = String.Format("{0:N1}",u),
				SD = String.Format("{0:N0}",sd),
			});
		}

		// Combined the strategies performance into a portfolio
		var eqyKeys = myFrame.ColumnKeys.Where( key=>key.Contains("Eq") );
		var rowKeys = myFrame.RowKeys;
		var myEqty = new List<KeyValuePair<DateTime,decimal> >();
		// foreach DateTime
		foreach (var row in rowKeys) {
			decimal total = 0;
			// get the equity point of each system
			foreach (var col in eqyKeys) {
				total += (decimal)myFrame[col,row];
			}
			myEqty.Add( new KeyValuePair<DateTime,decimal>(row, total) );
		}
		var lastChange = myEqty[myEqty.Count-1].Value - myEqty[myEqty.Count-2].Value;
		var portfolioEquitySeries = new Series<DateTime,decimal>( myEqty );
		portfolioChart.Add(portfolioEquitySeries, "Portfolio", Color.Blue);

		// Calculate Bollinger bands
		var bbtop = C2TALib.BBandTop(portfolioEquitySeries, 15, 2.0);
		var bbbot = C2TALib.BBandBot(portfolioEquitySeries, 15, 2.0);
		var ma15 = C2TALib.MA(portfolioEquitySeries, 14);


		// Add equity to the chart
		//portfolioChart.Add(equity, "Equity", Color.Blue);

		// Add upper BBand
		//portfolioChart.Add(bbtop, "BBTop", Color.Black);
		// Add lower BBand
		//portfolioChart.Add(bbbot, "BBBot", Color.Black);
		// Add MA
		//portfolioChart.Add(ma15, "MA15", Color.Red);


		// Find CAGR
		var startDate = portfolioEquitySeries.Observations.First().Key;
		var endDate = portfolioEquitySeries.Observations.Last().Key;
		var startEqy = portfolioEquitySeries.Observations.First().Value;
		var endEq = portfolioEquitySeries.Observations.Last().Value;
		double cagr = Math.Pow( ((double)endEq/(double)startEqy), 1/((double)((endDate-startDate).Days)/365) )-1;

		double mrpp = ((cagr-1) * (double)startEqy) / ((timeInterval == TimeInterval.Day) ? 365 : 12);

		// Find MaxDD
		var prices = portfolioEquitySeries.Values.ToList();
		decimal maxPrice = prices[0];
		// Drawdrown as ocurred over last high
		decimal maxDd = 0;
		// Drawndown if occurred at portfolio inception
		decimal maxDd3 = 0;

		for (int i = 1; i < prices.Count; i++) {
			if (prices[i] > maxPrice)
				maxPrice = prices[i];
			else if (prices[i] < maxPrice)
				maxDd = Math.Min(maxDd, (prices[i] - maxPrice ) / maxPrice);
			maxDd3 = Math.Min(maxDd3, (prices[i] - maxPrice ) / prices[0]);
		}
		// RECORD some overall stats -----------------
		scenarioStats.Add( new {
			Scenario = scenario.name,
			TimeFrame = timeInterval.ToString(),
			CAGR = Math.Round(cagr * 100,0),
			ObservedDD = Math.Round(maxDd * 100,0),
			InceptionDD = Math.Round(maxDd3 * 100,0),
			MRPP = Math.Round(mrpp, 0),
			Last = Math.Round(lastChange, 0),
		});
		// OUTPUT THE DATA ==============================================================================================//
		//TABLE=FrameToTable(denseEquityFrame);
		//TABLE=FrameToTable(myFrame);
		HTML = @"<p style='page-break-before: always;'>";
		//HTML = "<br/>";
		H1=scenario.name + " - " + timeInterval.ToString();
		H4=endDate.ToString();
		TEXT=String.Format("CAGR: {0:n0}%",cagr * 100);
		TEXT=String.Format("MaxDD Recorded: {0:N1}%",maxDd * 100);
		TEXT=String.Format("MaxDD Worst Case: {0:N1}% (if max draw down occurred at inception)",maxDd3 * 100);
		TEXT=String.Format("Last period: ${0:N0}", lastChange);
		CHART=portfolioChart;
		HR();
		CHART=systemsChart;
		if (showStats) {
			H3="Modified system performance";
			TABLE=sysData;
		}
		HR();

	}//TimeFrame
	if (showStats) {
		var sysStats = new List<dynamic>();
		foreach (var system in scenario.systems) {
			var sys = C2SYSTEMS.Where(s=>s.SystemId == system.Item1).First();
			var stats = C2STATS.Where(stat=>stat.SystemId==sys.SystemId);

			sysStats.Add( new {
				Name = sys.SystemName,
				Age = (DateTime.Now - sys.Started).Days,
				Trades = stats.Where(s=>s.StatName=="numtrades").Select(s=>s.StatValueVal).First(),
				Class = stats.Where(s=>s.StatName=="trades").Select(s=>s.StatValueChar).First(),
				//SubsAll = stats.Where(s=>s.StatName=="numSubsAll").Select(s=>s.StatValueVal).First(),
				//SubsNow = stats.Where(s=>s.StatName=="numSubsNow").Select(s=>s.StatValueVal).First(),
				Tos = stats.Where(s=>s.StatName=="ownerAutoTradesPcnt").Select(s=>s.StatValueVal).First(),
				AnnReturn = stats.Where(s=>s.StatName=="jAnnReturn").Select(s=>s.StatValueVal).First()*100,
				ProfitFactor = stats.Where(s=>s.StatName=="profitFactor").Select(s=>s.StatValueVal).First(),
				Sharpe = stats.Where(s=>s.StatName=="jSharpe").Select(s=>s.StatValueVal).First(),
				Sortino = stats.Where(s=>s.StatName=="jSortino").Select(s=>s.StatValueVal).First(),
				Calmar = stats.Where(s=>s.StatName=="jCalmar").Select(s=>s.StatValueVal).First(),
			});
		}
		H3="C2 Recorded System Stats";
		TABLE=sysStats;
	}
	if (showCorrelation) {
		H3="System CorrelationData";
		TABLE = GetCorrelationTable(scenario.systems.Select(s=>(long)s.Item1));
	}
	HR();


}//Scenario
HR();
H2="Scenarios compared:";
TABLE=scenarioStats.OrderBy(x=>x.TimeFrame).ThenBy(x=>x.Scenario);


//H1 = "DEBUG:";
//  TABLE=debug;
