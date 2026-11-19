class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Make Pancakes", "Easy Cooking", 420);
        video1.AddComment(new Comment("Maria", "This recipe was very easy to follow."));
        video1.AddComment(new Comment("John", "My pancakes came out great!"));
        video1.AddComment(new Comment("Luis", "Thank you for sharing this video."));
        videos.Add(video1);

        Video video2 = new Video("Learning C# Basics", "Code for Beginners", 780);
        video2.AddComment(new Comment("Ana", "This helped me understand classes."));
        video2.AddComment(new Comment("David", "The examples were clear."));
        video2.AddComment(new Comment("Sofia", "I am learning C# too."));
        videos.Add(video2);

        Video video3 = new Video("A Walk in the Mountains", "Travel Days", 615);
        video3.AddComment(new Comment("Carlos", "The view is beautiful."));
        video3.AddComment(new Comment("Emily", "I want to visit this place."));
        video3.AddComment(new Comment("Pedro", "Very relaxing video."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}
