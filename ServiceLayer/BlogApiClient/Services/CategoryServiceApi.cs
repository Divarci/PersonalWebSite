using CoreLayer.ResponseModel;
using EntityLayer.BlogApi.ViewModels.ArticleViewModels;
using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace ServiceLayer.BlogApiClient.Services
{
    public class CategoryServiceApi
    {
        private readonly HttpClient _httpClient;

        public CategoryServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
           
        }

        public async Task<(CustomResponseVM<List<CategoryListVM>>,short)> GetCategoryListAsync()
        {

            var response = await _httpClient.GetAsync("Category");
            var contentCategoryList = JsonConvert.DeserializeObject<CustomResponseVM<List<CategoryListVM>>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);
            return (contentCategoryList, statusCode);
        }

        public async Task<(CustomResponseVM<CategoryUpdateVM>,short)> GetCategoryByIdAsync(int id, HttpClient myClient)
        {
            var response = await myClient.GetAsync($"Category/{id}");
            var contentCategory = JsonConvert.DeserializeObject<CustomResponseVM<CategoryUpdateVM>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);
            return (contentCategory, statusCode);
        }

        public async Task<(CustomResponseVM<NoContentVM>, short)> UpdateCategoryAsync(CategoryUpdateVM updatedCategory, HttpClient myClient)
        {
           
            var rowVersionBase64 = Convert.ToBase64String(updatedCategory.RowVersion);

            var newContent = new MultipartFormDataContent();

            newContent.Add(new StringContent(updatedCategory.Id.ToString() ?? string.Empty),"Id");
            newContent.Add(new StringContent(updatedCategory.Name ?? string.Empty),"Name");
            newContent.Add(new StringContent(rowVersionBase64 ?? string.Empty), "RowVersion");

            var response = await myClient.PutAsync("Category", newContent);
            var responseContent = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);     
            
            return (responseContent, statusCode);
        }

        public async Task<(CustomResponseVM<CategoryAddVM>,short)> AddCategoryAsync(CategoryAddVM newCategory, HttpClient myClient)
        {
            var response = await myClient.PostAsJsonAsync("Category", newCategory);
            var contentResponse = JsonConvert.DeserializeObject<CustomResponseVM<CategoryAddVM>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);  
            return (contentResponse, statusCode);
        }

        public async Task<(CustomResponseVM<NoContentVM>, short)> DeleteCategoryAsync(int id, HttpClient myClient)
        {
            var response = await myClient.DeleteAsync($"category/{id}");
            var contentResponse = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);
            return (contentResponse, statusCode);

        }
    }
}
