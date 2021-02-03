using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public static class TempStorage
    {
        private static List<MovieInfo> infos = new List<MovieInfo>();

        public static IEnumerable<MovieInfo> Infos => infos;

        public static void AddMovieInfo(MovieInfo info)
        {
            infos.Add(info);
        }
    }
}
