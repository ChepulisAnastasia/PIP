--	�������� � �������� ���������� ������ (��� ���������� ��������� �� ����� � ���������). 
	CREATE VIEW ����������_����� (ISBN, ��������)
	AS SELECT ISBN, ��������
	FROM �����
	WHERE ISBN IN(
		SELECT ISBN
		FROM ��������� INNER JOIN ������ ON ���������.�����_���������� = ������.�����_����������
		WHERE ����_�������� IS NULL
		GROUP BY ISBN
		HAVING COUNT(*) =(
			SELECT MAX(����������)
			FROM (
				SELECT ISBN, COUNT(*)
				FROM ��������� INNER JOIN ������ ON ���������.�����_���������� = ������.�����_����������
				WHERE ����_�������� IS NULL
				GROUP BY ISBN
				) AS TMP(ISBN, ����������)
			)
		);