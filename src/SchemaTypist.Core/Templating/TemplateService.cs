using System;
using System.Threading;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Model;
using Scriban;

namespace SchemaTypist.Core.Templating
{
    internal class TemplateService : ITemplateService
    {
        private volatile int _isLoaded;

        public void LoadTemplates(CodeGenConfig config)
        {
            if (Interlocked.CompareExchange(ref _isLoaded, 1, 0) != 0) return;
            var (entitiesTemplateName, persistenceTemplateName, dapperInitialiserTemplateName) =
                TemplateConstants.GetTemplateFileNames(config);

            EntitiesTemplate = GetTemplate(entitiesTemplateName);
            PersistenceTemplate = GetTemplate(persistenceTemplateName);
            DapperInitialiserTemplate = GetTemplate(dapperInitialiserTemplateName);

        }

        public string GenerateEntity(EntitiesTemplateModel entitiesTemplateModel)
        {
            EnsureTemplatesAreLoaded();
            return EntitiesTemplate.Render(entitiesTemplateModel);
        }

        public string GeneratePersistence(PersistenceTemplateModel persistenceModel)
        {
            EnsureTemplatesAreLoaded();
            return PersistenceTemplate.Render(persistenceModel);
        }

        public string GenerateDapperMapper(DapperInitialiserTemplateModel dapperInitialiserModel)
        {
            EnsureTemplatesAreLoaded();
            return DapperInitialiserTemplate.Render(dapperInitialiserModel);
        }

        private Template EntitiesTemplate { get; set; }
        private Template PersistenceTemplate { get; set; }
        private Template DapperInitialiserTemplate { get; set; }


        private void EnsureTemplatesAreLoaded()
        {
            if (Interlocked.Add(ref _isLoaded, 0) == 0)
                throw new InvalidOperationException($"Please call {nameof(LoadTemplates)} first.");
        }

        
        private static Template GetTemplate(string templateFileName)
        {
            return Template.Parse(EmbeddedResource.GetContent(templateFileName), templateFileName);
        }
    }

    internal interface ITemplateService
    {
        void LoadTemplates(CodeGenConfig config);

        string GenerateEntity(EntitiesTemplateModel entitiesTemplateModel);

        string GeneratePersistence(PersistenceTemplateModel persistenceModel);

        string GenerateDapperMapper(DapperInitialiserTemplateModel dapperInitialiserModel);
    }
}