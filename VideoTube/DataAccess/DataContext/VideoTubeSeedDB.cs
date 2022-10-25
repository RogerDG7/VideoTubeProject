using System;
using Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.DataContext
{
    public class VideoTubeSeedDB
    {

        private readonly VideoTubeContext _context;

        public VideoTubeSeedDB(VideoTubeContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckUserData();
            await CheckVideos();
        }

        public async Task CheckUserData()
        {
            if (!_context.Users.Any())
            {
                await _context.Users.AddRangeAsync(new List<User>
                { new User {
                        Id = Guid.Parse("be1e6bb2-24bb-47a8-960d-b2ca82901c40"),
                        Name = "Metallica",
                        UrlPicture = "https://yt3.ggpht.com/ZjcQii3sVKaPcGK3rIm8vot-qwdmm7KAHsWCjlQLsDLa_tm2kykM-Lgmty1IwQWehj7nEzXPUA=s176-c-k-c0x00ffffff-no-rj"
                    },
                    new User
                    {
                        Id = Guid.Parse("5250eaff-06a3-42f3-b840-0d5c356834cb"),
                        Name = "RogerG",
                        UrlPicture = "https://yt3.ggpht.com/yti/AJo0G0nhii36M-n1f_sKsCZhl2KsUc86Sl6PZenCoDMvpA=s88-c-k-c0x00ffffff-no-rj-mo"
                    },
                    new User
                    {
                        Id = Guid.Parse("5741e6b6-a76b-428a-b09a-03e7ee7a4997"),
                        Name = "Megadeth",
                        UrlPicture = "https://yt3.ggpht.com/ivGOVVq3Q4yn1XGM8AL7YrfuOqXR_VMI8nqnugCZz0DdYCK2uxYKLRGVL5fX6nveMdTmTeFV=s48-c-k-c0x00ffffff-no-rj"
                    },
                    new User
                    {
                        Id = Guid.Parse("3da4767d-4858-4392-a81a-3264697d7b34"),
                        Name = "Iron Maiden",
                        UrlPicture = "https://yt3.ggpht.com/ytc/AMLnZu8_KZjK_ACNJYhOsqHMmJhgLBex842pUqfWyJLTxQ=s48-c-k-c0x00ffffff-no-rj-mo"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckVideos()
        {
            if (!_context.videos.Any())
            {
                await _context.videos.AddRangeAsync(new List<Video>
                { new Video {
                        Id = Guid.NewGuid(),
                        Title = "Metallica: One (Official Music Video)(Official Music Video)",
                        Description ="Metallica's official music video for “One,” from the album “...And Justice for All.” Subscribe for more videos: https://metallica.lnk.to/subscribe",
                        Likes = 0,
                        Dislikes = 0,
                        ThumbnailUrl = "https://i.scdn.co/image/ab67616d0000b273be54746b374358970b5e617a",
                        UloapDate = DateTime.UtcNow,
                        UserID = Guid.Parse("be1e6bb2-24bb-47a8-960d-b2ca82901c40"),
                        Url = "WM8bTdBs-cw"
                    },
                    new Video {
                        Id = Guid.NewGuid(),
                        Title = "Metallica: Master of Puppets (Official Lyric Video)",
                        Description ="Official lyric video for \"Master of Puppets.\" Animation by ILOVEDUST.  Subscribe for more videos:",
                        Likes = 0,
                        Dislikes = 0,
                        ThumbnailUrl = "https://img.europapress.es/fotoweb/fotonoticia_20160305095544_1200.jpg",
                        UloapDate = DateTime.UtcNow,
                        UserID = Guid.Parse("be1e6bb2-24bb-47a8-960d-b2ca82901c40"),
                        Url = "6xjJ2XIbGRk"
                    },
                    new Video {
                        Id = Guid.NewGuid(),
                        Title = "Metallica: Nothing Else Matters (Official Music Video)",
                        Description ="Metallica's official music video for “Nothing Else Matters,” from the album “Metallica.” Subscribe for more videos: https://metallica.lnk.to/subscribe",
                        Likes = 0,
                        Dislikes = 0,
                        ThumbnailUrl = "https://www.rhino.com/sites/g/files/g2000012691/files/styles/article_image/public/nothingelsematters.jpg?itok=c7GTvanB",
                        UloapDate = DateTime.UtcNow,
                        UserID = Guid.Parse("be1e6bb2-24bb-47a8-960d-b2ca82901c40"),
                        Url = "tAGnKpE4NCI"
                    },
                    new Video {
                        Id = Guid.NewGuid(),
                        Title = "Symphony Of Destruction (Official Music)",
                        Description ="Provided to YouTube by Universal Music Group Symphony Of Destruction · Megadeth",
                        Likes = 0,
                        Dislikes = 0,
                        ThumbnailUrl = "https://i.scdn.co/image/ab67616d0000b2737b178f928742be1492c6fba2",
                        UloapDate = DateTime.UtcNow,
                        UserID = Guid.Parse("5741e6b6-a76b-428a-b09a-03e7ee7a4997"),
                        Url = "WdoXZf-FZyA"
                    },
                    new Video {
                        Id = Guid.NewGuid(),
                        Title = "Iron Maiden - Fear of the Dark (2015 Remaster)",
                        Description ="Provided to YouTube by Parlophone UK Fear of the Dark (2015 Remaster) · Iron Maiden",
                        Likes = 0,
                        Dislikes = 0,
                        ThumbnailUrl = "https://i.scdn.co/image/ab67616d0000b273e1d08ba386fcc6b38c47d5be",
                        UloapDate = DateTime.UtcNow,
                        UserID = Guid.Parse("3da4767d-4858-4392-a81a-3264697d7b34"),
                        Url = "bePCRKGUwAY"
                    },
                    new Video {
                        Id = Guid.NewGuid(),
                        Title = "Iron Maiden - The Trooper (Official Video)",
                        Description ="The Official Video for Iron Maiden -  The Trooper Iron Maiden’s 17th studio album 'Senjutsu' Is out now - https://ironmaiden.lnk.to/Senjutsu",
                        Likes = 0,
                        Dislikes = 0,
                        ThumbnailUrl = "https://i.scdn.co/image/ab67616d0000b273291b0e8f1a74c2bc9f9d3110",
                        UloapDate = DateTime.UtcNow,
                        UserID = Guid.Parse("3da4767d-4858-4392-a81a-3264697d7b34"),
                        Url = "X4bgXH3sJ2Q"
                    },
                });
                await _context.SaveChangesAsync();
            }
        }

    }
}

