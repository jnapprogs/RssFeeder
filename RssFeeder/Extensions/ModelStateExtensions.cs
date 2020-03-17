using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RssFeeder.Extensions
{
    public static class ModelStateExtensions
    {
        public static Dictionary<string, string> ExtractErrors(this ModelStateDictionary modelState)
        {
            var errors = new Dictionary<string, string>();
            var erroneousFields = modelState.Where(ms => ms.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

            foreach (var erroneousField in erroneousFields)
            {
                var fieldKey = erroneousField.Key;
                var fieldErrors = erroneousField.Errors
                    .Select(error => new KeyValuePair<string, string>(fieldKey, error.ErrorMessage)).First();
                errors.Add(fieldErrors.Key, fieldErrors.Value);
            }

            return errors;
        }
    }
}
