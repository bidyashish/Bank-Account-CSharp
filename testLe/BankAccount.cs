using System;
using System.Collections.Generic;
using System.Text;
using testLe;

namespace testLeb
{
	public class BankAccount
	{
		public string Number { get; }
		public string Owner  { get; set; }

		public decimal Balance
		{
			get
			{
				decimal balance = 0;
				foreach (var item in allTransactions)
					balance += item.Amount;

				return balance;
			}
		}

		private static int accountNumberSeed = 1234567890;

		private List<Transaction> allTransactions = new List<Transaction>();

		// public BankAccount(string name, decimal initialBalance)
		// {
		// 	Owner = name;
		// 	MakeDeposit(initialBalance, DateTime.Now, "Startomg Balance");
		// 	Number = accountNumberSeed.ToString();
		// 	accountNumberSeed++;
		//
		// }
		
		private readonly decimal minimumBalance;

		public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

		public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
		{
			this.Number = accountNumberSeed.ToString();
			accountNumberSeed++;

			this.Owner = name;
			this.minimumBalance = minimumBalance;
			if (initialBalance > 0)
				MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
		}

		public void MakeDeposit(decimal amount, DateTime date, string note)
		{
			if (amount <= 0)
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit");

			var deposit = new Transaction(amount, date, note);
			allTransactions.Add(deposit);
		}
		//
		// public void MakeWithdrawal(decimal amount, DateTime date, string note)
		// {
		// 	if (amount <= 0)
		// 		throw new ArgumentOutOfRangeException(nameof(amount), "Amount is crazy");
		//
		// 	if (Balance - amount < minimumBalance)
		// 		throw new InvalidOperationException("Not Sufficent Funds Available");
		// 	var withdrawal = new Transaction(-amount, date, note);
		// 	allTransactions.Add(withdrawal);
		//
		// }
		
		public void MakeWithdrawal(decimal amount, DateTime date, string note)
		{
			if (amount <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
			}
			var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
			var withdrawal           = new Transaction(-amount, date, note);
			allTransactions.Add(withdrawal);
			if (overdraftTransaction != null)
				allTransactions.Add(overdraftTransaction);
		}

		protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
		{
			if (isOverdrawn)
			{
				throw new InvalidOperationException("Not sufficient funds for this withdrawal");
			}
			else
			{
				return default;
			}
		}


		public string GetAccountHistory()
		{
			var report = new StringBuilder();
			report.AppendLine("Date \t\t\t Ammount \t Note");
			foreach (var item in allTransactions)
				report.AppendLine($"{item.Date}\t{item.Amount}\t{item.Notes}");

			return report.ToString();
		}

		public virtual void PerformMonthEndTransactions()
		{
			if (Balance > 500m)
			{
				var interest = Balance * 0.05m;
				MakeDeposit(interest, DateTime.Now, "Add Monthly Interest method");
			}
		}
		
		
	}
}