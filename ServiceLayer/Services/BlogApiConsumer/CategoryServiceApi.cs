using EntityLayer.BlogApi.ResponseViewModel;
using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ServiceLayer.Services.BlogApiConsumer
{
    public class CategoryServiceApi
    {
        private readonly HttpClient _httpClient;

        public CategoryServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryListVM>> GetCategoryListAsync()
        {
            var responseCategoryList = await _httpClient.GetFromJsonAsync<CustomResponseVM<List<CategoryListVM>>>("Category");
            return responseCategoryList.Data;
        
        }

        public async Task<(CategoryUpdateVM, CustomResponseVM<NoContentVM>)> GetCategoryByIdAsync(int id)
        {
            var responseCategory = await _httpClient.GetAsync($"Category/{id}");
            var contentCategory = await responseCategory.Content.ReadAsStringAsync();
            if (!responseCategory.IsSuccessStatusCode)
            {
                var errorList = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(contentCategory);
                return (null, errorList)!;
            }

            var success = JsonConvert.DeserializeObject<CustomResponseVM<CategoryUpdateVM>>(contentCategory);
            return (success.Data,null)!;
        }

        public async Task<(CustomResponseVM<NoContentVM>,bool)> UpdateCategoryAsync(CategoryUpdateVM updatedCategory)
        {
            var responseCategoryUpdate = await _httpClient.PutAsJsonAsync("Category", updatedCategory);
            var contentCategoryUpdate = await responseCategoryUpdate.Content.ReadAsStringAsync();
            if(!responseCategoryUpdate .IsSuccessStatusCode)
            {
                var errorList = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(contentCategoryUpdate);
                return (errorList,false);
            }
            return (null,true)!;

        }

        public async Task<CustomResponseVM<CategoryAddVM>> AddCategoryAsync(CategoryAddVM newCategory)
        {
            var responseCategoryAdd = await _httpClient.PostAsJsonAsync("Category", newCategory);
            var contentCategoryAdd =await responseCategoryAdd.Content.ReadAsStringAsync();
            
            if(!responseCategoryAdd.IsSuccessStatusCode)
            {
                var errorList = JsonConvert.DeserializeObject<CustomResponseVM<CategoryAddVM>>(contentCategoryAdd);
                return errorList;
            }

            var success = JsonConvert.DeserializeObject<CustomResponseVM<CategoryAddVM>>(contentCategoryAdd);
            return success;
        }

        public async Task<(CustomResponseVM<NoContentVM>,bool)> DeleteCategoryAsync(int id)
        {
            var responseCategoryDelete = await _httpClient.DeleteAsync($"category/{id}");
            var contentCategoryDelete = await responseCategoryDelete.Content.ReadAsStringAsync();
            if(!responseCategoryDelete.IsSuccessStatusCode)
            {
                var errorList = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(contentCategoryDelete);
                return (errorList,false);
            }
            return (null, true)!;

        }
    }
}
