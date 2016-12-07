--------------------------------------------------------------------------------------------------------------------------
--	Создать представления для администрации библиотеки, cодержащие:														--
--------------------------------------------------------------------------------------------------------------------------
--	сведения о должниках.
	CREATE VIEW Debtors (last_name, name, middle_name, phone, "Количество дней задержки")
	AS SELECT DISTINCT last_name, name, middle_name, phone, DATEDIFF(DAY, date_extradition, GETDATE()) AS "Количество дней задержки"
	FROM Readers INNER JOIN Extradition ON Readers.id = Extradition.reader_id
	WHERE reader_id IS NULL
		AND DATEDIFF(DAY, date_extradition, GETDATE()) > 10;
--------------------------------------------------------------------------------------------------------------------------