using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNamespace;
using AdminNamespace;
using PostNamespace;
using NotificationNamespace;

namespace DatabaseNamespace
{
    class DataBase
    {
        public User[] Users { get; set; }
        public Post[] Posts { get; set; }
        public Admin[] Admins { get; set; }
        public Notification[] Notifications { get; set; }
        public int UserCount { get; set; }
        public int PostCount { get; set; }
        public int AdminCount { get; set; }
        public int NotificationCount { get; set; }
        public void AddUser(User user)
        {
            int newCount = UserCount + 1;
            User[] newUsers = new User[newCount];
            for (int i = 0; i < UserCount; i++)
            {
                newUsers[i] = Users[i];
            }
            newUsers[UserCount] = user;
            ++UserCount;
            Users = newUsers;

        }
        public void AddAdmin(Admin admin)
        {
            int newCount = AdminCount + 1;
            Admin[] newAdmins = new Admin[newCount];
            for (int i = 0; i < AdminCount; i++)
            {
                newAdmins[i] = Admins[i];
            }
            newAdmins[AdminCount] = admin;
            ++AdminCount;
            Admins = newAdmins;

        }
        public void AddPost(Post post)
        {
            int newCount = PostCount + 1;
            Post[] newPosts = new Post[newCount];
            for (int i = 0; i < PostCount; i++)
            {
                newPosts[i] = Posts[i];
            }
            newPosts[PostCount] = post;
            ++PostCount;
            Posts = newPosts;

        }
        public void AddNotification(Notification notification)
        {
            int newCount = NotificationCount + 1;
            Notification[] newNotifications = new Notification[newCount];
            for (int i = 0; i < NotificationCount; i++)
            {
                newNotifications[i] = Notifications[i];
            }
            newNotifications[NotificationCount] = notification;
            ++NotificationCount;
            Notifications = newNotifications;

        }
        public void DeletePost(int id)
        {
            for (int i = 0; i < Posts.Length; i++)
            {
                if (Posts[i].Id == id)
                {
                    Post[] newclients = new Post[Posts.Length - 1];
                    for (int k = 0, j = 0; j < Posts.Length; j++)
                    {
                        if (j != i) newclients[k++] = Posts[j];
                    }
                    Posts = newclients;

                }
            }
        }
        public void ShowAllPosts()
        {
            foreach (var post in Posts)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                post.show();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void ShowAllUSers()
        {
            foreach (var user in Users)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                user.show();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void ShowAllNotifications()
        {
            foreach (var notification in Notifications)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                notification.show();
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
