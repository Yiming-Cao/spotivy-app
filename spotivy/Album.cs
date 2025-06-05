using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy_app.spotivy
{
    class Album : SongCollection
    {
        public List<Artist> Artists { get; set; }

        public Album(List<Artist> artists, string title, List<Song> songs) : base(title)
        {
            Artists = artists;
        }

        public List<Artist> ShowArtists()
        {
            return Artists;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
