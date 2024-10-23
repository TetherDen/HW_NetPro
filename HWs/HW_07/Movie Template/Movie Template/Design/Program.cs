using Design.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void Main()
        //{
        //    Application.SetHighDpiMode(HighDpiMode.SystemAware);
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //}
        static async Task Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            var allGenres = await MovieApi.GetGenreList();
            var allMovies = await MovieApi.GetPopularMovies(page: 1);
            var allMoviesByName = await MovieApi.GetMoviesByName("Star wars", page: 1);
            var allMoviesByGenre = await MovieApi.GetMoviesByGenre(allGenres.genres[0].id, page: 1);
            var allMoviesByNameAndYear = MovieApi.GetMoviesByYearAndName("Star Wars", 2001);
            var currentMovie = await MovieApi.GetMovieById(allMoviesByGenre.Results[0].id);
            var similarMovies = await MovieApi.GetSimilarMovies(allMoviesByGenre.Results[0].id, page: 1);
        }
    }
}
