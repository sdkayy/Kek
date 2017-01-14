# Kek
Kek is a public C# Instagram Wrapper!

#User.cs
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


#Waiting for a user to post
```
private void button1_Click(object sender, EventArgs e)
{
	backgroundWorker1.RunWorkerAsync();
}

Kek.Utils.Post post;
private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
{
	post = new Kek.Utils.Post();
	post.OnNewPost += new Kek.Utils.Post.NewPost(NewPost);
	post.WaitForPost("teh_sdk");
}

private void NewPost(object obj, Kek.Utils.PostArgs args)
{
	post.Like(args.Link);
	MessageBox.Show("SDK Posted and we liked it instantly! Nice!");
}
```

#Login
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
if(user.Logon("Username", "Password"))
{
	MessageBox.Show("logged in");
}
```

#Registering
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
if(user.Register("Testin123", "Testing123", "testing+1@gmail.com", "Test Lol"))
{
	MessageBox.Show("registered");
}
```

#Changing a Name
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
if(user.Logon("Testing123", "Testin123"))
{
	if(user.ChangeName("astro")) 
	{
		MessageBox.Show("Name Changed");
	}
}
```

#Follow
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
if(user.Logon("Testin123", "Testing123"))
{
	if(user.Follow("Testing1234"))
	{
		MessageBox.Show("Followed");
	}
}
```

#Unfollow
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testing123", "Testing123"))
{
	if(user.Unfollow("Testing1234"))
	{
		MessageBox.Show("Unfollowed");
	}
}
```

#Like
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testin123", "Testing123"))
{
	if(post.Like("https://www.instagram.com/p/BHOReJnjzgo/"))
	{
		MessageBox.Show("Liked");
	}
}
```

#Unlike
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testing123", "Testing123"))
{
	if(post.Unlike("https://www.instagram.com/p/BHOReJnjzgo/"))
	{
		MessageBox.Show("Unliked");
	}
}
```

#Comment
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testing123", "Testing123"))
{
	if(post.Comment("https://www.instagram.com/p/BHOReJnjzgo/", "Okokokok"))
	{
		MessageBox.Show("Commented");
	}
}
```

#Report
```
Kek.Kek kek = new Kek.Kek();
Kek.Utils.User user = new Kek.Utils.User();
Kek.Utils.Post post = new Kek.Utils.Post();
if(user.Logon("Testing123","Testing123"))
{
	if(post.Report("https://www.instagram.com/p/BHOReJnjzgo/", Kek.Kek.ReportType.Nudity)) 
	{
		MessageBox.Show("Reported");
	}
}
```

#Contact
Instagram: @teh_sdk
DM me for my email
