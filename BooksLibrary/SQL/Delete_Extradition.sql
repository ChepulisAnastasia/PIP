--------------------------------------------------------------------------------------------------------------------------
--	��� �������� ����� � ������� ����������� ������ ����� �����������, ��� ��� ���������			+					--
--------------------------------------------------------------------------------------------------------------------------
	CREATE TRIGGER Delete_Extradition ON Extradition
	AFTER DELETE
	AS

	DECLARE @instance_id int		
	SELECT @instance_id = instance_id FROM DELETED
	
	UPDATE Instances  
	SET existence = '��'
	WHERE id = @instance_id