CREATE OR ALTER VIEW [vwGetIncomesByCategory] AS

SELECT Transactions.UserId, Categories.Title AS Category, YEAR(Transactions.PaidOrReceivedAt) AS [YEAR], SUM(Transactions.Amount) AS Incomes
FROM Transactions INNER JOIN Categories ON Transactions.CategoryId = Categories.Id
WHERE Transactions.PaidOrReceivedAt >= DATEADD(MONTH, -11, GETDATE()) AND Transactions.PaidOrReceivedAt <= DATEADD(MONTH, 1, GETDATE())
AND Transactions.[Type] = 1
GROUP BY Transactions.UserId, Categories.Title, YEAR(Transactions.PaidOrReceivedAt)