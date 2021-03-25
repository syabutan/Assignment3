using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment3.Pages
{
    public class MovieCollectionModel : PageModel
    {
        private iMovieRepository repository;
        public MovieCollectionModel(iMovieRepository repo, Collection collectionService)
        {
            repository = repo;
            Collection = collectionService;
        }

        public Collection Collection { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPostRemove(long movieId, string returnUrl)
        {
            MovieInfo movieInfo = repository.Movies.FirstOrDefault(p => p.MovieId == movieId);

            Collection.RemoveLine(Collection.Lines.First(cl =>
            cl.MovieInfo.MovieId == movieId).MovieInfo);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

    }
}
