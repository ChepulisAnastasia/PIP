--------------------------------------------------------------------------------------------------------------------------
--	��� ������ ����� � ������� ����������� ������ ����� �����������, ��� ��� �����������			+					--
--------------------------------------------------------------------------------------------------------------------------
	CREATE TRIGGER Extradition_Instance ON Extradition
	AFTER INSERT
	AS

	DECLARE @instance_id int		
	SELECT @instance_id = instance_id FROM INSERTED
	
	IF (@instance_id =ANY( SELECT id FROM Instances WHERE existence = '��' ))
	BEGIN 
		UPDATE Instances  
		SET existence = '���'
		WHERE id = @instance_id
	END