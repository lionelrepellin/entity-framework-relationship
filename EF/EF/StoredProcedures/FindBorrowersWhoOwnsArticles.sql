CREATE PROCEDURE FindBorrowersWhoOwnsArticles
	@discriminator varchar(10)
AS
BEGIN
	SELECT e.id AS Id, e.prenom AS Firstname, e.nom AS Lastname, e.age
	FROM emprunteur AS e, 
	article AS a,
	pret AS p
	WHERE e.id = p.emprunteur_id
	AND a.id = p.article_id
	AND a.entity_type = @discriminator
	AND p.date_retour IS NULL
END