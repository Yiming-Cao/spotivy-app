using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy_app.spotivy
{
    class Artist
    {
        public string Naam { get; set; }
        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }

        public Artist(string naam, List<Album> albums)
        {
            Naam = naam;
            Albums = albums ?? new List<Album>();
            Songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            if (song != null && !Songs.Contains(song))
            {
                Songs.Add(song);
            }
        }

        public void AddAlbum(Album album)
        {
            if (album != null && !Albums.Contains(album))
            {
                Albums.Add(album);
            }
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
