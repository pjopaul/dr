using DR.Data.Entities;
using DR.Data.Migrations;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DR.Data
{
    public class LifeEventsMasterData : DropCreateDatabaseIfModelChanges<LifeEventsDBContext>
    {

        protected override void Seed(LifeEventsDBContext context)
        {
            base.Seed(context);
        }

    }
}