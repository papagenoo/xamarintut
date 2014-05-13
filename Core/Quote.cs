using System;

namespace Core
{
	// {"name":"q","args":[{"q":[{"t":"2014-05-13T01:39:46","c":"SIH4","mrg":"M","bbp":0,"bbs":0,"bbc":" ","bbf":0,"bap":0,"bas":0,"bac":" ","baf":0,"pp":36708,"op":36695,"ltp":36708,"lts":0,"ltt":"2014-05-13T01:24:46","chg":0,"pcp":0,"ltr":"FORTS","ltc":" ","mintp":36600,"maxtp":36740,"vol":0,"vlt":0,"yld":0,"acd":0,"fv":0,"mtd":"2014-03-17T00:00:00","cpn":0,"cpp":0,"ncd":"","dpb":1836,"dps":1836,"ncp":0,"trades":0,"min_step":1,"step_price":1,"kind":6,"type":3,"name":"Si-3.14","name2":"","p5":36529,"chg5":0.49,"p22":35356,"chg22":3.82,"p110":31491,"chg110":16.57,"p220":31491,"chg220":16.57,"x_dsc1":"100.0","x_dsc2":"100.0","x_dsc3":"100.0","x_descr":"","x_curr":"RUR","x_short":"1","x_lot":"1","x_currVal":"1.00000000"}]}]}

	public class Quote
	{
		public string t { get; set; }
		public string c { get; set; }
		public override string ToString()
		{
			return String.Format ("[Quote {0} {1}]", c, t);
		}
	}
}

