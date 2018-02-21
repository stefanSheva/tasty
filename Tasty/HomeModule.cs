using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Nancy.Responses;
using Newtonsoft.Json;
using Tasty.Models;
using Tasty.Utils;
using static Tasty.Utils.Enum;

namespace Tasty
{
    public class HomeModule: NancyModule
    {
        dynamic CreateResponse<T>(T result) => new JsonResponse(result, new DefaultJsonSerializer());

        public HomeModule()
        {
            // Receipt Route
            Get["/dummy/receipts"] = p => 
            { 
                Repository.AddDummyReceipts();
                return CreateResponse(Repository.GetAllReceipts());
            };

            Get["/receipts"] = p => CreateResponse(Repository.ListOfReceipts);

            Get["/receipt/{id}"] = p => 
            {
                var res = Repository.ListOfReceipts.FirstOrDefault(r => r.Id == p.id);
                return CreateResponse(res);
            };

            Post["/receipts"] = p =>
            {
                var receipt = this.Bind<Receipt>();
                var result = Repository.AddReceipt(receipt);

                return CreateResponse(result);
            };

            Delete["/receipt/{id}"] = p =>
            {
                var res = Repository.DeleteReceipt(p.id);
                return CreateResponse(res);
            };


            // Ingredient Routes
            Get["/dummy/ingredients"] = p =>
            {
                Repository.AddDummyIngredients();

                return CreateResponse(Repository.GetAllIngredients());
            };

            Get["/ingredients"] = p => CreateResponse(Repository.ListOfIngredients);

            Get["/ingredient/{id}"] = p =>
            {
                var res = Repository.ListOfIngredients.FirstOrDefault(i => i.Id == p.id);
                return CreateResponse(res);
            };

            Post["/ingredients"] = p =>
            {
                var ingredient = this.Bind<Ingredient>();
                var res = Repository.AddIngredient(ingredient);

                return CreateResponse(res);
            };

            Delete["/ingredient"] = p =>
            {
                var res = Repository.DeleteIngredient(p.id);
                return CreateResponse(res);
            };
        }
    }
}
