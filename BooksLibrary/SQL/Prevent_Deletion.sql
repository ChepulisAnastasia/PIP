--------------------------------------------------------------------------------------------------------------------------
--	������ �������� ��������, ���� �� �� ������ ��� �����:																--
--------------------------------------------------------------------------------------------------------------------------
	CREATE TRIGGER Prevent_Deletion ON Readers
	INSTEAD OF DELETE
	AS 
	DECLARE @X varchar(10) 
	SELECT @X = id FROM DELETED
	IF (@X =ANY(SELECT reader_id FROM Extradition WHERE return_date IS NULL))
		BEGIN
			ROLLBACK TRAN
			RAISERROR('������ �������� ��������, ��� ��� �� ���� ���������� ��� �����',16,10)
		END
	ELSE
		BEGIN
			DELETE FROM Extradition  WHERE reader_id = @X
			DELETE FROM Readers WHERE id = @X
		END