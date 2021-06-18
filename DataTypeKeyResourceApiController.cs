namespace Codery.DataTypePicker
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using Umbraco.Core.Models;
    using Umbraco.Web.WebApi;

    // /Umbraco/Api/DataTypeKeyResourceApi <-- UmbracoApiController

    // [IsBackOffice]
    // /Umbraco/backoffice/Api/DataTypeKeyResourceApi <-- UmbracoAuthorizedApiController

    [IsBackOffice]
    public class DataTypeKeyResourceApiController : UmbracoAuthorizedApiController
    {
        /// /Umbraco/backoffice/Api/DataTypeKeyResourceApi/GetAll
        [System.Web.Http.AcceptVerbs("GET")]
        public HttpResponseMessage GetAll()
        {
            var dtService = Services.DataTypeService;
            var allDts = dtService.GetAll();
            var allResources = new List<DataTypeKeyResource>();

            foreach (var dt in allDts)
            {
                var resource = new DataTypeKeyResource();
                resource.Name = dt.Name;
                resource.Id = dt.Id;
                resource.GuidKey = dt.Key;
                resource.DbType = dt.DatabaseType;
                resource.EditorAlias = dt.EditorAlias;

                allResources.Add(resource);
            }

            string json = JsonConvert.SerializeObject(allResources);

            return new HttpResponseMessage()
            {
                Content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                )
            };
        }

    }


    public class DataTypeKeyResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid GuidKey { get; set; }
        public ValueStorageType DbType { get; set; }
        public string EditorAlias { get; set; }
    }
}
