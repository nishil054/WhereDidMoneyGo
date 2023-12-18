namespace ExpenseTracker.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Expense_Details : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expense_Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseName = c.String(),
                        Price = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Details_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Expense_Details", new[] { "IsDeleted" });
            DropTable("dbo.Expense_Details",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Details_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
