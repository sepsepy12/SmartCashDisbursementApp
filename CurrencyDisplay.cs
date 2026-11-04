using System;

namespace SmartCashDisbursementApp
{
	internal static class CurrencyDisplay
	{
		public static string Format(decimal amount)
		{
			return $"₱{FormatNumber(amount)}";
		}

		public static string FormatNumber(decimal amount)
		{
			decimal roundedAmount = decimal.Round(amount, 0, MidpointRounding.AwayFromZero);
			return roundedAmount.ToString("N0");
		}
	}
}
