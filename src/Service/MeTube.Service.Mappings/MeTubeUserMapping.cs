using MeTube.Data.Models;
using MeTube.Service.Models;

namespace MeTube.Service.Mappings;

public static class MeTubeUserMapping
{
    public static MeTubeUser ToMeTubeUserEntity(this MeTubeUserDto meTubeUserDto)
    {
        MeTubeUser meTubeUser = new MeTubeUser();

        meTubeUser.Id = meTubeUserDto.Id;
        meTubeUser.Email = meTubeUserDto.Email;
        meTubeUser.PhoneNumber = meTubeUserDto.PhoneNumber;
        meTubeUser.UserName = meTubeUserDto.UserName;

        return meTubeUser;
    }

    public static MeTubeUserDto ToMeTubeUserDto(this MeTubeUser meTubeUser)
    {
        MeTubeUserDto meTubeUserDto = new MeTubeUserDto();

        meTubeUserDto.Id = meTubeUser.Id;
        meTubeUserDto.Email = meTubeUser.Email;
        meTubeUserDto.PhoneNumber = meTubeUser.PhoneNumber;
        meTubeUserDto.UserName = meTubeUser.UserName;

        return meTubeUserDto;
    }
}
