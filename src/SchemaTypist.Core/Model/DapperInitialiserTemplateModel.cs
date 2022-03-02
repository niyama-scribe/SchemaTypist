using System.Collections.Generic;
using SchemaTypist.Core.Config;

namespace SchemaTypist.Core.Model
{
    internal class DapperInitialiserTemplateModel : TemplateModel
    {
        public List<EntitiesTemplateModel> TemplateModels { get; set; }
    }
}
