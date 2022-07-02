namespace InnoTech_Blazor_Training.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseSettingsController<TEntity> : BaseController<TEntity> where TEntity : BaseSettingsEntity
    {
        private readonly IBaseSettingsUnitOfWork<TEntity> _baseSettingsUnitOfWork;

        public BaseSettingsController(IBaseSettingsUnitOfWork<TEntity> unitOfWork) : base(unitOfWork) =>
                                                                _baseSettingsUnitOfWork = unitOfWork;


        [HttpGet("search/{searchText}")]
        public virtual async Task<IEnumerable<TEntity>> Search([FromRoute] string searchText) => await _baseSettingsUnitOfWork.Search(searchText);
    }
}
