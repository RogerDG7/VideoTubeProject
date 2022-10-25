using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bussines.Implement;
using Common.Utilities.Mapper;
using Common.Utilities.ResponseModels;
using DataAccess.DataContext;
using Models.Video;
using Services.VideoService.Implements;
using VideoTube.Controllers;

namespace VideoTubeTest;

[TestFixture]
public class Tests
{
    private IMapper _mapper;
    private VideoController videoController;

    [SetUp]
    public void Setup()
    {
        if (_mapper == null)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new VideoTubeProfileMap());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        videoController = new(new VideoActions(
               new VideoServiceRepository(new VideoTubeContext()), _mapper)
           );
    }

    [Test]
    public async Task Get_all_video_random()
    {
        Response<List<VideoModel>> Response = await videoController.GetVideosRandom();
        Assert.IsTrue(Response.ObjectResponse.Count > 0);
    }

    [Test]
    public async Task Get_all_video_by_id()
    {
        Response<VideoModel> Response = await videoController.GetByIdVideo(Guid.Parse("87f2e8d6-2491-4d80-ac1d-cb73d64c56d5"));
        Assert.IsTrue(!string.IsNullOrEmpty(Response.ObjectResponse.Title));
    }
}
