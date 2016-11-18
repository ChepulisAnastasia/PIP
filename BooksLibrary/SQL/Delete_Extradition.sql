--------------------------------------------------------------------------------------------------------------------------
--	При удалении книги в таблице экземпляров данная книга помечаеться, что она появилась			+					--
--------------------------------------------------------------------------------------------------------------------------
	CREATE TRIGGER Delete_Extradition ON Extradition
	AFTER DELETE
	AS

	DECLARE @instance_id int		
	SELECT @instance_id = instance_id FROM DELETED
	
	UPDATE Instances  
	SET existence = 'да'
	WHERE id = @instance_id