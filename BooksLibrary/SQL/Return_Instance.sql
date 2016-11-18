--------------------------------------------------------------------------------------------------------------------------
--	При возврате книги в таблице экземпляров данная книга помечаеться, что она появилась			+					--
--------------------------------------------------------------------------------------------------------------------------
	CREATE TRIGGER Return_Instance ON Extradition
	AFTER UPDATE
	AS

	DECLARE @instance_id int
	SELECT @instance_id = instance_id FROM INSERTED

	DECLARE @return_date date	
	SELECT @return_date = return_date FROM INSERTED

	IF (@return_date IS NOT NULL)
	BEGIN
	UPDATE Instances  
	SET existence = 'да'
	WHERE id = @instance_id
	END