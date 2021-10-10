using System;
using testLeb;

namespace BankAccount
{
	internal static class ss
	{
		private static void Main(string[] args)
		{
			var account = new testLeb.BankAccount("kendra", 1000);
			Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");


			account.MakeDeposit(500, DateTime.Now, "Mac book ");
			account.MakeDeposit(15, DateTime.Now, "kela");
			account.MakeWithdrawal(200, DateTime.Now, "ATM");

			var giftCard = new GiftCardAccount("gidt card", 100, 50);
			giftCard.MakeWithdrawal(20, DateTime.Now, "get expensice coffe");
			giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
			giftCard.PerformMonthEndTransactions();


			// can make additional deposits
			giftCard.MakeDeposit(27, DateTime.Now, "add some additional spend");
			Console.WriteLine(giftCard.GetAccountHistory());

			var savings = new InterestEarningAccount("Saving account", 10000);
			savings.MakeDeposit(750, DateTime.Now, "save some Money");
			savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
			savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bill");
			savings.PerformMonthEndTransactions();
			Console.WriteLine(savings.GetAccountHistory());


			// var lineOfCredit = new LineOfCreditAccount("line of credit", 0);
			// lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, ";Take out monthly");
			// lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
			// lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency Fund");
			// lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration");
			// lineOfCredit.PerformMonthEndTransactions();
			// Console.WriteLine(lineOfCredit.GetAccountHistory());
			
			var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
			// How much is too much to borrow?
			lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
			lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
			lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
			lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
			lineOfCredit.PerformMonthEndTransactions();
			Console.WriteLine(lineOfCredit.GetAccountHistory());
			
			


			Console.WriteLine(account.Balance);
		}
	}
}