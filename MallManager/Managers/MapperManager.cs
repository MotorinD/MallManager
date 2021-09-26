using AutoMapper;

namespace MallManager.Managers
{
    public class MapperManager
    {
        private readonly Mapper _mapper;
        public MapperManager()
        {
            this._mapper = new Mapper(MapperConfiguration.GetConfiguration());
        }

        public Mapper GetActive()
        {
            return this._mapper;
        }
    }
}
