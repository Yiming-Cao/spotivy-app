﻿namespace spotivy_app.spotivy
{
    public class Album : SongCollection
    {
        public List<Artist> Artists { get; set; }

        public Album(List<Artist> artists, string title, List<Song> songs) : base(title)
        {
            Artists = artists;

            foreach (var song in songs)
            {
                playables.Add(song);
            }
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
