using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using powerpollService.DataObjects;
using powerpollService.Models;
using Tweetinvi;

namespace powerpollService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials(
                "3004124297-zzToru8oHmIGxJAOyWojqeRP2fxgzx25irOO4de",
                "Sa8CerPNMZfOh3hiWQ30gu9pxADnfnOAAAUGN4dlENKhd",
                "dQPcIhiNdtHAchfx7ZbsjeDAW",
                "V53RXnrRhpq6ReHa6qtRKi5J5IhLz5HzYCyXAJP031krCzreur");

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new powerpollInitializer());
        }
    }

    public class powerpollInitializer : ClearDatabaseSchemaIfModelChanges<powerpollContext>
    {
        protected override void Seed(powerpollContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
}

