--------------------------------------------------------------------------------------------------------------------------
--	������� ������������� ��� ������������� ����������, c���������:														--
--------------------------------------------------------------------------------------------------------------------------
--	�������� � ���������.
	CREATE VIEW Debtors (last_name, name, middle_name, phone, "���������� ���� ��������")
	AS SELECT DISTINCT last_name, name, middle_name, phone, DATEDIFF(DAY, date_extradition, GETDATE()) AS "���������� ���� ��������"
	FROM Readers INNER JOIN Extradition ON Readers.id = Extradition.reader_id
	WHERE reader_id IS NULL
		AND DATEDIFF(DAY, date_extradition, GETDATE()) > 10;
--------------------------------------------------------------------------------------------------------------------------