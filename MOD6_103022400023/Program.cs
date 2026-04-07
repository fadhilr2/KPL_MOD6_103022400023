using System.Diagnostics;
using System.Diagnostics.Contracts;

public class SayaMusicTrack
{
    private int id;
    public string title;
    private int playCount;
    public SayaMusicTrack(string title)
    {

        Debug.Assert(title != null, "Precondition gagal: judul track tidak boleh null");
        Debug.Assert(title.Length <= 200, "Precondition gagal: karakter judul track tidak boleh lebih dari 200");
        this.title = title;
        this.playCount = 0;

        Random random = new Random();
        this.id = random.Next(10000, 99999);

        this.playCount = 0;
    }
    public void increasePlayCount(int count)
    {
        Debug.Assert((count) <= 25000000, "Precondition gagal: input play count melebihi 25.000.000");
        Debug.Assert(count > 0, "Precondition gagal: input play count tidak boleh negatif");
        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine($"Gagal menambah {count} ke play count. Telah melebihi batas integer (overflow)");
        }
    }

    public void printTrackDetails()
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
        Debug.Assert(username != null, "Precondition gagal: username tidak boleh null");
        Debug.Assert(username.Length <= 100, "Precondition gagal: karakter username tidak boleh melebihi 100");

        this.Username = username;
        this.uploadedTracks = new List<SayaMusicTrack>();
        Random random = new Random();
        this.id = random.Next(10000, 99999);
    }

    public void addTrack(SayaMusicTrack track)
    {
        Debug.Assert(track.getPlayCount() < int.MaxValue, "Precondition gagal: Playcount melebihi int.MAXVALUE atau lebih dari maksimal int");
        uploadedTracks.Add(track);
    }

    public void printAllTracks()
    {
        Console.WriteLine($"User: {Username}'s Playlist:");
        Contract.Ensures(this.uploadedTracks.Count <= 8, "Postcondition gagal: jumlah track yang ditampilkan harus kurang dari 8");
        foreach (var track in uploadedTracks)
        {
            track.printTrackDetails();
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
        Console.WriteLine("TEST ASSERT");
        //SayaMusicTrack track3 = new SayaMusicTrack("test");
        //SayaMusicTrack track1 = new SayaMusicTrack("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        //SayaMusicTrack track2 = new SayaMusicTrack(null);
        //track3.increasePlayCount(25000000+1);
        //track3.increasePlayCount(-1);
        //SayaMusicUser user2 = new SayaMusicUser("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        SayaMusicUser user1 = new SayaMusicUser("Fadil");
        //track3 = new SayaMusicTrack("test");
        //track3.increasePlayCount(2);
        //user1.addTrack(track3);

        for (int i = 0; i < 10; i++)
        {
            SayaMusicTrack track = new SayaMusicTrack($"Song {i + 1}");
            Random random = new Random();
            int cnt = random.Next(1, 10);
            track.increasePlayCount(cnt);
            user1.addTrack(track);
        }

        List<SayaMusicTrack> uploadedTracks = user1.getUploadedTracks();

        user1.printAllTracks();
        Console.WriteLine($"Total Play Count: {user1.getTotalPlayCount()}");
        Console.WriteLine();
        foreach (SayaMusicTrack track in uploadedTracks)
        {
            Console.WriteLine($"Review Lagu {track.title} oleh {user1.Username}");
        }
        Console.WriteLine();

    }
}