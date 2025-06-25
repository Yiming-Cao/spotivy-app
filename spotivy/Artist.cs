using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spotivy_app.spotivy
{
    public class Artist
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
                song.Artists.Add(this);
            }
        }

        public void AddAlbum(Album album)
        {
            if (album != null && !Albums.Contains(album))
            {
                Albums.Add(album);
                foreach (var playable in album.playables)
                {
                    if (playable is Song song)
                    {
                        AddSong(song);
                    }
                }
            }
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}
