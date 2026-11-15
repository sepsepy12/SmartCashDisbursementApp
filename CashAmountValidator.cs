namespace SmartCashDisbursementApp
{
	internal static class CashAmountValidator
	{
		private const decimal MinimumCashAmount = 50m;

		public static bool IsValid(decimal amount)
		{
			return amount >= MinimumCashAmount && amount % MinimumCashAmount == 0;
		}
	}
}
