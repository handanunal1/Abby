using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(Category category)
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly math the name");
            }

            if (ModelState.IsValid)
            {
                _db.Category.AddAsync(category);
                _db.SaveChangesAsync();
                TempData["success"] = "Category created succesfully";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["error"] = "Category could not be created";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
