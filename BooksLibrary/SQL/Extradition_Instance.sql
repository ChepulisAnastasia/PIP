--------------------------------------------------------------------------------------------------------------------------
--	При выдачи книги в таблице экземпляров данная книга помечаеться, что она отсутствует			+					--
--------------------------------------------------------------------------------------------------------------------------
	CREATE TRIGGER Extradition_Instance ON Extradition
	AFTER INSERT
	AS

	DECLARE @instance_id int		
	SELECT @instance_id = instance_id FROM INSERTED
	
	IF (@instance_id =ANY( SELECT id FROM Instances WHERE existence = 'да' ))
	BEGIN 
		UPDATE Instances  
		SET existence = 'нет'
		WHERE id = @instance_id
	END