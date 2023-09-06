namespace EntityLayer.BlogApi.ViewModels.ArticleViewModels
{
    public class ArticleImageVM
    {
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public string? Error { get; set; }
        }
}
