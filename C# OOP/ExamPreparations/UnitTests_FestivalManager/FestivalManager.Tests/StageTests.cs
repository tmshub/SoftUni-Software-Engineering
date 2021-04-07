// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void test1()
	    {
			Performer performer = new Performer("Gosh", "Mosh", 22);

			Assert.That(performer.Age, Is.EqualTo(22));
			Assert.That(performer.FullName, Is.EqualTo("Gosh"+" "+"Mosh"));
		}

		[Test]
		public void test2()
		{
			DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
			DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);
			TimeSpan timeSpan = date2 - date1;
			Song song = new Song("Josh", timeSpan);

			Assert.That(song.Duration, Is.EqualTo(timeSpan));
			Assert.That(song.Name, Is.EqualTo("Josh"));
			Assert.That(song.ToString(), Is.EqualTo($"{song.Name} ({song.Duration:mm\\:ss})"));
		}

		[Test]
		public void test3()
		{
			Stage stage = new Stage();
			Performer performer = null;

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
			performer = new Performer("Gosh", "Mosh", 3);
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
			performer = new Performer("Gosh", "Mosh", 34);
			stage.AddPerformer(performer);
			Assert.That(stage.Performers.Count == 1);
		}

		[Test]
		public void test4()
		{
			Stage stage = new Stage();
			Performer performer = null;
			Song song = new Song("Goo", new TimeSpan(0,0,3));

			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}

		[Test]
		public void test5()
		{
			Stage stage = new Stage();
			Song song = new Song("Goo", new TimeSpan(0, 2, 3));
			stage.AddSong(song);
			Performer performer = new Performer("Gosh", "Mosh", 55);
			stage.AddPerformer(performer);
			
			stage.AddSongToPerformer("Goo", "Gosh"+" "+"Mosh");
			Assert.That(performer.SongList.Count, Is.EqualTo(1));
			Assert.That(performer.SongList.First(), Is.EqualTo(song));
			Assert.That(() => stage.AddSongToPerformer("Goo", "Gosh" + " " + "Mosh"), Is.EqualTo($"{song} will be performed by {performer}"));

		}

		[Test]
		public void test6()
		{
			Stage stage = new Stage();
			Song song = new Song("Goo", new TimeSpan(0, 2, 3));
			stage.AddSong(song);
			Performer performer = new Performer("Gosh", "Mosh", 55);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer("Goo", "Gosh" + " " + "Mosh");

			Assert.That(() => stage.Play(), Is.EqualTo($"{stage.Performers.Count} performers played 1 songs"));
		}

		[Test]
		public void test7()
		{
			Stage stage = new Stage();
			Song song = new Song("Goo", new TimeSpan(0, 2, 3));
			stage.AddSong(song);
			Performer performer = new Performer("Gosh", "Mosh", 55);
			stage.AddPerformer(performer);

			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Go", "Gosh" + " " + "Mosh"));
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("Go0", "Goseh" + " " + "Mosh"));

		}
	}
}