using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Nancy.Responses;
using Newtonsoft.Json;
using Tasty.Models;
using static Tasty.Utils.Enum;

namespace Tasty
{
    public class HomeModule: NancyModule
    {
        public HomeModule()
        {
            Get["/dummy/receipts"] = p => 
            { 
                Repository.AddDummyReceipts();
                var result = Repository.GetAllReceipts();
                return new JsonResponse(result, new DefaultJsonSerializer());
            };
            Get["/receipts"] = p => new JsonResponse(Repository.ListOfReceipts, new DefaultJsonSerializer());
            Get["/receipts/{id}"] = p => Response.AsJson(Repository.ListOfReceipts.FirstOrDefault(r => r.Id == p.id));
            Post["/receipts"] = p =>
            {
                var receipt = this.Bind<Receipt>();
                Repository.AddReceipt(receipt);

                return new Response() { StatusCode = HttpStatusCode.Created };
            };

            Get["/dummy/ingredients"] = p =>
            {
                Repository.AddDummyIngredients();
                var result = Repository.GetAllIngredients();
                return new JsonResponse(result, new DefaultJsonSerializer());
            };
            Get["/ingredients"] = p => new JsonResponse(Repository.ListOfIngredients, new DefaultJsonSerializer());
            Get["/ingredients/{id}"] = p => Response.AsJson(Repository.ListOfIngredients.FirstOrDefault(i => i.Id == p.id));
            Post["/ingredients"] = p =>
            {
                var ingredient = this.Bind<Ingredient>();
                var name = Request.Form.Name;
                var unit = Request.Form.Unit;
                if (unit != Measure.Kilogram || unit != Measure.Litar)
                    unit = Measure.Kilogram;
                var id = Repository.AddIngredient(name, unit);

                return new Response() { StatusCode = HttpStatusCode.Accepted };
            };
        }
    }
}
