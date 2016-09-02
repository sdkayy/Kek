# Kek
Kek is a public C# Instagram Wrapper!

<<<<<<< HEAD
#User.cs
=======
#Usage
#Functions Non Botting:
>>>>>>> origin/master
```Logon(string username, string password)```
Logs a user on

```Register(string username, string password, string email, string name)```
Registers a user

```ChangeName(string username)```
Changes a username

```Follow(string username)```
Follows a user

```Unfollow(string username)```
Unfollows a user

#Post.cs
```Unlike(string pic)```
Unlike a post

```Like(string posturl)```
Likes a post

```Comment(string post, string comment)```
Comment on a post

```Report(string post, Kek.Kek.ReportType.TYPE)```
Report a post


#Login
```
<<<<<<< HEAD
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
if(user.Logon("Username", "Password"))
=======
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Username", "Password"))
>>>>>>> origin/master
{
	MessageBox.Show("logged in");
}
```

#Registering
```
<<<<<<< HEAD
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
if(user.Register("Testin123", "Testing123", "testing+1@gmail.com", "Test Lol"))
=======
Kek.Kek kek = new Kek.Kek(false);
if(kek.Register("Testin123", "Testing123", "testing+1@gmail.com", "Test Lol"))
>>>>>>> origin/master
{
	MessageBox.Show("registered");
}
```

#Changing a Name
```
<<<<<<< HEAD
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
if(user.Logon("Testing123", "Testin123"))
=======
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testing123", "Testin123"))
>>>>>>> origin/master
{
	if(user.ChangeName("astro")) 
	{
<<<<<<< HEAD
		MessageBox.Show("Name Changed");
=======
		MessageBox.Show("Turboed");
	}
}
```

#Like
```
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testin123", "Testing123"))
{
	if(kek.Like("https://www.instagram.com/p/BHOReJnjzgo/"))
	{
		MessageBox.Show("Liked");
>>>>>>> origin/master
	}
}
```

#Follow
```
<<<<<<< HEAD
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
if(user.Logon("Testin123", "Testing123"))
=======
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testin123", "Testing123"))
>>>>>>> origin/master
{
	if(user.Follow("Testing1234"))
	{
		MessageBox.Show("Followed");
	}
}
```

#Unfollow
```
<<<<<<< HEAD
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testing123", "Testing123"))
=======
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testing123", "Testing123"))
>>>>>>> origin/master
{
	if(user.Unfollow("Testing1234"))
	{
		MessageBox.Show("Unfollowed");
	}
}
```

<<<<<<< HEAD
#Like
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testin123", "Testing123"))
=======
#Unlike
```
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testing123", "Testing123"))
{
	if(kek.Unlike("https://www.instagram.com/p/BHOReJnjzgo/"))
	{
		MessageBox.Show("Unliked");
	}
}
```

#Comment
```
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testing123", "Testing123"))
{
	if(kek.Comment("https://www.instagram.com/p/BHOReJnjzgo/", "Okokokok"))
	{
		MessageBox.Show("Commented");
	}
}
```

#Report
```
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testing123","Testing123"))
{
	if(kek.Report("https://www.instagram.com/p/BHOReJnjzgo/", Kek.Kek.ReportType.Nudity)) 
	{
		MessageBox.Show("Reported");
	}
}
```

Usage for botting:
Logging In
```
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Username", "Password", proxy, useragent))
{
	MessageBox.Show("logged in");
}
```

#Registering
```
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Register("Testin123", "Testing123", "testing+1@gmail.com", "Test Lol", proxy, useragent))
{
	MessageBox.Show("registered");
}
```

#Turbo
```
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Testing123", "Testin123", proxy, useragent))
{
	if(kek.TurboName("astro", proxy, useragent)) 
	{
		MessageBox.Show("Turboed");
	}
}
```

#Like
```
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Testin123", "Testing123", proxy, useragent))
>>>>>>> origin/master
{
	if(post.Like("https://www.instagram.com/p/BHOReJnjzgo/"))
	{
		MessageBox.Show("Liked");
	}
}
```

<<<<<<< HEAD
#Unlike
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testing123", "Testing123"))
=======
#Follow
```
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Testin123", "Testing123", proxy, useragent))
{
	if(kek.Follow("Testing1234", proxy, useragent))
	{
		MessageBox.Show("Followed");
	}
}
```

#Unfollow
```
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Testing123", "Testing123", proxy, useragent))
{
	if(kek.Unfollow("Testing1234", proxy, useragent))
	{
		MessageBox.Show("Unfollowed");
	}
}
```

#Unlike
```
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Testing123", "Testing123", proxy, useragent))
>>>>>>> origin/master
{
	if(post.Unlike("https://www.instagram.com/p/BHOReJnjzgo/"))
	{
		MessageBox.Show("Unliked");
	}
}
```

#Comment
```
<<<<<<< HEAD
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testing123", "Testing123"))
=======
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Testing123", "Testing123", proxy, useragent))
>>>>>>> origin/master
{
	if(post.Comment("https://www.instagram.com/p/BHOReJnjzgo/", "Okokokok"))
	{
		MessageBox.Show("Commented");
	}
}
```

#Report
```
<<<<<<< HEAD
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testing123","Testing123"))
=======
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Testing123","Testing123", proxy, useragent))
>>>>>>> origin/master
{
	if(post.Report("https://www.instagram.com/p/BHOReJnjzgo/", Kek.Kek.ReportType.Nudity)) 
	{
		MessageBox.Show("Reported");
	}
}
```

#Contact
Instagram: @teh_sdk
