--	сведения о наиболее популярных книгах (все экземпляры находятся на руках у читателей). 
	CREATE VIEW ПОПУЛЯРНЫЕ_КНИГИ (ISBN, название)
	AS SELECT ISBN, название
	FROM КНИГА
	WHERE ISBN IN(
		SELECT ISBN
		FROM ЭКЗЕМПЛЯР INNER JOIN ВЫДАЧА ON ЭКЗЕМПЛЯР.номер_экземпляра = ВЫДАЧА.номер_экземпляра
		WHERE дата_возврата IS NULL
		GROUP BY ISBN
		HAVING COUNT(*) =(
			SELECT MAX(количество)
			FROM (
				SELECT ISBN, COUNT(*)
				FROM ЭКЗЕМПЛЯР INNER JOIN ВЫДАЧА ON ЭКЗЕМПЛЯР.номер_экземпляра = ВЫДАЧА.номер_экземпляра
				WHERE дата_возврата IS NULL
				GROUP BY ISBN
				) AS TMP(ISBN, количество)
			)
		);