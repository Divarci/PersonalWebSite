using CoreLayer.ResponseModel;
using EntityLayer.AuthServer.Entities;
using EntityLayer.BlogApi.ViewModels.ArticleViewModels;
using EntityLayer.BlogApi.ViewModels.CategoryViewModels;
using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.BlogApiClient.Exceptions;
using ServiceLayer.BlogApiClient.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace ServiceLayer.BlogApiClient.Services
{
    public class ArticleServiceApi
    {
        private readonly HttpClient _httpClient;

        public ArticleServiceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(CustomResponseVM<List<ArticleListVM>>, short)> GetAllArticleAsync(HttpClient myClient)
        {
            var response = await myClient.GetAsync("Article");
            var content = JsonConvert.DeserializeObject<CustomResponseVM<List<ArticleListVM>>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);

            return (content, statusCode);

        }

        public async Task<(CustomResponseVM<ArticleUpdateVM>, short)> GetArticleByIdAsync(int id, HttpClient myClient)
        {
            var categories = await GetCategoriesForDropDown(myClient);

            var response = await myClient.GetAsync($"Article/{id}");
            var responseContent = JsonConvert.DeserializeObject<CustomResponseVM<ArticleUpdateVM>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);

            if (responseContent.Data == null)
            {
                var newData = new ArticleUpdateVM { Categories = categories };
                responseContent.Data = newData;
                return (responseContent, statusCode);
            }

            responseContent.Data!.Categories = categories;
            return (responseContent, statusCode);

        }

        public async Task<List<CategoryListVM>> GetCategoriesForDropDown(HttpClient myClient)
        {
            var response = await myClient.GetAsync("Category");
            var responseContent = JsonConvert.DeserializeObject<CustomResponseVM<List<CategoryListVM>>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);
            if (statusCode == 200)
            {
                if (responseContent.Data == null)
                {
                    throw new CustomNullException("You do not have any category to add in!");
                }

                if (!responseContent.Data.Any())
                {
                    throw new CustomNullException("You do not have any category to add in!");
                }

                return responseContent.Data!;
            }

            throw new ConflictException(responseContent.Errors!.FirstOrDefault());

        }

        public async Task<(CustomResponseVM<ArticleUpdateVM>, short)> ArticleUpdateAsync(ArticleUpdateVM updatedArticle, HttpClient myClient)
        {
            var categories = await GetCategoriesForDropDown(myClient);
            var newContent = new MultipartFormDataContent();

            if (updatedArticle.Photo == null)
            {
                newContent.Add(new StringContent(updatedArticle.Id.ToString() ?? string.Empty), "Id");
                newContent.Add(new StringContent(updatedArticle.Title ?? string.Empty), "Title");
                newContent.Add(new StringContent(updatedArticle.Content ?? string.Empty), "Content");
                newContent.Add(new StringContent(updatedArticle.Author ?? string.Empty), "Author");
                newContent.Add(new StringContent(updatedArticle.CategoryId.ToString() ?? string.Empty), "CategoryId");

                var rowVersionBase64 = Convert.ToBase64String(updatedArticle.RowVersion);
                newContent.Add(new StringContent(rowVersionBase64), "RowVersion");
            }
            else
            {
                newContent.Add(new StringContent(updatedArticle.Id.ToString() ?? string.Empty), "Id");
                newContent.Add(new StringContent(updatedArticle.Title ?? string.Empty), "Title");
                newContent.Add(new StringContent(updatedArticle.Content ?? string.Empty), "Content");
                newContent.Add(new StringContent(updatedArticle.Author ?? string.Empty), "Author");
                newContent.Add(new StringContent(updatedArticle.CategoryId.ToString() ?? string.Empty), "CategoryId");

                var rowVersionBase64 = Convert.ToBase64String(updatedArticle.RowVersion);
                newContent.Add(new StringContent(rowVersionBase64), "RowVersion");

                var photoContent = new StreamContent(updatedArticle.Photo.OpenReadStream());
                photoContent.Headers.Add("Content-Type", updatedArticle.Photo.ContentType);

                newContent.Add(photoContent, "Photo", updatedArticle.Photo.FileName);
            }

            var response = await myClient.PutAsync("Article", newContent);
            var statusCode = Convert.ToInt16(response.StatusCode);
            var responseContent = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(await response.Content.ReadAsStringAsync());
            if (response.IsSuccessStatusCode)
            {
                return (null, statusCode)!;
            }
            var dataWithCategory = new CustomResponseVM<ArticleUpdateVM> { Data = new ArticleUpdateVM { Categories = categories }, Errors = responseContent.Errors };
            return (dataWithCategory, statusCode);
        }

        public async Task<(CustomResponseVM<ArticleAddVM>, short)> AddArticleAsync(ArticleAddVM newArticle, HttpClient myClient)
        {
            var categories = await GetCategoriesForDropDown(myClient);

            if (newArticle.Photo == null)
            {
                var errorPhoto = new CustomResponseVM<ArticleAddVM>() { Data = new ArticleAddVM { Categories = categories }, Errors = new List<string> { "Photo is required" } };
                return (errorPhoto, 400);
            }

            var newContent = new MultipartFormDataContent();

            newContent.Add(new StringContent(newArticle.Title ?? string.Empty), "Title");
            newContent.Add(new StringContent(newArticle.Content ?? string.Empty), "Content");
            newContent.Add(new StringContent(newArticle.Author ?? string.Empty), "Author");
            newContent.Add(new StringContent(newArticle.CategoryId.ToString() ?? string.Empty), "CategoryId");

            var photoContent = new StreamContent(newArticle.Photo.OpenReadStream());
            photoContent.Headers.Add("Content-Type", newArticle.Photo.ContentType);

            newContent.Add(photoContent, "Photo", newArticle.Photo.FileName);

            var response = await myClient.PostAsync("Article", newContent);
            var responseContent = JsonConvert.DeserializeObject<CustomResponseVM<ArticleAddVM>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);

            var dataWithCategory = new ArticleAddVM { Categories = categories };
            responseContent.Data = dataWithCategory;

            return (responseContent, statusCode);

        }

        public async Task<(CustomResponseVM<NoContentVM>, short)> DeleteArticleAsync(int id, HttpClient myClient)
        {
            var response = await myClient.DeleteAsync($"Article/{id}");
            var responseContent = JsonConvert.DeserializeObject<CustomResponseVM<NoContentVM>>(await response.Content.ReadAsStringAsync());
            var statusCode = Convert.ToInt16(response.StatusCode);

            return (responseContent, statusCode);
        }
    }
}


