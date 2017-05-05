using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DAL.Conventions
{
	public class DiscriminatorConvention : IStoreModelConvention<EdmProperty>
	{
		public void Apply(EdmProperty property, DbModel model)
		{
			if (property.Name == "Discriminator")
				property.Name = "entity_type";
		}
	}
}