using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class Collection
    {
        public List<CollectionLine> Lines { get; set; } = new List<CollectionLine>();

        public virtual void RemoveLine(MovieInfo movieInfo) =>
            Lines.RemoveAll(l => l.MovieInfo.MovieId == movieInfo.MovieId);

        public virtual void Clear() => Lines.Clear();

    }
    public class CollectionLine
    {
        public int CollectionLineID { get; set; }
        public MovieInfo MovieInfo { get; set; }
    }
}
