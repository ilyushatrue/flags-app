using DAL.Repositories;

namespace BL;

public class FlagAreaService
{
    private readonly FlagArea _repository;
    public FlagAreaService()
    {
        _repository = new FlagAreaRe();
    }
}
