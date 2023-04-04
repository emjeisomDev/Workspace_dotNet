using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Extensions
{
    public static class ModelStateExtention
    {
        public static List<String> GetErrors(this ModelStateDictionary modeState)
        {
            var result = new List<String>();
            foreach (var item in modeState.Values)
                result.AddRange(item.Errors.Select(error => error.ErrorMessage));
                //foreach (var error in item.Errors)
                //{
                //    result.Add(error.ErrorMessage);
                //}

            return result;
        }
    }
}
