using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace safeteefy_api.Shared.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(p => p.Value.Errors)
                .Select(p => p.ErrorMessage)
                .ToList();
        }
    }
}