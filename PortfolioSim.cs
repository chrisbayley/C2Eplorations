// =====================  <<<<< DISCLAIMER >>>>>  =====================================================================//
// This script is for demonstration purposes only and the results it generates do not pretend to be accurate nor
// should they be relied on as such. By using this script you accept and understand the above.
// --------------------------------------------------------------------------------------------------------------------//
// SET UP THE MODEL HERE ==============================================================================================//
// Adjust the system scaling in each system to select the relative volatility
// and set an overall scaling and starting captial for all systems in the scenario
// to adjust the overall portfolio volatility, or set autoScaling=true for auto scaling according to model equity at start date
// Normally we just use the earliest date common to all system but if you
// want to limit the date range further set a date for inception in 'startDate'
// 'startingCap' is shared equally among all systems
// Set 'scaling = 0.0' to use AutoScaling. If using Auto scaling start with SystemScaling=1.0 then adjust to taste. SystemScaling
// is applied on top of the Autoscaling
// the Margin line on the portfolio DOES NOT show margin requirements on FX systems!!
var scenarios = new[] {
	new {
		name="Age>365,Trades>100,AR>50,DD<20 2-Apr-20 - AUTO",
		enabled=false,
		startingCap=400000,
		scaling=0.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(122087689, "Open Energy", 1.0),
			Tuple.Create(121637339, "Stock Dow",  1.0),
			Tuple.Create(123071731,  "Mini Dow 123071731",  1.0),
			Tuple.Create(122397210, "Futrs Only", 1.0),
			Tuple.Create(122775625, "VIX TVIX ETFs", 1.0),
		}
	},
	new {
		name="Life post JFT - Auto Scaled",
		enabled=false,
		startingCap=100000,
		scaling=0.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(124998567, "abasacJAR 4X", 1.0 ),
			//Tuple.Create(94987184,  "Just Forex Trades",  0.375),
			//Tuple.Create(123472063, "dax and FB Global", 2.5),
			//Tuple.Create(125935591, "Klarity", 1.0),
			//Tuple.Create(117442067, "Carma Managed Future",1.0),
			//Tuple.Create(125428941, "Clear Futures", 1.0),
			Tuple.Create(102081384, "OPN W888", 0.5),
			Tuple.Create(125587405, "Stock Star", 3.0),
		}
	},
	new {
		name="Life post JFT - Option A",
		enabled=false,
		startingCap=400000,
		scaling=1.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(124998567, "abasacJAR 4X", 6.0 ),
			Tuple.Create(125935591, "Klarity", 3.0),
			Tuple.Create(117442067, "Carma Managed Future",1.0),
			Tuple.Create(125428941, "Clear Futures", 3.0),
		}
	},
	new {
		name="Life post JFT - Option B",
		enabled=false,
		startingCap=400000,
		scaling=2.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(124998567, "abasacJAR 4X", 4.0 ),
			Tuple.Create(125587405, "Stock Star", 3.0),
			Tuple.Create(102081384, "OPN W888", 0.5),
			//Tuple.Create(94987184,  "Just Forex Trades",  0.375),
		}
	},
	new {
		name="Heave to",
		enabled=true,
		startingCap=40000,
		scaling=0.5,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(124998567, "abasacJAR 4X", 4.0 ),
			Tuple.Create(125587405, "Stock Star", 3.0),
			Tuple.Create(102081384, "OPN W888", 0.5),
			Tuple.Create(125624499, "Dow M",2.0)
		}
	},

	new {
		name="PPR",
		enabled=false,
		startingCap=30000,
		scaling=1.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(120622361, "NQ Kingpin", 0.7 ),
			Tuple.Create(115023400, "Crude Oil Trader Z", 0.5),
			Tuple.Create(119232154, "PegasiCap", 0.5),
		}
	},
	new {
		name="PPR Auto",
		enabled=false,
		startingCap=30000,
		scaling=0.0,
		systems = new[] {
			// SystemID, SystemName, SystemScaling
			Tuple.Create(120622361, "NQ Kingpin", 1.0 ),
			Tuple.Create(115023400, "Crude Oil Trader Z", 1.0),
			Tuple.Create(119232154, "PegasiCap", 1.0),
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
bool showBollingerBands = false;

// Do the simulation for these Time Intevals
TimeInterval[] timeIntervals= new[] {TimeInterval.Day, TimeInterval.Month};
//TimeInterval[] timeIntervals= new[] {TimeInterval.Day};

// Normally we just use the earliest date common to all system but if you
// want to limit the date range further set a date for inception here
DateTime StartDate = DateTime.Parse("1-jan-2000");
//	 StartDate = DateTime.Parse("1-dec-2019");

List<dynamic> scenarioStats = new List<object>();
List<object> debug = new List<object>();

// SCENARIO LOOP BELOW HERE =====================================================================================================//
foreach (var scenario in scenarios) {
	if (!scenario.enabled) continue;
	foreach (var timeInterval in timeIntervals ) {
		int colorIndex = 0;
		var startEq = scenario.startingCap / scenario.systems.Length;

		// Get the Monthly equity data with commissions and fees
		ITimeSheet timeSheet = TimeSheetFactory( scenario.systems.Select(id => (long)id.Item1),
		                                         timeInterval,
		                                         EquityType.Equity|EquityType.Diff|EquityType.MarginUsed );

		// return Equity Sheet as sparse Deedle.Frame
		var sparseEquityFrame = timeSheet.EquitiesSheet(false);
		// Drop rows from the frame which dont have data for all systems
		var denseEquityFrame = FrameModule.DropSparseRows(sparseEquityFrame);

		//TABLE = FrameToTable(denseEquityFrame);

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
			double scaling;

			// We'll lookup the system name from the database so that spelling errors in our own list wont give us grief
			String sysName = C2SYSTEMS.Where(s=>s.SystemId == system.Item1).Select(s=>s.SystemName).First();

			// get the "diffs" for this system
			var diffs = denseEquityFrame.GetColumn<decimal>(sysName+" [diff]").Observations.Where(kvp=>kvp.Key>=StartDate).ToList();

			// Get the equity values of the system
			var eqs   = denseEquityFrame.GetColumn<decimal>(sysName+" [eq]").Observations.Where(kvp=>kvp.Key>=StartDate).ToList();

			// Get the MarginUsed values of the system
			var mrgs   = denseEquityFrame.GetColumn<decimal>(sysName+" [mrgn]").Observations.Where(kvp=>kvp.Key>=StartDate).ToList();

			// use the most recent Equity to determnine the value for our scaling
			var modelEq = eqs.Last().Value;

			//TABLE = from eq in eqs select new {Date = eq.Key, EQ = eq.Value };
			//TEXT=String.Format("{0} modelEq(${1:N1})",sysName,modelEq);

			if ( scenario.scaling == 0.0 )
				scaling = (double)startEq / (double)modelEq * system.Item3;
			else
				scaling = system.Item3 * scenario.scaling;

			// open some new lists
			var eqty = new List<KeyValuePair<DateTime,decimal> >();
			var ret = new List<KeyValuePair<DateTime,decimal> >();
			var mu = new List<KeyValuePair<DateTime,decimal> >();

			for (var i=0; i<diffs.Count; i++) {
				eqty.Add( new KeyValuePair<DateTime,decimal>(
							  diffs[i].Key,
							  (i==0) ? startEq : (eqty[i-1].Value + diffs[i].Value * (decimal)scaling) )
				          );
				ret.Add( new KeyValuePair<DateTime,decimal>(
							 diffs[i].Key,
							 (i==0) ? 0 : Math.Round(((eqty[i].Value/eqty[i-1].Value)-1)*100,2 ))
				         );
				mu.Add( new KeyValuePair<DateTime,decimal>(
							diffs[i].Key,
							mrgs[i].Value * (decimal)scaling )
				        );
			}

			var eqPoints = new Series<DateTime,decimal>( eqty );
			var mgnPoints = new Series<DateTime,decimal>( mu );

			myFrame.AddColumn(sysName+" Eq", eqPoints);
			myFrame.AddColumn(sysName+" Ret", new Series<DateTime,decimal>(ret) );
			myFrame.AddColumn(sysName+" Mgn", mgnPoints );

			systemsChart.Add(eqPoints,
			                 String.Format("{0}({1:N1}%)",sysName,scaling*100),
			                 colors[colorIndex++]);

			/* systemsChart.Add(mgnPoints,
			   String.Format("{0}({1:N1}%)",sysName,scaling*100),
			   colors[colorIndex++]);
			 */
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
				Sharpe = String.Format("{0:N2}", sharpe),
			});
		}

		// Combined the strategies performance into a portfolio
		var eqyKeys = myFrame.ColumnKeys.Where( key=>key.Contains("Eq") );
		var mgnKeys = myFrame.ColumnKeys.Where( key=>key.Contains("Mgn") );
		var rowKeys = myFrame.RowKeys;
		var myEqty = new List<KeyValuePair<DateTime,decimal> >();
		var myMrgn = new List<KeyValuePair<DateTime,decimal> >();

		// foreach DateTime
		foreach (var row in rowKeys) {
			decimal total = 0;
			// get the equity point of each system
			foreach (var col in eqyKeys) {
				total += (decimal)myFrame[col,row];
			}
			myEqty.Add( new KeyValuePair<DateTime,decimal>(row, total) );
			total = 0;
			// get the equity point of each system
			foreach (var col in mgnKeys) {
				total += (decimal)myFrame[col,row];
			}
			myMrgn.Add( new KeyValuePair<DateTime,decimal>(row, total) );
		}
		var lastChange = myEqty[myEqty.Count-1].Value - myEqty[myEqty.Count-2].Value;
		var portfolioEquitySeries = new Series<DateTime,decimal>( myEqty );
		var portfolioMarginSeries = new Series<DateTime,decimal>( myMrgn );
		portfolioChart.Add(portfolioEquitySeries, "Equity", Color.Blue);
		portfolioChart.Add(portfolioMarginSeries, "Margin", Color.Red);

		//var dd = portfolioEquitySeries.Values.Select(a => (double)a).ToList();
		//TEXT = string.Join(", ", dd );

		if (showBollingerBands) {
			// Calculate Bollinger bands
			var bbtop = C2TALib.BBandTop(portfolioEquitySeries, 15, 2.0);
			var bbbot = C2TALib.BBandBot(portfolioEquitySeries, 15, 2.0);
			var ma15 = C2TALib.MA(portfolioEquitySeries, 14);

			// Add upper BBand
			portfolioChart.Add(bbtop, "BBTop", Color.Black);
			// Add lower BBand
			portfolioChart.Add(bbbot, "BBBot", Color.Black);
			// Add MA
			portfolioChart.Add(ma15, "MA15", Color.Red);
		}

		// Find CAGR
		var startDate = portfolioEquitySeries.Observations.First().Key;
		var endDate = portfolioEquitySeries.Observations.Last().Key;
		var startEqy = portfolioEquitySeries.Observations.First().Value;
		var endEq = portfolioEquitySeries.Observations.Last().Value;
		double cagr = Math.Pow( ((double)endEq/(double)startEqy), 1/((double)((endDate-startDate).Days)/365) )-1;

		//double mrpp = ((cagr) * (double)startEqy) / ((timeInterval == TimeInterval.Day)? 365:12);
		double mrpp = (((double)endEq-(double)startEqy) / (endDate-startDate).Days) * ((timeInterval == TimeInterval.Day) ? 1 : 30);

		//TEXT=String.Format("days: {0:n0}",(endDate-startDate).Days);
		//TEXT=String.Format("startEqy: ${0:n0}",startEqy);
		//TEXT=String.Format("endEq: ${0:n0}",endEq);
		//TEXT=String.Format("cagr: {0:n1}%",cagr*100);
		//TEXT=String.Format("mrpp: ${0:n0}",mrpp);

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
		// TABLE=FrameToTable(denseEquityFrame);
		// TABLE=FrameToTable(myFrame);

		HTML = @"<p style='page-break-before: always;'>";
		//HTML = "<br/>";
		H1=scenario.name + " - " + timeInterval.ToString();
		H4=endDate.ToString();
		TEXT=String.Format("startEqy: ${0:n0}",startEqy);
		TEXT=String.Format("endEq: ${0:n0}",endEq);
		TEXT=String.Format("days: {0:n0}",(endDate-startDate).Days);
		TEXT=String.Format("CAGR: {0:n0}%",cagr * 100);
		TEXT=String.Format("MaxDD Recorded: {0:N1}%",maxDd * 100);
		TEXT=String.Format("MaxDD Worst Case: {0:N1}% (if max draw down occurred at inception)",maxDd3 * 100);
		TEXT=String.Format("Last period: ${0:N0} (Avg: ${1:n0})", lastChange, mrpp);
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
//TABLE=debug;
