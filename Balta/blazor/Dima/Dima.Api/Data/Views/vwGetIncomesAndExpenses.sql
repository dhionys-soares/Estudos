CREATE OR ALTER VIEW [vwGetIncomesAndExpenses] AS

SELECT
Transactions.UserId,
MONTH(Transactions.PaidOrReceivedAt) AS [MONTH],
YEAR(Transactions.PaidOrReceivedAt) AS [YEAR],
SUM(CASE WHEN Transactions.[Type] = 1 THEN Transactions.Amount ELSE 0 END) AS Incomes,
SUM(CASE WHEN Transactions.[Type] = 2 THEN Transactions.Amount ELSE 0 END) AS Expenses
FROM Transactions
WHERE Transactions.PaidOrReceivedAt >= DATEADD(MONTH, -11, GETDATE()) AND Transactions.PaidOrReceivedAt <= DATEADD(MONTH, 1, GETDATE())
GROUP BY Transactions.UserId,
MONTH(Transactions.PaidOrReceivedAt),
YEAR(Transactions.PaidOrReceivedAt)