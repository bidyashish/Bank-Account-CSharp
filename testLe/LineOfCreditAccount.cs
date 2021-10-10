using System;
using testLeb;

namespace testLe
{
	public class LineOfCreditAccount : BankAccount
	{
		public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
		{
		}
		
		protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
            isOverdrawn
            ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
            : default;
		
		public override void PerformMonthEndTransactions()
		{
			if (Balance < 0)
			{
				// Negative the balance to get a positive interest charge
				var interest = -Balance * 0.07m;
				MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
			}
		}
	}
}