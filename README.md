# Kek
Kek is a public C# Instagram Wrapper!

#Usage
#Functions Non Botting:
```Logon(string username, string password)```
Logs a user on

```Register(string username, string password, string email, string name)```
Registers a user

```TurboName(string username)```
Turbos a username

```Like(string posturl)```
Likes a post

```Follow(string username)```
Follows a user

```Unfollow(string username)```
Unfollows a user

```Unlike(string pic)```
Unlike a post

```Comment(string post, string comment)```
Comment on a post

```Report(string post, Kek.Kek.ReportType.TYPE)```
Report a post

#Functions For Botting:
```Logon(string username, string password, string proxy, string useragent)```
Logs a user on

```Register(string username, string password, string email, string name, string proxy, string useragent)```
Registers a user

```TurboName(string username, string proxy, string useragent)```
Turbos a username

```Like(string posturl, string proxy, string useragent)```
Likes a post

```Follow(string username, string proxy, string useragent)```
Follows a user

```Unfollow(string username, string proxy, string useragent)```
Unfollows a user

```Unlike(string pic, string proxy, string useragent)```
Unlike a post

```Comment(string post, string comment, string proxy, string useragent)```
Comment on a post

```Report(string post, Kek.Kek.ReportType.TYPE, string proxy, string useragent)```
Report a post


Usage not botting:
#Logging In
```
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Username", "Password"))
{
	MessageBox.Show("logged in");
}
```

#Registering
```
Kek.Kek kek = new Kek.Kek(false);
if(kek.Register("Testin123", "Testing123", "testing+1@gmail.com", "Test Lol"))
{
	MessageBox.Show("registered");
}
```

#Turbo
```
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testing123", "Testin123"))
{
	if(kek.TurboName("astro")) 
	{
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
	}
}
```

#Follow
```
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testin123", "Testing123"))
{
	if(kek.Follow("Testing1234"))
	{
		MessageBox.Show("Followed");
	}
}
```

#Unfollow
```
Kek.Kek kek = new Kek.Kek(false);
if(kek.Logon("Testing123", "Testing123"))
{
	if(kek.Unfollow("Testing1234"))
	{
		MessageBox.Show("Unfollowed");
	}
}
```

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
{
	if(kek.Like("https://www.instagram.com/p/BHOReJnjzgo/", proxy, useragent))
	{
		MessageBox.Show("Liked");
	}
}
```

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
{
	if(kek.Unlike("https://www.instagram.com/p/BHOReJnjzgo/", proxy, useragent))
	{
		MessageBox.Show("Unliked");
	}
}
```

#Comment
```
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Testing123", "Testing123", proxy, useragent))
{
	if(kek.Comment("https://www.instagram.com/p/BHOReJnjzgo/", "Okokokok", proxy, useragent))
	{
		MessageBox.Show("Commented");
	}
}
```

#Report
```
Kek.Kek kek = new Kek.Kek(false);
string proxy = "PROXY:PORT";
string useragent = kek.UAs[new Random().Next(0, kek.UAs.Length - 1)];
if(kek.Logon("Testing123","Testing123", proxy, useragent))
{
	if(kek.Report("https://www.instagram.com/p/BHOReJnjzgo/", Kek.Kek.ReportType.Nudity, proxy, useragent)) 
	{
		MessageBox.Show("Reported");
	}
}
```
