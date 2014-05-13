using System;

namespace Core
{
	public class QuotesUpdateEvent
	{
		public Quote[] q { get; set; }

		public override string ToString ()
		{
			return string.Format ("[QuotesUpdateEvent: q={0}]", q);
		}
	}
}

