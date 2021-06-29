using System;
using System.Text;
using UserNamespace;
using AdminNamespace;
using PostNamespace;
using NetworkNamespace;
using NotificationNamespace;
using DatabaseNamespace;
using System.Threading;
namespace MainNamespace
{
    class Display { 
        public static void show()
        {
            User user1 = new User
            {

                Username = "Amiraslan",
                Age = 18,
                Email = "emiraslaneliyev12@gmail.com",
                Password = "Azerbaycan"
            };
            User user2 = new User
            {

                Username = "Ferhad",
                Age = 18,
                Email = "ferhadaliyev035@gmail.com",
                Password = "Banan"
            };
            Admin admin = new Admin
            {

                Username = "kam",
                Email = "kamaleliyev035@gmail.com",
                Password = "kam"
            };
            Post post1 = new Post("My friends video");
            Post post2 = new Post("Varavskoy");
            Post post3 = new Post("About my lesson");
            Notification notification1 = new Notification
            {
                Id = 50,
                FromUser = user1,
                NotificationTime = DateTime.Now,
                Text = "Salam qaqa"
            };
            DataBase db = new DataBase();
            db.AddUser(user1);
            db.AddUser(user2);
            db.AddPost(post1);
            db.AddPost(post2);
            db.AddPost(post3);
            db.AddAdmin(admin);
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(40, 6);
                Console.WriteLine("[1]User");
                Console.SetCursorPosition(40, 7);
                Console.WriteLine("[2]Admin");
                Console.Write("Your option ");
                int option = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;
                if (option == 1)
                {
                    while (true)
                    {
                    lableRegister:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.SetCursorPosition(40, 6);
                        Console.WriteLine("[1]SignUp");
                        Console.SetCursorPosition(40, 7);
                        Console.WriteLine("[2]SignIn");
                        Console.SetCursorPosition(40, 8);
                        Console.WriteLine("[3]Back");
                        Console.Write("Your option ");
                        int option1 = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                        if (option1 == 1)
                        {

                            Console.Write("Enter your username: ");
                            string username = Console.ReadLine().ToString();
                            Console.Write("Enter your email: ");
                            string email = Console.ReadLine().ToString();
                            Console.Write("Enter your password: ");
                            string password = Console.ReadLine().ToString();
                            Console.Write("Enter your age: ");
                            int age = int.Parse(Console.ReadLine());
                            User user = new User { Age = age, Email = email, Password = password, Username = username };
                            db.AddUser(user);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You sucesfully registered"); Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(1500);
                            continue;

                        }
                        if (option1 == 2)
                        {
                            while (true)
                            {
                                Console.Write("Enter your username: ");
                                string username = Console.ReadLine().ToString();
                                Console.Write("Enter your password: ");
                                string password = Console.ReadLine().ToString();
                                foreach (var user in db.Users)
                                {
                                    if (user.Username == username && user.Password == password)
                                    {
                                        while (true)
                                        {
                                        lableview:
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.SetCursorPosition(40, 6);
                                            Console.WriteLine("[1]View posts");
                                            Console.SetCursorPosition(40, 7);
                                            Console.WriteLine("[2]Back");
                                            Console.Write("Your option:");
                                            int option5 = int.Parse(Console.ReadLine());
                                            Console.ForegroundColor = ConsoleColor.White;
                                            if (option5 == 1)
                                            {
                                                while (true)
                                                {
                                                    Console.Clear();
                                                    db.ShowAllPosts();
                                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                    Console.WriteLine("[1]Select Post(with id):");
                                                    Console.WriteLine("[2]Back");
                                                    int option6 = int.Parse(Console.ReadLine());
                                                    if (option6 == 1)
                                                    {
                                                        Console.Write("Select post: ");
                                                        int postId = int.Parse(Console.ReadLine());
                                                        foreach (var post in db.Posts)
                                                        {
                                                            if (postId == post.Id)
                                                            {
                                                                Console.Clear();
                                                                ++post.ViewCount;
                                                                Notification notification2 = new Notification { FromUser = user, NotificationTime = DateTime.Now, Text = $"{user.Username} view {post.Content} post" };
                                                                Network.net(notification2);
                                                                db.AddNotification(notification2);
                                                                post.show();
                                                                Console.SetCursorPosition(40, 8);
                                                                Console.WriteLine("Do you want like this post?(y/n)");
                                                                char likeOption = char.Parse(Console.ReadLine());
                                                                if (likeOption == 'Y' || likeOption == 'y')
                                                                {
                                                                    Notification notification = new Notification { FromUser = user, NotificationTime = DateTime.Now, Text = $"{user.Username} like {post.Content} post" };
                                                                    Network.net(notification);
                                                                    db.AddNotification(notification);
                                                                    Console.WriteLine("You liked this post");
                                                                    ++post.LikeCount;
                                                                }
                                                                else if (likeOption == 'N' || likeOption == 'n')
                                                                {
                                                                    break;

                                                                }
                                                            }
                                                        }
                                                    }
                                                    if (option6 == 2)
                                                    {
                                                        break;
                                                    }

                                                }
                                                continue;
                                            }
                                            else if (option5 == 2)
                                            {
                                                goto lableRegister;
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Your username or password incorrect"); Console.ForegroundColor = ConsoleColor.White;
                                continue;
                            }
                        }
                        if (option1 == 3)
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect option try again");
                            Console.ForegroundColor = ConsoleColor.White;
                            Thread.Sleep(1500);
                            continue;
                        }
                    }
                    continue;
                }
                if (option == 2)
                {
                    while (true)
                    {
                    label:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.SetCursorPosition(40, 6);
                        Console.WriteLine("[1]Log in");
                        Console.SetCursorPosition(40, 7);
                        Console.WriteLine("[2]Back");
                        Console.Write("Your option ");
                        int option3 = int.Parse(Console.ReadLine());
                        if (option3 == 1)
                        {
                            while (true)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("Enter your username: ");
                                string usernameAdmin = Console.ReadLine().ToString();
                                Console.Write("Enter your password: ");
                                string passwordAdmin = Console.ReadLine().ToString();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                foreach (var admIn in db.Admins)
                                {
                                    if (admin.Username == usernameAdmin && admin.Password == passwordAdmin)
                                    {
                                        while (true)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.SetCursorPosition(40, 6);
                                            Console.WriteLine("[1]Add Post");
                                            Console.SetCursorPosition(40, 7);
                                            Console.WriteLine("[2]Delete Post");
                                            Console.SetCursorPosition(40, 8);
                                            Console.WriteLine("[3]Update Post");
                                            Console.SetCursorPosition(40, 9);
                                            Console.WriteLine("[4]Show All Posts");
                                            Console.SetCursorPosition(40, 10);
                                            Console.WriteLine("[5]Show All users");
                                            Console.SetCursorPosition(40, 11);
                                            Console.WriteLine("[6]Show All notifications");
                                            Console.SetCursorPosition(40, 12);
                                            Console.WriteLine("[7]Back");
                                            Console.Write("Your option ");
                                            int option4 = int.Parse(Console.ReadLine());
                                            if (option4 == 1)
                                            {
                                                Console.Write("New Post content: ");
                                                string postContent = Console.ReadLine().ToString();
                                                Post post = new Post(postContent);
                                                Console.WriteLine("New Post succesfully added");
                                                Thread.Sleep(1500);
                                                continue;
                                            }
                                            if (option4 == 2)
                                            {
                                                Console.Clear();
                                                db.ShowAllPosts();
                                                Console.Write("Which post you want delete(with id)");
                                                int deleteId = int.Parse(Console.ReadLine());
                                                foreach (var post in db.Posts)
                                                {
                                                    if (post.Id == deleteId)
                                                    {
                                                        db.DeletePost(deleteId);
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine("This post delete succesfully "); Console.ForegroundColor = ConsoleColor.White;
                                                        Thread.Sleep(1500);
                                                        continue;
                                                    }
                                                }
                                            }
                                            if (option4 == 3)
                                            {
                                                Console.Clear();
                                                db.ShowAllPosts();
                                                Console.Write("Which post you want update(with id)");
                                                int updateId = int.Parse(Console.ReadLine());
                                                foreach (var post in db.Posts)
                                                {
                                                    if (post.Id == updateId)
                                                    {
                                                        Console.Write("New content of the this post: ");
                                                        string newContent = Console.ReadLine().ToString();
                                                        post.Content = newContent;
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine("This post content succesfully changed"); Console.ForegroundColor = ConsoleColor.White;
                                                        Thread.Sleep(1500);
                                                        continue;
                                                    }
                                                }
                                            }
                                            if (option4 == 4)
                                            {
                                                Console.Clear();
                                                db.ShowAllPosts();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Press any key go to back.."); Console.ForegroundColor = ConsoleColor.White;
                                                Console.ReadLine();
                                                continue;
                                            }
                                            if (option4 == 5)
                                            {
                                                db.ShowAllUSers();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Press any key go to back.."); Console.ForegroundColor = ConsoleColor.White;
                                                Console.ReadLine();
                                                continue;
                                            }
                                            if (option4 == 6)
                                            {
                                                Console.Clear();
                                                db.ShowAllNotifications();
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.Write("Press any key go to back.."); Console.ForegroundColor = ConsoleColor.White;
                                                Console.ReadLine();
                                                continue;
                                            }
                                            if (option4 == 7)
                                            {
                                                goto label;
                                            }
                                        }
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Your username or password incorrect"); Console.ForegroundColor = ConsoleColor.White;
                                continue;
                            }
                        }
                        else if (option3 == 2)
                        {
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect option try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    continue;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
               Display.show();
            }
            catch (FormatException ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }
    }
}
