using EntityLayer.Model.Entities.Base;

namespace BusinessLayer.Interfaces
{
    public interface IBaseCommonBll
    {
        bool Delete(BaseEntity entity);
    }
}
