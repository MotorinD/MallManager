using AutoMapper;

namespace MallManager.Managers
{
    /// <summary>
    /// Менеджер доступа к моделям данных, содержащих бизнес-логику и используемых в приложении
    /// </summary>
    public partial class DataManager
    {
        private EntityManager _entityManager => ManagerHelper.Entity;
        private Mapper _mapper => ManagerHelper.Mapper.GetActive();
    }
}
