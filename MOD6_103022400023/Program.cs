public class SayaMusicTrack
{
    private int id;
    public string title;
    private int playCount;
    public SayaMusicTrack(string title)
    {
        this.title = title;
        this.playCount = 0;

        Random random = new Random();
        this.id = random.Next(10000, 99999);

        this.playCount = 0;
    }
    public void increasePlayCount(int count)
    {
        this.playCount = count;
    }

    public void displayInfo()
    {
        Console.WriteLine($"Track {id} Judul    : {title}");
    }

    public int getPlayCount()
    {
        return playCount;
    }

}

public class SayaMusicUser
{
    private int id;
    public string Username;
    private List<SayaMusicTrack> uploadedTracks;

    public SayaMusicUser(string username)
    {
        this.Username = username;
        this.uploadedTracks = new List<SayaMusicTrack>();
        Random random = new Random();
        this.id = random.Next(10000, 99999);
    }

    public void addTrack(SayaMusicTrack track)
    {
        uploadedTracks.Add(track);
    }

    public void displayPlaylist()
    {
        Console.WriteLine($"User: {Username}'s Playlist:");
        foreach (var track in uploadedTracks)
        {
            track.displayInfo();
        }
    }

    public int getTotalPlayCount()
    {
        int totalPlayCount = 0;
        foreach (SayaMusicTrack track in uploadedTracks)
        {
            totalPlayCount += track.getPlayCount();
        }
        return totalPlayCount;

    }

    public List<SayaMusicTrack> getUploadedTracks()
    {
        return uploadedTracks;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaMusicUser user1 = new SayaMusicUser("Fadiil Rizky Akbar");

        for (int i = 0; i < 10; i++)
        {
            SayaMusicTrack track = new SayaMusicTrack($"Song {i + 1}");
            Random random = new Random();
            int cnt = random.Next(1, 10);
            track.increasePlayCount(cnt);
            user1.addTrack(track);
        }

        List<SayaMusicTrack> uploadedTracks = user1.getUploadedTracks();

        user1.displayPlaylist();
        Console.WriteLine($"Total Play Count: {user1.getTotalPlayCount()}");
        Console.WriteLine();
        foreach (SayaMusicTrack track in uploadedTracks)
        {
            Console.WriteLine($"Review Lagu {track.title} oleh {user1.Username}");
        }
    }
}