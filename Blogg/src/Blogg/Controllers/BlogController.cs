using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogg.Models;
using Blogg.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Blogg.Controllers
{
    public class BlogController : Controller
    {
        // GET: /<controller>/

        private BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult NewPost()
        {
            return View(GetCategories());
        }

        [HttpPost]
        public IActionResult NewPost(Post post)
        {

            List<SelectListItem> categories =
                new List<SelectListItem>
                (_context.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }));

            BlogNewPostViewModel vm = new BlogNewPostViewModel();
            vm.Category = categories;
            vm.Post = post;

            if (ModelState.IsValid)
            {
            post.Date = DateTime.Now;
            _context.Posts.Add(post);
            _context.SaveChanges();

            return View("NewPostConfirm");
            }

            else
            {
                return View(vm);
            }
        }

        private BlogNewPostViewModel GetCategories()
        {
            BlogNewPostViewModel vm = new BlogNewPostViewModel();

            List<SelectListItem> categories =
                new List<SelectListItem>(
                    _context.Categories.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Name}));
            vm.Category = categories;

            return vm;
        }

        public IActionResult ViewAllPosts()
        {
            var post = _context.Posts.ToList();
            var categories = _context.Categories.ToList();

            CategoryViewModel vm = new CategoryViewModel
            {
                Posts = post,
                Categories = categories
            };

            return View(vm);
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(string search)
        {
            BlogSearchViewModel vm = new BlogSearchViewModel();

            var postSearch = _context.Posts.Where(x => x.Title.Contains(search)).ToList();
            var categorySearch = _context.Categories.Where(x => x.Name.Contains(search)).ToList();

            List<Post> list = new List<Post>();
            List<Category> categoryPosts = new List<Category>();

            foreach (var post in postSearch)
            {
                list.Add(post);
            }

            foreach (var post in categorySearch)
            {
                list = _context.Posts.Where(x => x.CategoryId == post.Id).ToList();
            }
            vm.Posts = list;
            vm.Categories = categoryPosts;

            return View(vm);
        }

        public IActionResult ShowPost(int id)
        {
            var post = _context.Posts.Where(x => x.Id == id);

            return View(post);
        }

        public IActionResult Posts(int ID)
        {
            CategoryViewModel CategoryViewModel = new CategoryViewModel();
            CategoryViewModel.Categories = _context.Categories.ToList();

            var catList = _context.Posts.Where(x => x.CategoryId == ID).ToList().OrderByDescending(z => z.Date);
            CategoryViewModel.Posts = catList.ToList();
            return View("CategoryList", CategoryViewModel);
        }
    }
}
