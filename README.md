# EmailClient

A C# email client for pc

Will require access database driver. It can be found here: https://www.microsoft.com/en-us/download/details.aspx?id=13255

Settings changed on gmail:

	-Go to gmail settings ->Forwarding and POP/IMAP ->POP Download: ->select Enable POP for all mail

	-Go to my account -> sign-in and security -> connected apps & sites -> Allow less secure apps: on

Status:

	Will currently download mail & put it into a list. Emails are saved to the database, so the info can be used autonomously.

	The mail currently does not save to/load from the database properly. The email does not display yet. The saved emails are not yet encrypted.
