using System.ComponentModel;

namespace EntityLayer.BlogApi.ViewModels.CategoryViewModels
{
    public class CategoryAddVM
    {
        [DisplayName("Title")]
        public string Name { get; set; } = null!;

    }
}
