var systems = new[] {
	// SystemID, SystemName, SystemScaling
	// Run the forex systems first so we can scrape the trades to update the X-Rates table
	Tuple.Create(94987184,  "Just Forex Trades",  0.3),

    //Tuple.Create(124998567, "abasacJAR 4X", 6.0 ), // Seems to be missing 60 odd trades !!!!
/*    // PPRs pets systems
    Tuple.Create(120622361, "NQ Kingpin", 1.0 ),
    Tuple.Create(115023400, "Crude Oil Trader Z", 1.0),
    Tuple.Create(119232154, "PegasiCap", 1.0),
    // CDBs pet systems
    Tuple.Create(125935591, "Klarity", 3.0),
    //Tuple.Create(117442067, "Carma Managed Future",1.0), // Bad data in here causes Div0 Error
    Tuple.Create(125428941, "Clear Futures", 3.0),
    Tuple.Create(102081384, "OPN W888", 0.5),
    Tuple.Create(125587405, "Stock Star", 3.0),

	// Forex systems
	Tuple.Create(  121872737, "Aggressive Trend Scalper", 1.0 ),
	Tuple.Create(  124998567, "abasacJAR 4X   ", 1.0 ),
	Tuple.Create(  125277645, "FX Star", 1.0 ),
	Tuple.Create(  122042540, "FX Reversals", 1.0 ),
	Tuple.Create(  121808714, "PxV Forex", 1.0 ),
	Tuple.Create(  122467834, "Auto Wave Forex", 1.0 ),
	Tuple.Create(  123479706, "NEURAL STARK STRATEGY", 1.0 ),
	Tuple.Create(  116569503, "FOREX SWING SYSTEM", 1.0 ),
	Tuple.Create(  123805444, "Only A Boring FX", 1.0 ),
	Tuple.Create(  123530483, "Trading FX complex", 1.0 ),

	// Futures strats from Top strats
	Tuple.Create(   125587405, "stock star", 1.0 ),
	Tuple.Create(   125982253, "GoldFutures", 1.0 ),
	Tuple.Create(   125935591, "Klarity", 1.0 ),
	Tuple.Create(   126043352, "Bond USA", 1.0 ),
	Tuple.Create(   125624499, "dow m", 1.0 ),
	Tuple.Create(   123071731, "MINI DOW 123071731 ", 1.0 ),
	Tuple.Create(   121637339, "Stock dow", 1.0 ),
	Tuple.Create(   125206069, "Marlin", 1.0 ),
	Tuple.Create(   122397210, "Futrs only", 1.0 ),
	Tuple.Create(   123458321, "ES DSXmes", 1.0 ),
	Tuple.Create(   124332528, "ES Russell", 1.0 ),
	Tuple.Create(   125284205, "Change a", 1.0 ),
	Tuple.Create(   123472063, "C2Star dax and fgbl", 1.0 ),
	Tuple.Create(   124283622, "YM AGRI", 1.0 ),
	Tuple.Create(   123562056, "NASDAQ Mc", 1.0 ),
	Tuple.Create(   125428941, "Clear Futures", 1.0 ),
	Tuple.Create(   122681618, "lang", 1.0 ),
	Tuple.Create(   122087689, "OPN Energy 8868", 1.0 ),
	Tuple.Create(   125237603, "EliteSPX", 1.0 ),
	Tuple.Create(   125876898, "Pool of traders", 1.0 ),
	Tuple.Create(   123895279, "Commodity Gold", 1.0 ),
	Tuple.Create(   122867565, "STOCK MARKET SWINGER", 1.0 ),
	Tuple.Create(   124190857, "ES No Guts No Glory", 1.0 ),
	Tuple.Create(   120622361, "NQ KingPin", 1.0 ),
	Tuple.Create(   122174703, "AlgoSys YM - Andromalius", 1.0 ),
	Tuple.Create(   114887103, "DRIVER Balanced", 1.0 ),
	Tuple.Create(   123479706, "NEURAL STARK STRATEGY", 1.0 ),
	Tuple.Create(   120687863, "ElitES SnP 500 ", 1.0 ),
	Tuple.Create(   117442067, "Carma Managed Futures", 1.0 ),
	Tuple.Create(   121285788, "Capstone Strategic", 1.0 ),
	Tuple.Create(   125620901, "E MINI SP", 1.0 ),
	Tuple.Create(   124696549, "4Timing Trend ML", 1.0 ),
	Tuple.Create(   124877167, "Elliottwave System", 1.0 ),
	Tuple.Create(   119232154, "PegasiCap", 1.0 ),
	Tuple.Create(   123163369, "RedCrest Managed Vol", 1.0 ),

	// Stocks
	Tuple.Create(	125587405	, "stock star", 1.0 ),
	Tuple.Create(	121637339	, "Stock dow", 1.0 ),
	Tuple.Create(	124727146	, "TQQQSQQQ", 1.0 ),
	Tuple.Create(	126054331	, "CkNN Algo V", 1.0 ),
	Tuple.Create(	125236007	, "Systematic Managed Alpha", 1.0 ),
	Tuple.Create(	123007535	, "favour etf", 1.0 ),
	Tuple.Create(	125876898	, "Pool of traders", 1.0 ),
	Tuple.Create(	124343595	, "C2Star App SuperBands", 1.0 ),
	Tuple.Create(	124994120	, "Obsidian ALPHA AI Master", 1.0 ),
	Tuple.Create(	106901765	, "VIXTrader", 1.0 ),
	Tuple.Create(	125620901	, "E MINI SP", 1.0 ),
	Tuple.Create(	117580044	, "Volatility Balanced", 1.0 ),
	Tuple.Create(	102427283	, "Smart Volatility Margin", 1.0 ),
	Tuple.Create(	124696549	, "4Timing Trend ML", 1.0 ),
	Tuple.Create(	106600099	, "VIXTrader Professional", 1.0 ),
	Tuple.Create(	100707640	, "VXX Bias", 1.0 ),
	Tuple.Create(	106187009	, "Dual QM18", 1.0 ),
	Tuple.Create(	104952602	, "VIX Tactical Trader", 1.0 ),
	Tuple.Create(	124270346	, "SPODD500", 1.0 ),
	Tuple.Create(	126079605	, "Daily Scalp", 1.0 ),

	// Options
	Tuple.Create(	125620901	, "E MINI SP", 1.0 ),
	Tuple.Create(	117580044	, "Volatility Balanced", 1.0 ),
	Tuple.Create(	102427283	, "Smart Volatility Margin", 1.0 ),
*/
};

// Get some colors to use
List<System.Drawing.Color> colors = new List<System.Drawing.Color>(new System.Drawing.Color[]
                                                                   {Color.Blue, Color.Brown, Color.Red, Color.Green, Color.Orange, Color.Purple,
                                                                    Color.Pink, Color.DarkGreen, Color.DarkBlue, Color.Olive}
                                                                   );

int colorIndex = 0;
var systemsIds = systems.Select(f=>(long)f.Item1);
var sideWord = new Dictionary <string,string> () {
	{"BTO","LONG"}, {"STO","SHORT"}
};
var XRates = new Dictionary<string,double>()
{
//CHF,JPY,AUD,NZD,USD,CAD,GBP,EUR,HUF,CNH,SEK,TRY,ZAR
	{"USD",1.0},
	{"AUD", 0.6138},
	{"CAD", 0.7118},
	{"CHF", 1.02},
	{"EUR", 1.108},
	{"GBP", 1.2372},
	{"JPY", 0.009288},
	{"NZD", 0.6028},
	{"HUF", 0.0031},
	{"SEK", 0.1005 },
	{"ZAR", 0.0556 },
	{"CNH", 0.1407 },
	{"TRY", 0.1535 },
	{"SGD", 0.7076 },
};
// Set starting date (YYYY,MM,DD)
var startDate = new DateTime(2015,01,01);
var startTime = DateTime.Now;
List<String> allCurrencies =  new List<String>();
List<String> errors =  new List<String>();
List<dynamic> tsig = new List<dynamic>();
decimal runningEquity = 0;

bool debug = true;

foreach (var system in systems) {
	H2 = system.Item2;
	runningEquity = C2SYSTEMS.Where( sys => sys.SystemId == system.Item1 ).Select( sys => sys.StartingCash ).First();
	//var sys = C2SYSTEMS.Where(s=>s.SystemId==system.Item1).First();

	// We need to convert each query to a List so that we don't have open more than one database connection
	var signals = C2SIGNALS.Where(sig => sig.SystemId == system.Item1 && sig.PostedWhen > startDate).OrderBy(sig=>sig.TradedWhen).ToList();
	var trades = C2TRADES.Where( trade => trade.SystemId == system.Item1 && trade.EntryTime > startDate )
	             .OrderBy(trade => trade.ExitTime).ToList();

	if (debug) {
		// We will record the currency for every trade for debugging in the case that we find a currency not in our XRates tables
		foreach ( var currency in signals.Select( s => s.Currency ).Distinct().ToList() ) {
			if ( !allCurrencies.Contains(currency) )
				allCurrencies.Add(currency);
		}
		// we also want 'base' currencies in our XRates table
		foreach ( var trade in trades ) {
			if ( trade.Instrument.Equals("forex") ) {
				var baseCurrency = trade.Symbol.Substring(0,3);
				if ( !allCurrencies.Contains(baseCurrency) )
					allCurrencies.Add(baseCurrency);
			}
		}
	}

	if (true) {
		var ourTrades=trades.Select( trade =>
		{
			decimal openQty=0,openSum=0,openPrice=0;
			decimal closeQty=0,closeSum=0,closePrice=0;
			decimal ddQty=0,dd = 0;
			decimal lastEquity = runningEquity;
			runningEquity += trade.Result;


			// Search signals for this trade to establish open, close, and DD Qtys
			foreach ( var sig in signals.Where( sig => sig.TradeId == trade.Id )) {
			    if ( sig.Action.EndsWith("O") ) {
			        openSum += sig.Quant * sig.TradePrice;
			        openQty += sig.Quant;
			        openPrice = openSum / openQty;
				}else if ( sig.Action.EndsWith("C") ) {
			        closeSum += sig.Quant * sig.TradePrice;
			        closeQty += sig.Quant;
			        closePrice = closeSum / closeQty;
				}
			    if (sig.TradedWhen <= trade.MaxDrawdownTime) {
			        ddQty = openQty-closeQty;
				}
			}

			// If there is a price for MaxDrawdown then we compute the DD
			if ( true && trade.MaxDrawdown != 0 ) {
			    if ( trade.Instrument.Equals("forex") ) {
			        // If we are lookinhg at a USD trade that gives us a chance to update the x-rates table
			        if (trade.Symbol.Substring(0,3).Equals("USD")) {
			            XRates[trade.Symbol.Substring(3,3)] = 1/(double)closePrice;
					} else if ( trade.Symbol.Substring(3,3).Equals("USD") ) {
			            XRates[trade.Symbol.Substring(0,3)] = (double)closePrice;
					}
			        // now we compute the DD
			        dd = Math.Abs(openPrice - trade.MaxDrawdown) * ddQty * 10000                                                                                // ()? data in JFT corrupt
			             / trade.MaxDrawdown                                                                               // quote 2 base
			             * (decimal)XRates[trade.Symbol.Substring(0,3)];                                                                               // base to USD
				}else{
			        // DDs for non forex DD are simpler
			        dd = Math.Abs(openPrice - trade.MaxDrawdown) * ddQty * trade.PtValue
			             * (decimal)XRates[signals.First().Currency];
				}
			}
			return new {
			    //TradeId=trade.Id,
			    OpenTimeET=trade.EntryTime.ToString("yyyy-MM-dd HH:mm:ss"),
			    Side=sideWord[trade.Action],
			    QtyOpen=openQty,
			    Symbol=trade.Symbol,
			    Description=trade.Symbol,
			    AvgPriceOpen=Math.Round(openSum/openQty,4),
			    QtyClosed=closeQty,
			    ClosedTimeET=trade.ExitTime.ToString("yyyy-MM-dd HH:mm:ss"),
			    AvgPriceClosed=Math.Round(closeSum/closeQty,4),
			    DD_as_Pcnt=Math.Round(-dd/lastEquity*100,2),
			    DD_as_Dlr=Math.Round(-dd,0),
			    //Currency = openSigs.First().Currency,
			    //rate = Math.Round(XRates[openSigs.First().Currency],4),
			    //baseX = Math.Round(XRates[trade.Symbol.Substring(0,3)],4),
			    //PntVal=trade.PtValue,
			    DrawdownTimeET=trade.MaxDrawdownTime.ToString("yyyy-MM-dd HH:mm:ss"),
			    DD_Quant=ddQty,
			    DD_Worst_Price=Math.Round(trade.MaxDrawdown,4),
			    Trade_PL=Math.Round(trade.Result,2),
			    Equity=runningEquity,
			};
		}).ToList();
		TABLE=ourTrades;

		// CHARTING
		// Create a chart objects
		ITimeSeriesChart systemChart = new TimeSeriesChart();
		systemChart.Name = system.Item2;//"System equity curve";
		//IChartTimeSeries systemSeries = new ChartTimeSeries();
		//systemSeries.Type = ChartTypes.Line;

		//var eqPoints = new Series<DateTime,decimal>( ourTrades.OrderBy(t=>t.ClosedTimeET).Select(t=> { return new KeyValuePair<DateTime,decimal>(DateTime.Parse(t.ClosedTimeET),t.Equity); }));
		var eqPoints = new List<KeyValuePair<DateTime,decimal>>( ourTrades.OrderBy(t=>t.ClosedTimeET).Select(t=> { return new KeyValuePair<DateTime,decimal>(DateTime.Parse(t.ClosedTimeET),t.Equity); }));
		var eqPoints2 = new Series<DateTime,decimal>( eqPoints );

        var eqPoints3 = C2EQUITY.Where(sys=>sys.SystemId == system.Item1).Select(ep => new KeyValuePair<DateTime,decimal>(ep.DateTime,ep.Value) );
        var eqPoints4 = new Series<DateTime,decimal>( eqPoints3 );

		systemChart.Add( eqPoints2, "Realised Equity",
						 //String.Format("{0}({1:N1}%)",system.Item2,1.0*100),
						 colors[colorIndex++]);

      systemChart.Add( eqPoints4, "Realtime Equity",
						 //String.Format("{0}({1:N1}%)",system.Item2,1.0*100),
						 colors[colorIndex++]);
      //TABLE=eqPoints2;
      HR();
      CHART=systemChart;


    }else{
		TABLE = trades;
		TABLE = signals;
	}


	TEXT = String.Format("Query took {0}ms", (DateTime.Now - startTime).Milliseconds.ToString() );
	HR();

	if(false) {
		// Look for the symbols a system trades
		TEXT="Symbols:" + system.Item2;
		TABLE = (from trade in C2TRADES
		         where trade.SystemId == system.Item1 && trade.EntryTime > startDate
		         select new { Symbol=trade.Symbol }).Distinct();
	}
}

// if we have a problem with missing rates in the x-rates table we can turn on this debug
//TEXT = "All Currencies traded: " + String.Join(",",allCurrencies);
if (false) {
	foreach ( var cur in allCurrencies ) {
		if ( !XRates.ContainsKey( cur ) ) {
			TEXT = "Missing rate for " + cur;
		}
	}
}
