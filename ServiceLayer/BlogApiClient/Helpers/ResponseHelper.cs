using CoreLayer.ResponseModel;
using Newtonsoft.Json;

namespace ServiceLayer.BlogApiClient.Helpers
{
    public static class ResponseHelper<T> where T : class
    {
        public static async Task<CustomResponseVM<T>> ResponseCheck(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            switch (Convert.ToInt16(response.StatusCode))
            {
                case 400:
                    var modelError = JsonConvert.DeserializeObject<CustomResponseVM<T>>(responseContent);
                    return modelError;

                default:

                    if (Convert.ToInt16(response.StatusCode) == 401)
                    {
                        var errorList = JsonConvert.DeserializeObject<CustomResponseVM<T>>(responseContent);
                        return errorList;
                    }

                    if (Convert.ToInt16(response.StatusCode) == 403)
                    {
                        var errorList = JsonConvert.DeserializeObject<CustomResponseVM<T>>(responseContent);
                        return errorList;
                    }


                    if (Convert.ToInt16(response.StatusCode) == 400)
                    {
                        var errorList = JsonConvert.DeserializeObject<CustomResponseVM<T>>(responseContent);
                        return errorList;
                    }

                    if (Convert.ToInt16(response.StatusCode) == 500)
                    {
                        var errorList = JsonConvert.DeserializeObject<CustomResponseVM<T>>(responseContent);
                        return errorList;
                    }

                    var errorList2 = JsonConvert.DeserializeObject<CustomResponseVM<T>>(responseContent);
                    return errorList2;

            }






        }
    }
}
