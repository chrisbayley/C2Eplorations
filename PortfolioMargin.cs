// https://forums.collective2.com/t/measuring-leverage/8394/6
// Select FOREX Systems we want in charts.
var systems = new[] {
	// SystemID, SystemName, SystemScaling
	Tuple.Create(124998567, "abasacJAR 4X", 6.0 ),
	//Tuple.Create(94987184,  "Just Forex Trades",  0.3),
	//Tuple.Create(125935591,"Klarity", 1.0),
};
var systemsIds = systems.Select(f=>(long)f.Item1);

// Set starting date (YYYY,MM,DD)
var startingDate = new DateTime(2015,01,01);

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
var baseCurrency = "NZD";

var IBMarginRates = new Dictionary<string,Tuple<double,double,double> >()
{
	{ "AUD",   Tuple.Create(   0.03,   0.03,   0.03    )},
	{ "CAD",   Tuple.Create(   0.03,   0.03,   0.02    )},
	{ "CHF",   Tuple.Create(   0.03,   0.03,   0.03    )},
	{ "CNH",   Tuple.Create(   0.15,   0.12,   0.05    )},
	{ "CZK",   Tuple.Create(   0.05,   0.05,   0.05    )},
	{ "DKK",   Tuple.Create(   0.10,   0.05,   0.02    )},
	{ "EUR",   Tuple.Create(   0.03,   0.03,   0.02    )},
	{ "GBP",   Tuple.Create(   0.07,   0.05,   0.05    )},
	{ "HKD",   Tuple.Create(   0.12,   0.10,   0.05    )},
	{ "HUF",   Tuple.Create(   0.05,   0.05,   0.05    )},
	{ "ILS",   Tuple.Create(   0.05,   0.05,   0.05    )},
	{ "JPY",   Tuple.Create(   0.03,   0.03,   0.04    )},
	{ "KRW",   Tuple.Create(   0.10,   0.10,   0.05    )},
	{ "MXN",   Tuple.Create(   0.10,   0.06,   0.10    )},
	{ "NOK",   Tuple.Create(   0.03,   0.03,   0.07    )},
	{ "NZD",   Tuple.Create(   0.03,   0.03,   0.03    )},
	{ "PLN",   Tuple.Create(   0.05,   0.05,   0.05    )},
	{ "RUB",   Tuple.Create(   0.20,   0.20,   0.20    )},
	{ "SEK",   Tuple.Create(   0.03,   0.03,   0.03    )},
	{ "SGD",   Tuple.Create(   0.05,   0.05,   0.05    )},
	{ "THB",   Tuple.Create(   0.10,   0.10,   0.10    )},
	{ "TRY",   Tuple.Create(   0.30,   0.30,   0.12    )},
	{ "USD",   Tuple.Create(   0.03,   0.03,   0.02    )},
	{ "ZAR",   Tuple.Create(   0.10,   0.07,   0.07    )},
};

decimal runningMgn = 0;

var openTrades = new Dictionary<long,Tuple<decimal,decimal> >();

var sysNames = C2SYSTEMS.Where(s => systemsIds.Contains(s.SystemId));
//TABLE=sysNames;

var sigs = C2SIGNALS.Where( sig => systemsIds.Contains( sig.SystemId ) && sig.TradedWhen > startingDate )
           .OrderBy(sig => sig.TradedWhen ).AsEnumerable()
           .Select( sig =>
{
	var scaling = systems.Where( sys => sys.Item1 == sig.SystemId).First().Item3;
	var tvUSD = sig.Quant*sig.TradePrice*(decimal)XRates[sig.Currency]*sig.PtValue;
	var tvBase = tvUSD / (decimal)XRates[baseCurrency];
	var Mgn = Math.Round(tvBase*(decimal)IBMarginRates[sig.Currency].Item1) * (decimal)scaling;
	if ( sig.Action.EndsWith("O") )
	{
	    runningMgn += Mgn;
	}else{
	    runningMgn -= Mgn;
	}
	return new{
	    //Id = sig.Id,
	    SystemId = sysNames.Where(s => s.SystemId == sig.SystemId)
	               .Select( s => s.SystemName ),
	    Trade = sig.TradeId,
	    When = sig.TradedWhen,
	    Action = sig.Action,
	    Quant=sig.Quant,
	    Symbol=sig.Symbol,
	    // Currency=sig.Currency,
	    // fx=XRates[sig.Currency],
	    Price=sig.TradePrice,
	    // TradeValueUsd=Math.Round(tvUSD),
	    TradeValueNzd=Math.Round(tvBase),
	    Margin=Mgn,
	    RunningMgn=runningMgn,
	};
}).ToList();

//  TABLE = sigs;//.Take(10);
foreach (  var t in openTrades ) {
	TEXT = String.Format("{0}, {1},{2}", t.Key, t.Value.Item1, t.Value.Item2 );
	TEXT="${t.Key}";
}

// Create a chart object
ITimeSeriesChart timeSeriesChart = new TimeSeriesChart();
timeSeriesChart.Name = "Time series Margin";
IChartTimeSeries chartSeries = new ChartTimeSeries();
chartSeries.Type = ChartTypes.Line;
chartSeries.Data = sigs.Select( sig => new TimeSeriesPoint() {
	DateTime = sig.When,
	Value = (double)sig.RunningMgn,
});
chartSeries.Name = "Margin";
chartSeries.Color = Color.DarkBlue;
timeSeriesChart.Add(chartSeries);
CHART = timeSeriesChart;
