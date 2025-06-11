using spotivy_app.spotivy;

public class SuperUser : Person
{
    public SuperUser(string naam) : base(naam)
    {
    }

    
    public void AddFriend(Person person)
    {
        if (person == null || Friends.Contains(person))
        {
            Messenger.SendMessage("Cannot add friend: null or already in list.");
            return;
        }
        Friends.Add(person);
        Messenger.SendMessage($"{Naam} added {person.Naam} as a friend.");
    }

    
    public void RemoveFriend(Person person)
    {
        if (Friends.Remove(person))
        {
            Messenger.SendMessage($"{Naam} removed {person.Naam} from friends.");
        }
        else
        {
            Messenger.SendMessage("Friend not found.");
        }
    }

    
    public void CreatePlaylist(string title)
    {
        Playlist newPlaylist = new Playlist(this, title);
        Playlists.Add(newPlaylist);
        Messenger.SendMessage($"{Naam} created playlist: {title}");
    }

    
    public void RemovePlaylist(int index)
    {
        if (index >= 0 && index < Playlists.Count)
        {
            Messenger.SendMessage($"{Naam} removed playlist: {Playlists[index].Title}");
            Playlists.RemoveAt(index);
        }
        else
        {
            Messenger.SendMessage("Invalid playlist index.");
        }
    }

    
}
