using AlbumAlertClient;

namespace AlbumAlert
{ 
    public class Program
    {
        private const string apiUrl = "https://musicbrainz.org/ws/2/";
        static void Main() // Do I need the string[] args parameter here?
        {
            AlbumAlertApp runProgram = new AlbumAlertApp();
            runProgram.run();
        }
    }
}