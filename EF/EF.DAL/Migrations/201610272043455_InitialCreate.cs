namespace EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.emprunteur",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        prenom = c.String(nullable: false, maxLength: 50),
                        nom = c.String(nullable: false, maxLength: 50),
                        age = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.adresse_emprunteur",
                c => new
                    {
                        emprunteur_id = c.Int(nullable: false),
                        rue = c.String(),
                        code_postal = c.String(),
                        ville = c.String(),
                        pays = c.String(),
                    })
                .PrimaryKey(t => t.emprunteur_id)
                .ForeignKey("dbo.emprunteur", t => t.emprunteur_id)
                .Index(t => t.emprunteur_id);
            
            CreateTable(
                "dbo.pret",
                c => new
                    {
                        emprunteur_id = c.Int(nullable: false),
                        article_id = c.Int(nullable: false),
                        date_emprunt = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        date_echeance = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        date_retour = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.emprunteur_id, t.article_id })
                .ForeignKey("dbo.article", t => t.article_id, cascadeDelete: true)
                .ForeignKey("dbo.emprunteur", t => t.emprunteur_id, cascadeDelete: true)
                .Index(t => new { t.emprunteur_id, t.article_id }, unique: true, name: "IX_Borrower_Item")
                .Index(t => t.date_retour);
            
            CreateTable(
                "dbo.article",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        statut = c.Int(nullable: false),
                        langage = c.Int(nullable: false),
                        titre = c.String(),
                        catalogue_id = c.Int(nullable: false),
                        auteur = c.String(maxLength: 50),
                        code_isbn = c.String(maxLength: 13, fixedLength: true),
                        artiste = c.String(),
                        nb_pistes = c.Int(),
                        resume = c.String(),
                        duree = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.catalogue", t => t.catalogue_id, cascadeDelete: true)
                .Index(t => t.catalogue_id);
            
            CreateTable(
                "dbo.catalogue",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.genre",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.genre_article",
                c => new
                    {
                        article_id = c.Int(nullable: false),
                        genre_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.article_id, t.genre_id })
                .ForeignKey("dbo.article", t => t.article_id, cascadeDelete: true)
                .ForeignKey("dbo.genre", t => t.genre_id, cascadeDelete: true)
                .Index(t => t.article_id)
                .Index(t => t.genre_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pret", "emprunteur_id", "dbo.emprunteur");
            DropForeignKey("dbo.genre_article", "genre_id", "dbo.genre");
            DropForeignKey("dbo.genre_article", "article_id", "dbo.article");
            DropForeignKey("dbo.pret", "article_id", "dbo.article");
            DropForeignKey("dbo.article", "catalogue_id", "dbo.catalogue");
            DropForeignKey("dbo.adresse_emprunteur", "emprunteur_id", "dbo.emprunteur");
            DropIndex("dbo.genre_article", new[] { "genre_id" });
            DropIndex("dbo.genre_article", new[] { "article_id" });
            DropIndex("dbo.article", new[] { "catalogue_id" });
            DropIndex("dbo.pret", new[] { "date_retour" });
            DropIndex("dbo.pret", "IX_Borrower_Item");
            DropIndex("dbo.adresse_emprunteur", new[] { "emprunteur_id" });
            DropTable("dbo.genre_article");
            DropTable("dbo.genre");
            DropTable("dbo.catalogue");
            DropTable("dbo.article");
            DropTable("dbo.pret");
            DropTable("dbo.adresse_emprunteur");
            DropTable("dbo.emprunteur");
        }
    }
}
