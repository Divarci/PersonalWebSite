using EntityLayer.BlogApi.ResponseViewModel;
using EntityLayer.BlogApi.ViewModels.ArticleViewModels;
using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace ServiceLayer.Services.BlogApiConsumer
{
    public class ArticleServiceApi
    {
        private readonly HttpClient _httpClient;

        public ArticleServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ArticleListVM>> GetAllArticleAsync()
        {    
            var responseArticleList = await _httpClient.GetFromJsonAsync<CustomResponseVM<List<ArticleListVM>>>("Article");
            return responseArticleList.Data;
        }

        public async Task<(ArticleUpdateVM, CustomResponseVM<NoContentVM>)> GetArticleByIdAsync(int id)
        {
            var category =await GetCategoriesForDropDown();
            
            var response = await _httpClient.GetAsync($"Article/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorList = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(content);
                return (null, errorList)!;
            }

            var success = JsonConvert.DeserializeObject<CustomResponseVM<ArticleUpdateVM>>(content);
            success.Data!.Categories = category;
            return (success.Data, null)!;
        }

        public async Task<List<CategoryListVM>> GetCategoriesForDropDown()
        {
            var responseCategory = await _httpClient.GetAsync("Category");
            var contentCategory = await responseCategory.Content.ReadAsStringAsync();           
            var category = JsonConvert.DeserializeObject<CustomResponseVM<List<CategoryListVM>>>(contentCategory).Data;
            return category;
        }

        public async Task<(CustomResponseVM<NoContentVM>,List<CategoryListVM>)> ArticleUpdateAsync(ArticleUpdateVM updatedArticle)
        {
            var category = await GetCategoriesForDropDown();

            if (updatedArticle.Photo == null)
            {

                var newContent = new MultipartFormDataContent();

                newContent.Add(new StringContent(updatedArticle.Id.ToString() ?? string.Empty), "Id");
                newContent.Add(new StringContent(updatedArticle.Title ?? string.Empty), "Title");
                newContent.Add(new StringContent(updatedArticle.Content ?? string.Empty), "Content");
                newContent.Add(new StringContent(updatedArticle.Author ?? string.Empty), "Author");
                newContent.Add(new StringContent(updatedArticle.CategoryId.ToString() ?? string.Empty), "CategoryId");

                var response = await _httpClient.PutAsync("Article", newContent);
                var responseContent = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {

                    var errorList = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(responseContent);
                    return (errorList,category);
                }
                category = null;
                return (null, category)!;
            }

             var newContentWithPhoto = new MultipartFormDataContent();

            newContentWithPhoto.Add(new StringContent(updatedArticle.Id.ToString() ?? string.Empty), "Id");
            newContentWithPhoto.Add(new StringContent(updatedArticle.Title ?? string.Empty), "Title");
            newContentWithPhoto.Add(new StringContent(updatedArticle.Content ?? string.Empty), "Content");
            newContentWithPhoto.Add(new StringContent(updatedArticle.Author ?? string.Empty), "Author");
            newContentWithPhoto.Add(new StringContent(updatedArticle.CategoryId.ToString() ?? string.Empty), "CategoryId");
            newContentWithPhoto.Add(new StreamContent(updatedArticle.Photo.OpenReadStream()), "Photo", updatedArticle.Photo.FileName);

            var responseWithPhoto = await _httpClient.PutAsync("Article", newContentWithPhoto);
            var responseWithPhotoContent = await responseWithPhoto.Content.ReadAsStringAsync();
            if (!responseWithPhoto.IsSuccessStatusCode)
            {
                var errorList = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(responseWithPhotoContent);
                return (errorList, category);
            }

            category = null;
            return (null, category)!;
        }


        public async Task<CustomResponseVM<ArticleAddVM>> AddArticleAsync(ArticleAddVM newArticle)
        {
            var categories = await GetCategoriesForDropDown();

            if (newArticle.Photo == null)
            {
                return new CustomResponseVM<ArticleAddVM>() { Data = new ArticleAddVM { Categories= categories }, Errors = new List<string> { "Photo is required" } };
            }

            var newContent = new MultipartFormDataContent();

            newContent.Add(new StringContent(newArticle.Title ?? string.Empty), "Title");
            newContent.Add(new StringContent(newArticle.Content ?? string.Empty), "Content");
            newContent.Add(new StringContent(newArticle.Author ?? string.Empty), "Author");
            newContent.Add(new StringContent(newArticle.CategoryId.ToString() ?? string.Empty), "CategoryId");
            newContent.Add(new StreamContent(newArticle.Photo.OpenReadStream()), "Photo", newArticle.Photo.FileName);

            var response = await _httpClient.PostAsync("Article", newContent);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorList = JsonConvert.DeserializeObject<CustomResponseVM<ArticleAddVM>>(responseContent);
                
                return new CustomResponseVM<ArticleAddVM>() { Data = new ArticleAddVM { Categories = categories }, Errors = errorList.Errors }; ;
            }

            var success = JsonConvert.DeserializeObject<CustomResponseVM<ArticleAddVM>>(responseContent);
            return success;
        }

       public async Task<(CustomResponseVM<NoContentVM>,bool)> DeleteArticleAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Article/{id}");
            var responseContent =await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var errorList = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(responseContent);
                return (errorList, false);
            }

            return (null, true)!;
        }
    }
}


